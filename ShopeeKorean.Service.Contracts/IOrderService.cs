using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Shared.RequestFeatures;
using ShopeeKorean.Shared.DataTransferObjects.Order;
using System.Dynamic;

namespace ShopeeKorean.Service.Contracts
{
    public interface IOrderService
    {
        public Task<Result<OrderDto>> GetOrder(Guid orderId, bool trackChanges, string? isInclude = default);
        public Task<Result<IEnumerable<ExpandoObject>>> GetOrders(Guid userId, OrderParameters orderParameters, bool trackChanges, string? isInclude = null);
        public Task<Result<OrderDto>> CreateOrder(OrderForCreationDto orderDto, Guid userId);
        public Task<Result> UpdateOrder(OrderForUpdateDto orderDto);
    }
}
