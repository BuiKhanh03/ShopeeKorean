using ShopeeKorean.Shared.Enums;
using ShopeeKorean.Shared.Enums.Status;

namespace ShopeeKorean.Entities.Models
{
    public class PaymentRecord : BaseEntity<PaymentRecord>
    {
        public Guid Id { get; set; }
        public PaymentRecordType PaymentRecordMethod { get; set; } = PaymentRecordType.Cod;
        public decimal AmountPaid { get; set; }
        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
        public PaymentRecordStatus PaymentRecordStatus { get; set; } = PaymentRecordStatus.Pending;
        public Order Order { get; set; }
    }
}
