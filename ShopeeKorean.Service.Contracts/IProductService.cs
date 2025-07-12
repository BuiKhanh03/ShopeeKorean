using System.Dynamic;
using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Shared.RequestFeatures;
using ShopeeKorean.Shared.DataTransferObjects.Product;

namespace ShopeeKorean.Service.Contracts
{
    public interface IProductService
    {
        public Task<Result<ProductDto>> GetProduct(Guid productId, bool trackChanges = false, string? isInclude = default);
        public Task<Result<IEnumerable<ExpandoObject>>> GetProducts(ProductParameters productParameters, bool trackChanges = false, string? isInclude = default);

        public Task<Result<IEnumerable<ExpandoObject>>> GetProducts(Guid userId,ProductParameters productParameters, bool trackChanges = false, string? isInclude = default);
        public Task<Result<ProductDto>> CreateProduct(ProductDtoForCreation product, Guid SellerId);
        public Task<Result> UpdateProduct(Guid productId, ProductDtoForUpdate product);
    }
}
