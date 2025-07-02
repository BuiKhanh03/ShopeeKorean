using AutoMapper;
using Contracts;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.DataTransferObjects.CartItemDto;
using ShopeeKorean.Shared.DataTransferObjects.OrderItem;
using ShopeeKorean.Shared.Extension;
using ShopeeKorean.Shared.ResultModel;
using ShopNoteeKorean.Shared.Constant.Product;

namespace ShopeeKorean.Service
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IDataShaperManager _dataShaper;
        private readonly IRepositoryManager _repositoryManager;
        public OrderItemService(IMapper mapper, ILoggerManager loggerManager, IRepositoryManager repositoryManager, IDataShaperManager dataShaper)
        {
            _mapper = mapper;
            _dataShaper = dataShaper;
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<OrderItemDto>> CreateOrder(OrderItemForCreationDto orderItem, bool trackChanges, string? isInclude = default)
        {
            var productResultCheck = await this.GetAndCheckProduct(orderItem.ProductId, trackChanges);
            if (!productResultCheck.IsSuccess) return Result<OrderItemDto>.BadRequest(productResultCheck.Errors!);
            var orderItemEntity = _mapper.Map<OrderItem>(orderItem);
            var productEntity = productResultCheck.GetValue<Product>();
            orderItemEntity.PriceAtTime = productEntity.Price;
            await _repositoryManager.OrderItemRepository.CreateOrder(orderItemEntity);
            await _repositoryManager.SaveAsync();
            var orderItemReturned = _mapper.Map<OrderItemDto>(orderItemEntity);
            return Result<OrderItemDto>.Ok(orderItemReturned);
        }

        public async Task<Result<Product>> GetAndCheckProduct(Guid productId, bool trackChanges, string? include = null)
        {
            var productResult = await _repositoryManager.ProductRepository.GetProduct(productId, trackChanges, include);
            if (productResult == null) return Result<Product>.BadRequest([ProductErrors.GetProductNotFound(productId)]);
            return Result<Product>.Ok(productResult);
        }
    }
}
