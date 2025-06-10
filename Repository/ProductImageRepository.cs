using Microsoft.EntityFrameworkCore;
using Repository;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Repository.Contracts;
using ShopeeKorean.Repository.Extensions.Utility;

namespace ShopeeKorean.Repository
{
    public class ProductImageRepository : RepositoryBase<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public async Task CreateProductImage(ProductImage productImage) => await base.CreateAsync(productImage);

        public void DeleteProductImage(ProductImage productImage)
        {
            base.Delete(productImage);
        }

        public async Task<ProductImage?> GetProductImage(Guid productImageId, bool trackChanges = false)
        {
            var productImage = await FindByCondition(p => p.Id.Equals(productImageId), trackChanges).SingleOrDefaultAsync();
            return productImage;
        }

        public async Task<ProductImage?> GetProductImage(string publicId)
        {
            var productImage = await FindByCondition(p => p.ImageId!.ToLower().Trim().Equals(publicId.ToLower().Trim()), false).SingleOrDefaultAsync();
            return productImage;
        }

        public async Task<IEnumerable<ProductImage>> GetProductImages(Guid productId, bool trackChanges = false, string? include = null)
        {
            var products = await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
                                                .IsInclude(include)
                                                .ToListAsync();
           return products;
        }

        public void UpdateImage(ProductImage productImage)
          => base.Update(productImage);
    }
}
