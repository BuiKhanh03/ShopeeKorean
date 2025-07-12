using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.DataTransferObjects.Review;
using System.Security.Claims;

namespace ShopeeKorean.Presentation.Controllers
{
    [Route("api/review")]
    public class ReviewController : ApiControllerBase
    {
        public ReviewController(IServiceManager service) : base(service)
        {

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody]ReviewForCreationDto cartItemDto)
        {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var cartItemResult = await _service.ReviewService.CreateReview(cartItemDto, new Guid(userId!), trackChanges: false, include: null);
            return cartItemResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [Authorize]
        [HttpPut("{reviewId:guid}")]
        public async Task<IActionResult> UpdateReview(Guid reviewId, [FromBody] ReviewForUpdateDto cartItemDto)
        {
            var cartItemResult = await _service.ReviewService.UpdateReview(cartItemDto, reviewId, trackChanges: true, include: null);
            return cartItemResult.Map(
               onSuccess: Ok,
               onFailure: ProcessError
               );
        }
        [Authorize]
        [HttpDelete("{reviewId:guid}")]
        public async Task<IActionResult> DeleteReview(Guid reviewId)
        {
            var cartItemResult = await _service.ReviewService.DeleteReview(reviewId, trackChanges: false);
            return cartItemResult.Map(
             onSuccess: Ok,
             onFailure: ProcessError
             );
        }
    }
}
