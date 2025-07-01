using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Shared.RequestFeatures;
using ShopeeKorean.Shared.DataTransferObjects.Order;

namespace ShopeeKorean.Service.Contracts
{
    public interface IOrderService
    {
        public Task<Result<OrderDto>> GetOrder(Guid orderId, bool trackChanges, string? isInclude = default);
        public Task<Result<IEnumerable<OrderDto>>> GetOrders(Guid userId, OrderParameters orderParameters, bool trackChanges);
        public Task<Result<OrderDto>> CreateOrder(OrderForCreationDto orderDto, Guid userId);
        public Task<Result> UpdateOrder(OrderForUpdateDto orderDto);
    }
}
