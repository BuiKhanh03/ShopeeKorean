using ShopeeKorean.Shared.DataTransferObjects.PaymentRecord;
using ShopeeKorean.Shared.DataTransferObjects.VnPay;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Service.Contracts
{
    public interface IPaymentRecordService
    {
        public Task<Result<PaymentRecordDto>> CreatePaymentRecord(PaymentRecordForCreationDto paymentRecordForCreationDto);
        public Task<Result<PaymentRecordDto>> SaveVnPayPament(VnPayDto vnPayDto);
    }
}
