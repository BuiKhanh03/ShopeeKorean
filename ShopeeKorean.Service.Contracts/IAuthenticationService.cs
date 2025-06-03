using Microsoft.AspNetCore.Identity;
using ShopeeKorean.Shared.DataTransferObjects.User;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Service.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication);
        Task<UserTokenDto> CreateToken(bool populateExp);
        Task<UserTokenDto> RefreshToken(UserTokenDto tokenDto);
        public Task<Result<string>> CreateConfirmEmailUrl(string email);
        public Task<Result> ConfirmEmail(UserForConfirmGmailDto userForConfirmGmail);
    }
}
