using Contracts;
using AutoMapper;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.ResultModel;
using ShopNoteeKorean.Shared.Constant.Product;
using ShopeeKorean.Shared.DataTransferObjects.ProductImage;
using ShopeeKorean.Shared.Extension;

namespace ShopeeKorean.Service
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IDataShaperManager _dataShaper;
        private readonly IRepositoryManager _repositoryManager;
        public ProductImageService(IMapper mapper, ILoggerManager loggerManager, IRepositoryManager repositoryManager, IDataShaperManager dataShaper)
        {
            _mapper = mapper;
            _dataShaper = dataShaper;
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<IEnumerable<ProductImageDto>>> GetProductImages(Guid productId, bool trackChanges = false, string? include = null)
        {
            var productImage = await _repositoryManager.ProductImageRepository.GetProductImages(productId, trackChanges, include);
            var productEntity = _mapper.Map<IEnumerable<ProductImageDto>>(productImage);
            return Result<IEnumerable<ProductImageDto>>.Ok(productEntity);
        }

        public async Task<Result<string>> CreateProductImage(Guid productId, bool trackChanges, string imageId, string imageUrl)
        {
            var resultCheck = await this.GetAndCheckProduct(productId, trackChanges);
            if(!resultCheck.IsSuccess) return Result<string>.BadRequest(resultCheck.Errors!);

            var productImageDto = new ProductImageDtoForCreation()
            {
                ProductId = productId,
                ImageId = imageId,
                ImageLink = imageUrl,
                IsMain = false
            };

            var productEntity = _mapper.Map<ProductImage>(productImageDto);
            await _repositoryManager.ProductImageRepository.CreateProductImage(productEntity);
            await _repositoryManager.SaveAsync();
            return Result<string>.Ok(imageUrl);
        }

        public async Task<Result> UpdateProductImage(Guid productId, Guid productImageId, ProductImageDtoForUpdate productImageDto)
        {
            var resultProductCheck = await this.GetAndCheckProduct(productId, trackChanges: false);
            var resultProductImageCheck = await this.GetAndCheckProductImage(productImageId, trackChanges: true);
            if (!resultProductCheck.IsSuccess) return Result.BadRequest(resultProductCheck.Errors!);
            if (!resultProductImageCheck.IsSuccess) return Result.BadRequest(resultProductImageCheck.Errors!);
            var productImages = await _repositoryManager.ProductImageRepository.GetProductImages(productId, trackChanges: false);
            foreach (var productImage in productImages) {
                productImage.IsMain = false;
            }
            var productImageValue = resultProductCheck.GetValue<ProductImage>();
            var productImageEntity = _mapper.Map<ProductImage>(productImageDto);
            await _repositoryManager.SaveAsync();
            return Result.NoContent();
        }

        private async Task<Result<Product>> GetAndCheckProduct(Guid productId, bool trackChanges)
        {
            var product = await _repositoryManager.ProductRepository.GetProduct(productId, trackChanges);
            if (product == null) return Result<Product>.BadRequest([ProductErrors.GetProductNotFound(productId)]);
            return Result<Product>.Ok(product);
        }

        private async Task<Result<ProductImage>> GetAndCheckProductImage(Guid productImageId, bool trackChanges)
        {
            var productImage = await _repositoryManager.ProductImageRepository.GetProductImage(productImageId, trackChanges);
            if (productImage == null) return Result<ProductImage>.BadRequest([ProductErrors.GetProduct_ImageNotFound(productImageId)]);
            return Result<ProductImage>.Ok(productImage);
        }

        private async Task<Result<ProductImage>> GetAndCheckProductImage(string publicId)
        {
            var productImage = await _repositoryManager.ProductImageRepository.GetProductImage(publicId);
            if (productImage == null) return Result<ProductImage>.BadRequest([ProductErrors.GetProduct_ImageNotFoundImageId(publicId)]);
            return Result<ProductImage>.Ok(productImage);
        }

        public async Task<Result> DeleteProductImage(string publicId)
        {
            var productImage = await this.GetAndCheckProductImage(publicId);
            if (!productImage.IsSuccess) return Result.BadRequest(productImage.Errors!);
            var productImageValue = productImage.GetValue<ProductImage>();
            _repositoryManager.ProductImageRepository.DeleteProductImage(productImageValue);
            await _repositoryManager.SaveAsync();
            return Result.NoContent();
        }

        public async Task<Result> UpdateProductImage(Guid productId, Guid productImageId, bool trackChanges = false)
        {
            var resultProductCheck = await this.GetAndCheckProduct(productId, trackChanges: false);
            var resultImageCheck = await this.GetAndCheckProductImage(productImageId, trackChanges: true);
            if(!resultImageCheck.IsSuccess) return Result.BadRequest(resultImageCheck.Errors!);
            if(!resultProductCheck.IsSuccess) return Result.BadRequest(resultProductCheck.Errors!);

            var productImages = await _repositoryManager.ProductImageRepository.GetProductImages(productId);
            foreach (var image in productImages) { 
               image.IsMain = false;
            } 

            var productImageValue = resultImageCheck.GetValue<ProductImage>();

            productImageValue.IsMain = true;
            _repositoryManager.ProductImageRepository.UpdateImage(productImageValue);
            await _repositoryManager.SaveAsync();
            return Result.NoContent();

        }
    }
}
