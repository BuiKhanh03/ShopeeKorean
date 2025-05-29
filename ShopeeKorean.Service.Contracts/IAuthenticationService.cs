using Microsoft.AspNetCore.Identity;
using ShopeeKorean.Shared.DataTransferObjects.User;

namespace ShopeeKorean.Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication);
        Task<UserTokenDto> CreateToken(bool populateExp);
        Task<UserTokenDto> RefreshToken(UserTokenDto tokenDto);
    }
}
