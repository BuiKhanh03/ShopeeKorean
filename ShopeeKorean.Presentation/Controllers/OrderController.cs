using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopeeKorean.Service.Contracts;
namespace ShopeeKorean.Presentation.Controllers;

using Microsoft.AspNetCore.Authorization;
using ShopeeKorean.Shared.DataTransferObjects.Order;
using ShopeeKorean.Shared.RequestFeatures;

[ApiController]
    [Route("api/order")]
    public class OrderController : ApiControllerBase
    {
        public OrderController(IServiceManager serviceManager) : base(serviceManager)
        {

        }

    [Authorize]
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

    [HttpGet]
    public async Task<IActionResult> GetOrder([FromQuery] OrderParameters orderParameters)
    {
        var userId = HttpContext.User.FindFirstValue("UserId");
        var include = "OrderItems,Shipping,PaymentRecord";
        var productResult = await _service.OrderService.GetOrders(new Guid(userId!), orderParameters, trackChanges: false, isInclude: include);
        return productResult.Map(
            onSuccess: Ok,
            onFailure: ProcessError
            );
    }
    }

