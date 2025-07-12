using Contracts;
using AutoMapper;
using System.Dynamic;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Shared.RequestFeatures;
using ShopeeKorean.Shared.Constant.Category;
using ShopNoteeKorean.Shared.Constant.Product;
using ShopeeKorean.Shared.Constant.Authentication;
using ShopeeKorean.Shared.DataTransferObjects.Product;
using Microsoft.AspNetCore.Authorization;
using ShopeeKorean.Shared.Extension;

namespace ShopeeKorean.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IDataShaperManager _dataShaper;
        private readonly IRepositoryManager _repositoryManager;
        public ProductService(IMapper mapper, ILoggerManager loggerManager, IRepositoryManager repositoryManager, IDataShaperManager dataShaper)
        {
            _mapper = mapper;
            _dataShaper = dataShaper;
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
        }

        [Authorize]
        public async Task<Result<ProductDto>> CreateProduct(ProductDtoForCreation product, Guid SellerId)
        {
            var resultCategoryCheck = await this.GetAndCheckCategory(product.CategoryId, trackChanges: false);
            var resultSellerCheck = await this.GetAndCheckSeller(SellerId, trackChanges: false);

            if (!resultCategoryCheck.IsSuccess) return Result<ProductDto>.BadRequest([ProductErrors.GetProduct_CategoryNotFound(product.CategoryId)]);
            if (!resultSellerCheck.IsSuccess) return Result<ProductDto>.BadRequest([ProductErrors.GetProduct_UserNotFound(SellerId)]);

            var productEntity = _mapper.Map<Product>(product);

            productEntity.CreatedAt = DateTime.UtcNow;
            productEntity.UpdatedAt = DateTime.UtcNow;
            productEntity.SellerId = SellerId;
            productEntity.Status = Shared.Enums.Status.SystemStatus.Inactive;

            await _repositoryManager.ProductRepository.CreateProduct(productEntity);
            await _repositoryManager.SaveAsync();

            var productReturned = _mapper.Map<ProductDto>(productEntity);
            return Result<ProductDto>.Ok(productReturned);
        }

        public async Task<Result<ProductDto>> GetProduct(Guid productId, bool trackChanges = false, string? isInclude = null)
        {
            var resultCheck = await this.GetAndCheckProduct(productId, trackChanges, isInclude);
            if (!resultCheck.IsSuccess) return Result<ProductDto>.BadRequest(resultCheck.Errors!);
            var productEntity = resultCheck.GetValue<Product>();
            var productReturned = _mapper.Map<ProductDto>(productEntity);
            return Result<ProductDto>.Ok(productReturned);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetProducts(ProductParameters productParameters, bool trackChanges = false, string? isInclude = null)
        {
            var products = await _repositoryManager.ProductRepository.GetProducts(productParameters, trackChanges, isInclude);

            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            var productShapped = _dataShaper.Product.ShapeData(productDtos, productParameters.Field);

            return Result<IEnumerable<ExpandoObject>>.Ok(productShapped, products.MetaData);
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetProducts(Guid userId, ProductParameters productParameters, bool trackChanges = false, string? isInclude = null)
        {
            var products = await _repositoryManager.ProductRepository.GetProducts(userId, productParameters, trackChanges, isInclude);

            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            var productShapped = _dataShaper.Product.ShapeData(productDtos, productParameters.Field);

            return Result<IEnumerable<ExpandoObject>>.Ok(productShapped, products.MetaData);
        }

        [Authorize]
        public async Task<Result> UpdateProduct(Guid productId, ProductDtoForUpdate product)
        {
            var resultCategoryCheck = await this.GetAndCheckCategory(product.CategoryId, trackChanges: false);
            var resultProductCheck = await this.GetAndCheckProduct(productId, trackChanges: true);
            if(!resultProductCheck.IsSuccess) return Result<ProductDto>.BadRequest([ProductErrors.GetProductNotFound(productId)]);
            if (!resultCategoryCheck.IsSuccess) return Result<ProductDto>.BadRequest([ProductErrors.GetProduct_CategoryNotFound(product.CategoryId)]);
            var productValue = resultProductCheck.GetValue<Product>();
            var productEntity = _mapper.Map(product, productValue);
            productEntity.UpdatedAt = DateTime.UtcNow;

            this._repositoryManager.ProductRepository.UpdateProduct(productEntity);
            await _repositoryManager.SaveAsync();
            return Result.NoContent();
        }

        private async Task<Result<Product>> GetAndCheckProduct(Guid productId, bool trackChanges, string? include = default) {
            var product = await _repositoryManager.ProductRepository.GetProduct(productId, trackChanges, include);
            if (product == null) return Result<Product>.BadRequest([ProductErrors.GetProductNotFound(productId)]);
            return Result<Product>.Ok(product);
        }

        private async Task<Result<Category>> GetAndCheckCategory(Guid categoryId, bool trackChanges, string? include = default)
        {
            var category = await _repositoryManager.CategoryRepository.GetCategory(categoryId, trackChanges, include);
            if (category == null) return Result<Category>.BadRequest([CategoryErrors.GetCategoryNotFoundWithIdError(categoryId)]);
            return Result<Category>.Ok(category);
        }

        private async Task<Result<User>> GetAndCheckSeller(Guid sellerId, bool trackChanges, string? include = default)
        {
            var seller = await _repositoryManager.UserRepository.GetUser(sellerId, trackChanges, include);
            if (seller == null) return Result<User>.BadRequest([UserErrors.GetUserNotFoundWithIdError(sellerId)]);
            return Result<User>.Ok(seller);
        }
    }
}
