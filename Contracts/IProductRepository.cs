using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.RequestFeatures;

namespace ShopeeKorean.Repository.Contracts
{
    public interface IProductRepository
    {
        public Task<Product?> GetProduct(Guid productId, bool trackChanges = false, string? include = default);
        public Task<PagedList<Product>> GetProducts(ProductParameters productPagameters, bool trackChanges = false, string? include = default);
        public Task CreateProduct(Product product);
        public void UpdateProduct(Product product);

    }
}
