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
    }
}
