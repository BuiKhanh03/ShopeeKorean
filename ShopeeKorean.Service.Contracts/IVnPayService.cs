using Microsoft.AspNetCore.Http;
using ShopeeKorean.Shared.DataTransferObjects.VnPay;

namespace ShopeeKorean.Service.Contracts
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(VnPayForCreationDto model, HttpContext context);
        VnPayDto PaymentExecute(IQueryCollection collections);
    }
}
