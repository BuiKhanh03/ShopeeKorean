using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Contracts
{
    public interface IPaymentRecordRepository
    {
        public Task CreatePaymentRecord(PaymentRecord paymentRecord);
        public void UpdatePaymentRecord(PaymentRecord paymentRecord);
        public Task<PaymentRecord?> GetPaymentRecord(Guid paymentRecordId, bool trackChanges, string? isInclude = null);
        public Task<IEnumerable<PaymentRecord>> GetPaymentByUserId(Guid userIdi, bool trackChanges, string? isInclude = default);
        
        public Task<PaymentRecord?> GetPaymentRecordByOrder(Guid orderId, bool trackChanges, string? isInclude = default);
    }
}
