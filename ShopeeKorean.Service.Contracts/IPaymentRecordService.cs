using ShopeeKorean.Shared.DataTransferObjects.PaymentRecord;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Service.Contracts
{
    public interface IPaymentRecordService
    {
        public Task<Result<PaymentRecordDto>> CreatePaymentRecord(PaymentRecordForCreationDto paymentRecordForCreationDto);
    }
}
