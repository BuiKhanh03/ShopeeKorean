using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopeeKorean.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeKorean.Presentation.Controllers
{
    [Controller]
    [Route(template: "api/payment")]
    public class PaymentController : ApiControllerBase
    {
        public PaymentController(IServiceManager service) : base(service)
        {

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {
            //HttpContext User đại diện cho người dùng hiện tại
            var userId = HttpContext.User.FindFirstValue("UserId");
            var user = await _service.PaymentRecordService.GetPaymentByUser(new Guid(userId!), trackChanges: false, null);
            return Ok(user);
        }


    }
}
