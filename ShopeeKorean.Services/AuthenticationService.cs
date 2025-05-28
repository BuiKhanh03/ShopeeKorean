using Contracts;
using AutoMapper;
using System.Text;
using ShopeeKorean.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ShopeeKorean.Service.Contracts;
using Microsoft.Extensions.Configuration;
using ShopeeKorean.Shared.DataTransferObjects;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace ShopeeKorean.Service
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        private User? _user;


        public AuthenticationService(ILoggerManager loggerManager, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _loggerManager = loggerManager;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
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
        private SigningCredentials GetSigningCredentials()
        {
            var key = _configuration["SECRETKEY"];
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
                new Claim(ClaimTypes.Name, _user.UserName)
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
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken
    (
        issuer: jwtSettings["validIssuer"],
        audience: jwtSettings["validAudience"],
        claims: claims,
        expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
        signingCredentials: signingCredentials
    );
            return tokenOptions;
        }
    }
}
