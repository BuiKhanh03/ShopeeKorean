using Contracts;
using AutoMapper;
using System.Text;
using System.Security.Claims;
using ShopeeKorean.Entities.Models;
using System.Security.Cryptography;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ShopeeKorean.Service.Contracts;
using System.IdentityModel.Tokens.Jwt;
using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Entities.ConfigurationModels;
using ShopeeKorean.Shared.DataTransferObjects.User;
using ShopeeKorean.Application.Extensions.Exceptions;
using ShopeeKorean.Shared.Constant.Authentication;
using ShopeeKorean.Service.Extensions;

namespace ShopeeKorean.Service
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly UserManager<User> _userManager;
        private readonly JwtConfiguration _jwtConfiguration;
        private readonly IOptions<JwtConfiguration> _configuration;

        private User? _user;


        public AuthenticationService(ILoggerManager loggerManager, IMapper mapper, UserManager<User> userManager, IOptions<JwtConfiguration> configuration)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _jwtConfiguration = _configuration.Value;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (result.Succeeded) await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
            return result;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication)
        {
            _user = await _userManager.FindByNameAsync(userForAuthentication.Username);

            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuthentication.Password));
            if (!result) _loggerManager.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong username or password.");
            return result;
        }

        public async Task<UserTokenDto> CreateToken(bool populateExp)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();

            _user.RefreshToken = refreshToken;

            if (populateExp) 
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            await _userManager.UpdateAsync(_user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new UserTokenDto(accessToken, refreshToken);

        }

        public async Task<UserTokenDto> RefreshToken(UserTokenDto tokenDto)
        {
            var principal = GetClaimsPrincipalFromExpiredToken(tokenDto.AccessToken);

            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new RefreshTokenBadRequest();

            _user = user;
            return await CreateToken(populateExp: false);

        }

        public async Task<Result> ConfirmEmail(UserForConfirmGmailDto userForConfirmGmail)
        {
            _user = await _userManager.FindByEmailAsync(userForConfirmGmail.Email);
            if (_user == null) return Result.NotFound([UserErrors.GetUserNotFoundWithEmailError(userForConfirmGmail.Email)]);
            var result = await _userManager.ConfirmEmailAsync(_user, Uri.UnescapeDataString(userForConfirmGmail.Email));
            if (!result.Succeeded)
                return result.InvalidResult();

            await UpdateUserAsync();
            return Result.Ok();
        }

        public async Task<Result<string>> CreateConfirmEmailUrl(string email)
        {
            _user = await _userManager.FindByEmailAsync(email);
            var result = _user == null;
            if (!result) _loggerManager.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong username or password.");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(_user);
            var baseUrl = _jwtConfiguration.ValidAudience;
            var builder = new UriBuilder(baseUrl!)
            {
                Path = "api/authentication/confirm-email",
                Query = $"email={email}&token={Uri.EscapeDataString(token)}"
            };
            var resetPasswordUrl = builder.ToString();

            return Result<string>.Ok(resetPasswordUrl);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = _jwtConfiguration.SecretKey;
            if (string.IsNullOrEmpty(key))
            {
                throw new InvalidOperationException("JWT secret key is not configured");
            }

            var keyBytes = Encoding.UTF8.GetBytes(key);
            var secret = new SymmetricSecurityKey(keyBytes);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim("UserId", _user!.Id.ToString()!),
                new Claim("FirstName", _user!.FirstName!),
                new Claim("LastName", _user!.LastName!)
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {

            var tokenOptions = new JwtSecurityToken
            (
             issuer: _jwtConfiguration.ValidIssuer,
             audience: _jwtConfiguration.ValidAudience,
             claims: claims,
             expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
             signingCredentials: signingCredentials
             );
            return tokenOptions;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token)
        {
            var key = _jwtConfiguration.SecretKey;
            if (string.IsNullOrEmpty(key))
            {
                throw new InvalidOperationException("JWT secret key is not configured");
            }

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                ValidateLifetime = true,
                ValidIssuer = _jwtConfiguration.ValidIssuer,
                ValidAudience = _jwtConfiguration.ValidAudience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if(jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid Token");
            }
            return principal;
        }

        private async Task UpdateUserAsync()
        {
            await _userManager.UpdateAsync(_user);
        }


      
    }
}
