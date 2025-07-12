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

        public async Task<IEnumerable<PaymentRecord>> GetPaymentByUserId(Guid userIdi, bool trackChanges, string? isInclude = null)
        {
            var paymentRecord = await FindByCondition(p => p.Order.UserId == userIdi, trackChanges).ToListAsync();
            return paymentRecord;
        }

        public async Task<PaymentRecord?> GetPaymentRecord(Guid paymentRecordId, bool trackChanges, string? isInclude = null)
        {
            var paymentRecord = await FindByCondition(p => p.Id.Equals(paymentRecordId), trackChanges).SingleOrDefaultAsync();
            return paymentRecord;
        }

        public async Task<PaymentRecord?> GetPaymentRecordByOrder(Guid orderId, bool trackChanges, string? isInclude = null)
        {
            var paymentRecord = await FindAll(trackChanges)
                .Include(p => p.Order)
                .Where(p => p.Order.Id.Equals(orderId)).SingleOrDefaultAsync();
            return paymentRecord;
        }

        public void UpdatePaymentRecord(PaymentRecord paymentRecord)
        {
            Update(paymentRecord);
        }
    }
}
