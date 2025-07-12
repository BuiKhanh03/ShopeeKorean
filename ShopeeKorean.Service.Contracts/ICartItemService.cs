using ShopeeKorean.Shared.DataTransferObjects.CartItemDto;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Service.Contracts
{
    public interface ICartItemService
    {
        public Task<Result> UpdateCartItem(CartItemForUpdateDto cartItemDto, Guid cartItemId, bool trackChanges, string? include = default);
        public Task<Result<CartItemForGetDto>> CreateCartItem(CartItemForCreationDto cartItemDto, Guid userId, bool trackChanges, string? include = default);
        public Task<Result> DeleteCartItem(Guid cartItemId, bool trackChanges);
    }
}
