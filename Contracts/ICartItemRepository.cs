using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.RequestFeatures;
using System.Diagnostics.Eventing.Reader;

namespace ShopeeKorean.Repository.Contracts
{
    public interface ICartItemRepository
    {
        public Task<PagedList<CartItem>> GetCartItems(Guid cartId ,CartItemParameters cartItemParameters, bool trackChanges, string include);

        public Task<CartItem?> GetCartItem(Guid cartItemId, bool trackChanges, string? include = default);
        public Task<CartItem?> GetCartItemByProduct(Guid productId, bool trackChanges, string? include = default);  

        public Task CreateCartItem(CartItem cartItem);
        public void UpdateCartItem(CartItem cartItem);
        public void DeleteCartItem(CartItem cartItem);
    }
}
