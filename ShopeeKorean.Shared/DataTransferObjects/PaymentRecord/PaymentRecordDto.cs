using ShopeeKorean.Shared.Enums.Status;
using ShopeeKorean.Shared.Enums;

namespace ShopeeKorean.Shared.DataTransferObjects.PaymentRecord
{
    public class PaymentRecordDto
    {
        public Guid Id { get; set; }
        public PaymentRecordType PaymentRecordMethod { get; set; } = PaymentRecordType.Cod;
        public decimal AmountPaid { get; set; }
        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
        public PaymentRecordStatus PaymentRecordStatus { get; set; } = PaymentRecordStatus.Pending;
    }
}
