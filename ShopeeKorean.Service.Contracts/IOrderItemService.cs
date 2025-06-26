using ShopeeKorean.Shared.DataTransferObjects.OrderItem;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Service.Contracts
{
    public interface IOrderItemService
    {
        public Task<Result<OrderItemDto>> CreateOrder(OrderItemForCreationDto orderItem, bool trackChanges, string? isInclude = default);
    }
}
