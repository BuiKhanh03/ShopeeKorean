using Microsoft.AspNetCore.Identity;
using ShopeeKorean.Shared.ErrorModel;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Service.Extensions
{
    public static class IdentityResultExtension
    {
        //this gọi InvalidResult() như thể nó là phương thức gốc của IdentityResult.
        //static method trong một static class.
        public static Result InvalidResult(this IdentityResult identityResult)
        {
            //map từng lỗi thành đối tượng ErrorsResult
            var errors = identityResult.Errors
                .Select(ms =>
                new ErrorsResult()
                {
                    Code = ms.Code,
                    Description = ms.Description,
                }).ToList();
            return Result.BadRequest(errors);
        } 
    }
}
