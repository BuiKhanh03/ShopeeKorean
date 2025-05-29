using Microsoft.AspNetCore.Mvc;
using ShopeeKorean.Presentation.ActionFilters;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.DataTransferObjects.User;
namespace ShopeeKorean.Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _service;

        public TokenController(IServiceManager service) => _service = service;

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Refresh([FromBody]UserTokenDto tokenDto)
        {
            var tokenDtoReturn = await _service.AuthenticationService
                .RefreshToken(tokenDto);
            return Ok(tokenDtoReturn);
        }

    }
}
