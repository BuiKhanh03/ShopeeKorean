using System.Net;
using Microsoft.AspNetCore.Mvc;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Presentation.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
      /*  public IActionResult ProcessError(ApiBaseResponse baseResponse)
        {
            return baseResponse switch
           {
               ApiNotFoundResponse => NotFound(new ErrorDetails
               {
                   Message = ((ApiNotFoundResponse)baseResponse).Message,
                   StatusCode = StatusCodes.Status404NotFound
               }),
               ApiBadRequestResponse => BadRequest(new ErrorDetails
               {
                   Message = ((ApiBadRequestResponse)baseResponse).Message,
                   StatusCode = StatusCodes.Status400BadRequest
               }),
               _ => throw new NotImplementedException()
           };*/
        protected readonly IServiceManager _service;
        public ApiControllerBase(IServiceManager service)
        {
            _service = service;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public IActionResult ProcessError(Result result)
        {

            return result.StatusCode switch
            {
                HttpStatusCode.NotFound => NotFound(result),
                HttpStatusCode.BadRequest => BadRequest(result),
                HttpStatusCode.Unauthorized => Unauthorized(result),
                HttpStatusCode.Conflict => Conflict(result)
                ,
                _ => throw new NotImplementedException()
            };
        }
    } 
}
