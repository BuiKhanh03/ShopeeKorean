using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Shared.DataTransferObjects.Cart;

namespace ShopeeKorean.Service.Contracts
{
    public interface ICartService
    {
        Task<Result<CartDto>> GetCart(Guid userId, bool trackChanges, string? include = default);
    }
}
