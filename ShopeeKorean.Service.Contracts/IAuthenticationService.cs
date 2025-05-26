using Microsoft.AspNetCore.Identity;
using ShopeeKorean.Shared.DataTransferObjects;

namespace ShopeeKorean.Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
    }
}
