using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Contracts
{
    public interface IShippingRepository
    {
        public Task CreateShipping(Shipping shipping);
    }
}
