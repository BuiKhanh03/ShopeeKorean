using Repository;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Repository.Contracts;
using ShopeeKorean.Shared.DataTransferObjects.OrderItem;

namespace ShopeeKorean.Repository
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public async Task CreateOrder(OrderItem orderItem)
       => await CreateAsync(orderItem);
    }
}
