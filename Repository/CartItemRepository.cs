using Microsoft.EntityFrameworkCore;
using Repository;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Repository.Contracts;
using ShopeeKorean.Repository.Extensions.Utility;
using ShopeeKorean.Shared.RequestFeatures;

namespace ShopeeKorean.Repository
{
    public class CartItemRepository : RepositoryBase<CartItem>, ICartItemRepository
    {
        public CartItemRepository(RepositoryContext repository) : base(repository)
        {
            
        }
        public async Task CreateCartItem(CartItem cartItem)
        => await base.CreateAsync(cartItem);

        public async Task<PagedList<CartItem>> GetCartItems(Guid cartId, CartItemParameters cartItemParameters, bool trackChanges, string include)
        {
          var cartItems = await base.FindByCondition(c => c.CartId.Equals(cartId), trackChanges).IsInclude(include).ToListAsync();

            return PagedList<CartItem>.ToPagedList(
                cartItems,
                cartItemParameters.PageNumber,
                cartItemParameters.PageSize

                );
        }
    }
}
