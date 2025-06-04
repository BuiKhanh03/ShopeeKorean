using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.RequestFeatures;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Repository.Contracts
{
    public interface IProductRepository
    {
        public Task<Result<Product?>> GetProduct(Guid productId, bool trackChanges = false, string? include = default);
        public Task<PagedList<Product>> GetProducts(Guid userId, ProductParameters productPagameters, bool trackChanges = false, string? include = default);

        public Task CreateProduct(Product product);

        public void UpdateProduct(Product product);

    }
}
