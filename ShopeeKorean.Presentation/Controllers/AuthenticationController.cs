using Microsoft.AspNetCore.Mvc;
using ShopeeKorean.Shared.Extension;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Presentation.ActionFilters;
using ShopeeKorean.Shared.DataTransferObjects.User;

namespace ShopeeKorean.Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager service) => _service = service;

        [HttpPost("register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Registeruser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            var resultUrl = await _service.AuthenticationService.CreateConfirmEmailUrl(userForRegistration.Email);
            var url = resultUrl.GetValue<string>();
            await _service.MailService.SendConfirmEmail(userForRegistration.Email, url);
            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if(!await _service.AuthenticationService.ValidateUser(user)) return Unauthorized();

            var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);
            return Ok(tokenDto);
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromBody] UserForConfirmGmailDto user)
        {
            var result = await _service.AuthenticationService.ConfirmEmail(user);
            return StatusCode(201);
        }
    }
}
