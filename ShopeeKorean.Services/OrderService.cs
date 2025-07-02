using AutoMapper;
using Contracts;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.Extension;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Shared.RequestFeatures;
using ShopNoteeKorean.Shared.Constant.Product;
using ShopeeKorean.Shared.DataTransferObjects.Order;
using System.Dynamic;

namespace ShopeeKorean.Service
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IDataShaperManager _dataShaper;
        private readonly IRepositoryManager _repositoryManager;
        public OrderService(IMapper mapper, ILoggerManager loggerManager, IRepositoryManager repositoryManager, IDataShaperManager dataShaper)
        {
            _mapper = mapper;
            _dataShaper = dataShaper;
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<OrderDto>> CreateOrder(OrderForCreationDto orderDto, Guid userId)
        {
            decimal totalAmount = 0;

            foreach (var item in orderDto.OrderItems)
            {
                var productResult = await this.GetAndCheckProduct(item.ProductId, trackChanges: false);
                if (!productResult.IsSuccess)
                    return Result<OrderDto>.BadRequest(productResult.Errors!);

                var product = productResult.GetValue<Product>();
                var price = product.Price;

                totalAmount += price * item.Quantity;
            }

            var orderEntity = _mapper.Map<Order>(orderDto);
            orderEntity.UserId = userId;
            orderEntity.TotalAmount = totalAmount + orderDto.ShippingFee;
            orderEntity.CreateAt = DateTime.Now;
            orderEntity.UpdateAt = DateTime.Now;


            await _repositoryManager.OrderRepository.CreateOrder(orderEntity);
            await _repositoryManager.SaveAsync();

            var resultDto = _mapper.Map<OrderDto>(orderEntity);
            return Result<OrderDto>.Ok(resultDto);
        }

        public Task<Result<OrderDto>> GetOrder(Guid orderId, bool trackChanges, string? isInclude = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetOrders(Guid userId, OrderParameters orderParameters, bool trackChanges, string? isInclude = null)
        {
           var orders = await _repositoryManager.OrderRepository.GetOrders(userId, orderParameters, trackChanges, isInclude);
           var orderDtos =  _mapper.Map<IEnumerable<OrderDto>>(orders);
            var orderShappers = _dataShaper.Order.ShapeData(orderDtos, orderParameters.Field);
            return Result<IEnumerable<ExpandoObject>>.Ok(orderShappers, orders.MetaData);
        }

        public Task<Result> UpdateOrder(OrderForUpdateDto orderDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Product>> GetAndCheckProduct(Guid productId, bool trackChanges, string? include = null)
        {
            var productResult = await _repositoryManager.ProductRepository.GetProduct(productId, trackChanges, include);
            if (productResult == null) return Result<Product>.BadRequest([ProductErrors.GetProductNotFound(productId)]);
            return Result<Product>.Ok(productResult);
        }
    }
}
