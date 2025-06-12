using AutoMapper;
using Contracts;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.Extension;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.ResultModel;
using ShopNoteeKorean.Shared.Constant.Product;
using ShopeeKorean.Shared.DataTransferObjects.ProductSize;

namespace ShopeeKorean.Service
{
    public class ProductSizeService : IProductSizeService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IDataShaperManager _dataShaper;
        private readonly IRepositoryManager _repositoryManager;
        public ProductSizeService(IMapper mapper, ILoggerManager loggerManager, IRepositoryManager repositoryManager, IDataShaperManager dataShaper)
        {
            _mapper = mapper;
            _dataShaper = dataShaper;
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
        }
        public async Task<Result<ProductSizeDto>> CreateProductSize(Guid productId, ProductSizeDtoForCreation productSizeDtoForCreation)
        {
            var resultCheck = await this.GetAndCheckProduct(productId);
            if (!resultCheck.IsSuccess) return Result<ProductSizeDto>.BadRequest(resultCheck.Errors!);

            var productSize = _mapper.Map<ProductSize>(productSizeDtoForCreation);
            productSize.ProductId = productId;
            await _repositoryManager.ProductSizeRepository.CreateProductSize(productSize);
            await _repositoryManager.SaveAsync();
            var productSizeDto = _mapper.Map<ProductSizeDto>(productSize);
            return Result<ProductSizeDto>.Ok(productSizeDto);
        }

        public async Task<Result> UpdateProductSize(Guid productSizeId, ProductSizeDtoForUpdate productSizeDtoForUpdate)
        {
            var resultCheck = await this.GetAndCheckProductSize(productSizeId, trackChanges: true);
            if(!resultCheck.IsSuccess) return Result.BadRequest(resultCheck.Errors!);
            var productSizeValue = resultCheck.GetValue<ProductSize>();
            var productSizeMapping = _mapper.Map(productSizeDtoForUpdate, productSizeValue);
            _repositoryManager.ProductSizeRepository.UpdateProductSize(productSizeMapping);
            await _repositoryManager.SaveAsync();
            return Result.NoContent();
        }

        private async Task<Result<Product>> GetAndCheckProduct(Guid productId) {
            var resultCheck = await _repositoryManager.ProductRepository.GetProduct(productId, false);
            if (resultCheck == null) return Result<Product>.BadRequest([ProductErrors.GetProductNotFound(productId)]);
            return Result<Product>.Ok(resultCheck);
        }

        private async Task<Result<ProductSize>> GetAndCheckProductSize(Guid productSizeId,  bool trackChanges)
        {
            var resultCheck = await _repositoryManager.ProductSizeRepository.GetProductSize(productSizeId, trackChanges);
            if(resultCheck == null) return Result<ProductSize>.BadRequest([ProductErrors.GetProduct_SizeNotFound(productSizeId)]);
            return Result<ProductSize>.Ok(resultCheck);
        }
    }
}
