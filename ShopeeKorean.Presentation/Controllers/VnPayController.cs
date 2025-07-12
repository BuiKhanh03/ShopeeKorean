using Microsoft.AspNetCore.Mvc;
using ShopeeKorean.Service.Contracts;
using Microsoft.AspNetCore.Cors;
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
        [EnableCors("AllowAllOrigins")]
        public IActionResult CreatePaymentUrl(VnPayForCreationDto model)
        {
            var vnpayUrl = _service.VnPayService.CreatePaymentUrl(model, HttpContext);

            return Ok(new { url = vnpayUrl });
        }
        [HttpGet("payment-callback")]
        [EnableCors("AllowAllOrigins")]
        public async Task<IActionResult> PaymentCallback()
        {
            var response = _service.VnPayService.PaymentExecute(Request.Query);
            if (!response.IsSuccess || response.VnPayResponseCode != "00")
                return BadRequest("Thanh toán thất bại");

            var result = await _service.PaymentRecordService.SaveVnPayPament(response);
            if (!result.IsSuccess)
                return BadRequest(result.Errors);
            return new JsonResult(response);
        }
    }
}
