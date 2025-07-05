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
        public string? PaymentId { get; set; }
        public string? TransactionId { get; set; } 
        public string? PaidAt { get; set; } 
        public PaymentRecordType PaymentRecordMethod { get; set; } = PaymentRecordType.VnPay;
        public PaymentRecordStatus PaymentRecordStatus { get; set; } = PaymentRecordStatus.Pending;
        public Order Order { get; set; }
    }
}
