using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.DataTransferObjects.User;

namespace ShopeeKorean.Presentation.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/user")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        private readonly IServiceManager _serivce;
        public UserController(IServiceManager service) : base(service)
        {
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetUser()
        {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var includes = "Roles";
            var user = await _serivce.UserService.GetUserAsync(new Guid(userId!), trackChanges: false, includes);
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UserForUpdateDto user)
        {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var resultUpdated = await _serivce.UserService.UpdateUser(new Guid(userId!), user, trackChanes: true);
            return resultUpdated.Map(
                onSuccess: _ => NoContent(),
                onFailure: ProcessError
                );
        }

    }
}
