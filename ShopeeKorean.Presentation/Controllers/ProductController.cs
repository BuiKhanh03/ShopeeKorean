using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.RequestFeatures;
using ShopeeKorean.Shared.DataTransferObjects.Product;

namespace ShopeeKorean.Presentation.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ApiControllerBase
    {
        public ProductController(IServiceManager serviceManager) : base(serviceManager)
        {
            
        }

        [HttpGet("{productId:guid}")]
        public async Task<IActionResult> GetProduct(Guid productId) {
            var isInclude = "Category, Seller";
            var productResult = await _service.ProductService.GetProduct(productId, trackChanges: false, isInclude);
            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParameters productParameters)
        {
            var isInclude = "Category, Seller";
            var productResult = await _service.ProductService.GetProducts(productParameters, trackChanges: false, isInclude);
            return productResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDtoForCreation productDto)
        {
            var userId = HttpContext.User.FindFirstValue("UserId");
            var createdProductResult = await _service.ProductService.CreateProduct(productDto, new Guid(userId!));
            return createdProductResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

        [HttpPut("{productId:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid productId,[FromBody] ProductDtoForUpdate productDto)
        {
            var updatedProductResult = await _service.ProductService.UpdateProduct(productId, productDto);
            return updatedProductResult.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }

    }
}
