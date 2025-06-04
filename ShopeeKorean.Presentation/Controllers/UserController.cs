using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.DataTransferObjects.User;
using Microsoft.AspNetCore.Authorization;

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

    }
}
