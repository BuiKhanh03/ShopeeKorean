using ShopeeKorean.Shared.DataTransferObjects.Order;
using ShopeeKorean.Shared.RequestFeatures;
using ShopeeKorean.Shared.ResultModel;
using System.Security.Cryptography.X509Certificates;

namespace ShopeeKorean.Service.Contracts
{
    public interface IOrderService
    {
        public Task<Result<OrderDto>> GetOrder(Guid orderId, bool trackChanges, string? isInclude = default);
        public Task<Result<IEnumerable<OrderDto>>> GetOrders(Guid userId, OrderParameters orderParameters, bool trackChanges);
        public Task<Result<OrderDto>> CreateOrder(OrderForCreationDto orderDto);
        public Task<Result> UpdateOrder(OrderForUpdateDto orderDto);
    }
}
