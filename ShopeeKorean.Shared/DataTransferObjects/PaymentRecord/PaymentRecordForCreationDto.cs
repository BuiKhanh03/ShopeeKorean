using ShopeeKorean.Shared.Enums.Status;
using ShopeeKorean.Shared.Enums;

namespace ShopeeKorean.Shared.DataTransferObjects.PaymentRecord
{
    public class PaymentRecordForCreationDto
    {
        public PaymentRecordType PaymentRecordMethod { get; set; } = PaymentRecordType.Momo;
    }
}
