using Repository;
using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using ShopeeKorean.Repository.Contracts;

namespace ShopeeKorean.Repository
{
    public class ProductSizeRepository : RepositoryBase<ProductSize>, IProductSizeRepository
    {
        public ProductSizeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public async Task CreateProductSize(ProductSize productSize)
        {
            await base.CreateAsync(productSize);
        }

        public async Task<ProductSize?> GetProductSize(Guid productSizeId, bool trackChanges = false)
        {
            return  await base.FindByCondition(p => p.Id.Equals(productSizeId), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateProductSize(ProductSize productSize)
        {
          base.Update(productSize);
        }
    }
}
