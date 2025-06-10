using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Contracts
{
    public interface IProductImageRepository
    {
        public Task<IEnumerable<ProductImage>> GetProductImages(Guid productId, bool trackChanges = false, string? include = default);

        public Task<ProductImage?> GetProductImage(Guid productImageId, bool trackChanges = false);

        public Task<ProductImage?> GetProductImage(string publicId);

        public Task CreateProductImage(ProductImage productImage);

        public void UpdateImage(ProductImage productImage);

        public void DeleteProductImage(ProductImage productImage);
    }
}
