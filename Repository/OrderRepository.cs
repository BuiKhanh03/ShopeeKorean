using Repository;
using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using ShopeeKorean.Repository.Contracts;
using ShopeeKorean.Shared.RequestFeatures;
using ShopeeKorean.Repository.Extensions.Utility;

namespace ShopeeKorean.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public async Task CreateOrder(Order order)
        => await base.CreateAsync(order);
        public async Task<Order?> GetOrder(Guid orderId, bool trackChanges, string? include)
        {
            return await base.FindByCondition(o => o.Id.Equals(orderId), trackChanges).SingleOrDefaultAsync();
        }

            
        

        public async Task<PagedList<Order>> GetOrders(Guid userId, OrderParameters orderParameters, bool trackChanges, string? include)
        {
            var orders = await FindByCondition(o => o.UserId.Equals(userId), trackChanges)
                                                  .SearchByTotalAmount(orderParameters.TotalAmount)
                                                  .SearchByShippingFee(orderParameters.ShippingFee)
                                                  .SearchByStatus(orderParameters.Status)
                                                  .SearchByCreateAt(orderParameters.CreateAt)
                                                  .SearchByUpdatedAt(orderParameters.UpdateAt)
                                                  .IsInclude(include)
                                                  .ToListAsync();
            return PagedList<Order>.ToPagedList(
                orders,
                orderParameters.PageNumber,
                orderParameters.PageSize
                );
                                                  
        }

        public void UpdateOrder(Order order)
        {
            base.Update(order);
        }
    }
}
