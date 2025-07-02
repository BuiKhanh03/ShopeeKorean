using ShopeeKorean.Shared.Enums;
using ShopeeKorean.Shared.Enums.Status;

namespace ShopeeKorean.Entities.Models
{
    public class PaymentRecord : BaseEntity<PaymentRecord>
    {
        public Guid Id { get; set; }
        public string? OrderType { get; set; }
        public decimal Amount { get; set; }
        public string? OrderDescription { get; set; }
        public string? Name { get; set; }
        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
        public PaymentRecordType PaymentRecordMethod { get; set; } = PaymentRecordType.Cod;
        public PaymentRecordStatus PaymentRecordStatus { get; set; } = PaymentRecordStatus.Pending;
        public Order Order { get; set; }
    }
}
