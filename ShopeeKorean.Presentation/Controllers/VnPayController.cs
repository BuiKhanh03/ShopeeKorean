using Microsoft.AspNetCore.Mvc;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.DataTransferObjects.VnPay;

namespace ShopeeKorean.Presentation.Controllers
{
    [Controller]
    [Route("api/vnpay")]
    public class VnPayController : ApiControllerBase
    {
        public VnPayController(IServiceManager service) : base(service)
        {
            
        }
        [HttpPost("create-payment-url")]

        public IActionResult CreatePaymentUrl(VnPayForCreationDto model)
        {
            var url = _service.VnPayService.CreatePaymentUrl(model, HttpContext);

            return Redirect(url);
        }
        [HttpGet("payment-callback")]
        public IActionResult PaymentCallback()
        {
            var response = _service.VnPayService.PaymentExecute(Request.Query);

            return new JsonResult(response);
        }
    }
}
