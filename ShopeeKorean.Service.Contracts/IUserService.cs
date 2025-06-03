using ShopeeKorean.Shared.DataTransferObjects.User;
using ShopeeKorean.Shared.ResultModel;
using System.Dynamic;

namespace ShopeeKorean.Service.Contracts
{
    public interface IUserService
    {
        //ExpandoObject có thể thêm/xóa thuộc tính hoặc phương thức tại runtime 
        public Task<Result<UserDto>> GetUserAsync(Guid userId, bool trackChanges, string? include = null);
        public Task<Result> UpdateUser(Guid id, UserForUpdateDto user, bool trackChanes = false);
    }
}
