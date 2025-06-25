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
    [Route("api/cart")]
    public class CartController : ApiControllerBase
    {
        public CartController(IServiceManager service) : base(service)
        {

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCart() {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var cartResult = await _service.CartService.GetCart(new Guid(userId!), trackChanges: false, null);
            return cartResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
