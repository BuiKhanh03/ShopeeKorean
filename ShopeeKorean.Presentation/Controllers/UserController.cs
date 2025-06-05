using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.DataTransferObjects.User;
using Microsoft.AspNetCore.Authorization;
using ShopeeKorean.Shared.Extension;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ShopeeKorean.Presentation.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/user")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        public UserController(IServiceManager service) : base(service)
        {
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {
            //HttpContext User đại diện cho người dùng hiện tại
            var userId = HttpContext.User.FindFirstValue("UserId");
            var includes = "Roles";
            var user = await _service.UserService.GetUserAsync(new Guid(userId!), trackChanges: false, includes);
            return Ok(user);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UserForUpdateDto user)
        {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var resultUpdated = await _service.UserService.UpdateUser(new Guid(userId!), user, trackChanes: true);
            return resultUpdated.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
                );
        }

        [HttpPost("/image")]
        [Authorize]
        public async Task<IActionResult> UpdateUserImage([FromForm] IFormFile fileDto)
        {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var uploadFileResult = await _service.CloudinaryService.UploadUserImageAsync(fileDto);
            if (!uploadFileResult.IsSuccess)
                return ProcessError(uploadFileResult);
            var imageEntity = uploadFileResult.GetValue<(string? publicId, string? absoluteUrl)>();
            var updateResult = await _service.UserService.UpdateUserImage(new Guid(userId!), trackChanges: true, imageEntity.publicId!, imageEntity.absoluteUrl!);
            var newValue = updateResult.GetValue<(string? oldId, string? newImage)> ();
            if (!string.IsNullOrEmpty(newValue.oldId)) await _service.CloudinaryService.RemoveImage(newValue.oldId);
            return updateResult.Map(
                 onSuccess: _ => Ok(newValue.newImage),
                 onFailure: ProcessError
                );
        }

    }
}
