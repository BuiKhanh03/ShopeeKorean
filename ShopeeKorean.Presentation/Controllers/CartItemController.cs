using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.DataTransferObjects.CartItemDto;
using System.Security.Claims;

namespace ShopeeKorean.Presentation.Controllers
{
    [Controller]
    [Route("api/cartitem")]
    public class CartItemController : ApiControllerBase
    {
        public CartItemController(IServiceManager service) : base(service)
        {

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCartItem(CartItemForCreationDto cartItemDto)
        {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var cartItemResult = await _service.CartItemService.CreateCartItem(cartItemDto, new Guid(userId!), trackChanges: false, include: null);
            return cartItemResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [Authorize]
        [HttpPut("{cartItemId:guid}")]
        public async Task<IActionResult> UpdateCartItem(Guid cartItemId, CartItemForUpdateDto cartItemDto)
        {
            var cartItemResult = await _service.CartItemService.UpdateCartItem(cartItemDto, cartItemId, trackChanges: true, include: null);
            return cartItemResult.Map(
               onSuccess: Ok,
               onFailure: ProcessError
               );
        }
        [Authorize]
        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> DeleteCartItem(Guid cartItemId)
        {
            var cartItemResult = await _service.CartItemService.DeleteCartItem(cartItemId, trackChanges: false);
            return cartItemResult.Map(
             onSuccess: Ok,
             onFailure: ProcessError
             );
        }
    }
}
