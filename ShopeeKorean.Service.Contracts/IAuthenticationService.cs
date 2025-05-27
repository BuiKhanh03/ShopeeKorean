using Microsoft.AspNetCore.Identity;
using ShopeeKorean.Shared.DataTransferObjects;

namespace ShopeeKorean.Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication);
        Task<string> CreateToken();


    }
}
