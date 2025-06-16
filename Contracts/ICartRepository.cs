using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Contracts
{
    public interface ICartRepository
    {
        public Task CreateCart(Cart cart);
        public Task<Cart?> GetCart(Guid userId, bool trackChanges, string include);
    }
}
