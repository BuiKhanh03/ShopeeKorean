using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Shared.DataTransferObjects.ProductImage;

namespace ShopeeKorean.Service.Contracts
{
    public interface IProductImageService 
    {
        public Task<Result<string>> CreateProductImage(Guid productId, bool trackChanges, string imageId, string imageUrl);

        public Task<Result<IEnumerable<ProductImageDto>>> GetProductImages(Guid productId, bool trackChanges = false, string? include = null);

        public Task<Result> UpdateProductImage(Guid productId, Guid productImageId, bool trackChanges = false);

        public Task<Result> DeleteProductImage(string publicId);
    }
}
