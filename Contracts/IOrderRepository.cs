using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.RequestFeatures;

namespace ShopeeKorean.Repository.Contracts
{
    public interface IOrderRepository
    {
        public void UpdateOrder(Order order);
        public Task CreateOrder(Order order);
        public Task<Order?> GetOrder(Guid orderId, bool trackChanges, string? include);
        public Task<PagedList<Order>> GetOrders(Guid userId, OrderParameters orderParameters, bool trackChanges, string? include);
    }
}
