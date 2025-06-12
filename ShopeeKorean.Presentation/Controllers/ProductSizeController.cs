using Microsoft.AspNetCore.Mvc;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.DataTransferObjects.ProductSize;

namespace ShopeeKorean.Presentation.Controllers
{
    [Controller]
    [Route("api/productsize")]
    public class ProductSizeController : ApiControllerBase
    {
        public ProductSizeController(IServiceManager service) : base(service)
        {
            
        }

        [HttpPost("{productId:guid}")]
        public async Task<IActionResult> CreateProductSize(Guid productId, [FromBody] ProductSizeDtoForCreation productSize)
        {
            var resultCreated = await _service.ProductSizeService.CreateProductSize(productId, productSize);
            return resultCreated.Map(
             onSuccess: Ok,
             onFailure: ProcessError
             );
        }

        [HttpPut("{productSizeId:guid}")]
        public async Task<IActionResult> UpdateProductSize(Guid productSizeId, [FromBody] ProductSizeDtoForUpdate productSize)
        {
            var resultUpdated = await _service.ProductSizeService.UpdateProductSize(productSizeId, productSize);
            return resultUpdated.Map(
                onSuccess: Ok,
                onFailure: ProcessError
                );
        }
    }
}
