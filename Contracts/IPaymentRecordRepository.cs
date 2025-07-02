using ShopeeKorean.Entities.Models;

namespace ShopeeKorean.Repository.Contracts
{
    public interface IPaymentRecordRepository
    {
        public Task CreatePaymentRecord(PaymentRecord paymentRecord);
    }
}
