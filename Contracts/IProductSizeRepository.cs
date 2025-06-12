using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Contracts
{
    public interface IProductSizeRepository
    {
        public Task CreateProductSize(ProductSize productSize);

        public void UpdateProductSize(ProductSize productSize);

        public Task<ProductSize?> GetProductSize(Guid productSizeId, bool trackChanges = false);
    }
}
