using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Contracts
{
    public interface IPaymentRecordRepository
    {
        public Task CreatePaymentRecord(PaymentRecord paymentRecord);
        public void UpdatePaymentRecord(PaymentRecord paymentRecord);
        public Task<PaymentRecord?> GetPaymentRecordByOrder(Guid orderId, bool trackChanges, string? isInclude = default);
    }
}
