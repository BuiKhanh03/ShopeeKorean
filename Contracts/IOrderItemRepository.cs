

using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.DataTransferObjects.OrderItem;

namespace ShopeeKorean.Repository.Contracts
{
    public interface IOrderItemRepository
    {
        public Task CreateOrder(OrderItem orderItem);
    }
}
