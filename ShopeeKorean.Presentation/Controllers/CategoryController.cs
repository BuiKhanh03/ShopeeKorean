using Microsoft.AspNetCore.Mvc;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.RequestFeatures;

namespace ShopeeKorean.Presentation.Controllers
{
    [Controller]
    [Route("api/category")]
    public class CategoryController : ApiControllerBase
    {
        public CategoryController(IServiceManager service) : base(service)
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] CategoryParameters categoryParameters)
        {
            var categoryResult = await _service.CategoryService.GetCategories(categoryParameters, trackChanges: false, isInclude: default);
            return categoryResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet("{categoryId:guid}")]
        public async Task<IActionResult> GetCategory(Guid categoryId) {
            var categoryResult = await _service.CategoryService.GetCategory(categoryId, trackChanges: false, isInclude: default);
            return categoryResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
