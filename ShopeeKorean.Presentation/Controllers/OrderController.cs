using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopeeKorean.Service.Contracts;
namespace ShopeeKorean.Presentation.Controllers;
using ShopeeKorean.Shared.DataTransferObjects.Order;

    [ApiController]
    [Route("api/order")]
    public class OrderController : ApiControllerBase
    {
        public OrderController(IServiceManager serviceManager) : base(serviceManager)
        {

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderForCreationDto orderDto)
        {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var productResult = await _service.OrderService.CreateOrder(orderDto, new Guid(userId!));
            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }

