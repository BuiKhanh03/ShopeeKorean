using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.RequestFeatures;

namespace ShopeeKorean.Repository.Contracts
{
    public interface ICartItemRepository
    {
        public Task<PagedList<CartItem>> GetCartItems(Guid cartId ,CartItemParameters cartItemParameters, bool trackChanges, string include);

        public Task CreateCartItem(CartItem cartItem);
    }
}
