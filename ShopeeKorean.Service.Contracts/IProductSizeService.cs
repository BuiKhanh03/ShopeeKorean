using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Shared.DataTransferObjects.ProductSize;

namespace ShopeeKorean.Service.Contracts
{
    public interface IProductSizeService
    { 
        public Task<Result<ProductSizeDto>> CreateProductSize(Guid productId, ProductSizeDtoForCreation productSize);

        public Task<Result> UpdateProductSize(Guid productSizeId, ProductSizeDtoForUpdate productSize);
    }
}
