using Microsoft.EntityFrameworkCore;
using Repository;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Entities.Responses;
using ShopeeKorean.Repository.Contracts;

namespace ShopeeKorean.Repository
{
    public class PaymentRepository : RepositoryBase<PaymentRecord>, IPaymentRecordRepository
    {
        public PaymentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public async Task CreatePaymentRecord(PaymentRecord paymentRecord)
          => await CreateAsync(paymentRecord);

        public async Task<PaymentRecord?> GetPaymentRecordByOrder(Guid orderId, bool trackChanges, string? isInclude = null)
        {
            var paymentRecord = await FindByCondition(p => p.Order.Id.Equals(orderId), trackChanges).SingleOrDefaultAsync();
            return paymentRecord;
        }

        public void UpdatePaymentRecord(PaymentRecord paymentRecord)
        {
            Update(paymentRecord);
        }
    }
}
