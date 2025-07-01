using Repository;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Repository.Contracts;

namespace ShopeeKorean.Repository
{
    public class ShippingRepository : RepositoryBase<Shipping>, IShippingRepository
    {
        public ShippingRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public async Task CreateShipping(Shipping shipping)
       => await CreateAsync(shipping);
    }
}
