using ShopeeKorean.Shared.RequestFeatures;
using ShopeeKorean.Shared.ResultModel;
using System.Dynamic;

namespace ShopeeKorean.Service.Contracts
{
    public interface IProductService
    {
        public Task<Result<ProductDto>> GetProduct(Guid productId, bool trackChanges = false, string? isInclude = default);
        public Task<Result<ExpandoObject>> GetProducts(ProductParameters productParameters, bool trackChanges = false, string? isInclude = default);

        public Task<Result<ProductDto>> CreateProduct(ProductDtoForCreation product);
        public Task<Result> UpdateProduct(ProductDtoForUpdate product);
    }
}
