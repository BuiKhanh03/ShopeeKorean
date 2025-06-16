using Microsoft.EntityFrameworkCore;
using Repository;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Repository.Contracts;

namespace ShopeeKorean.Repository
{
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(RepositoryContext repository) : base(repository)
        {
            
        }
        public async Task CreateCart(Cart cart)
       => await base.CreateAsync(cart);

        public async Task<Cart?> GetCart(Guid userId, bool trackChanges, string include)
        {
            return await base.FindByCondition(c => c.UserId.Equals(userId), trackChanges).SingleOrDefaultAsync();
        }
    }
}
