using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeKorean.Shared.Extension;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.DataTransferObjects.ProductImage;

namespace ShopeeKorean.Presentation.Controllers
{
    [Controller]
    [Route("api/product/image")]
    public class ProductImageController : ApiControllerBase
    {
        public ProductImageController(IServiceManager serviceManager) : base(serviceManager)
        {

        }

        [HttpGet("{productId:guid}")]
        public async Task<IActionResult> GetProductImages(Guid productId) {
            var productImageResult = await _service.ProductImageService.GetProductImages(productId, trackChanges: false);
            return Ok(productImageResult);
        }

        [HttpPut("{productId:guid}/{productImageId:guid}")]
        public async Task<IActionResult> UpdateProductImage(Guid productId, Guid productImageId)
        {
            var productImageResult = await _service.ProductImageService.UpdateProductImage(productId, productImageId);
            return productImageResult.Map(
              onSuccess: Ok,
              onFailure: ProcessError
              );
        }

        [HttpPost("{productId:guid}")]
        public async Task<IActionResult> CreateProductImage(Guid productId, [FromForm] List<IFormFile> imageDtos)
        {
            if (imageDtos == null || !imageDtos.Any()) return BadRequest("File is not added");
            var createdProductImages = new List<object>();
            foreach (var imageDto in imageDtos)
            {
                var uploadFileResult = await _service.CloudinaryService.UploadProductImageAsync(imageDto);
                if (!uploadFileResult.IsSuccess) return ProcessError(uploadFileResult);
                var imgTuple = uploadFileResult.GetValue<(string? publicId, string? absoluteUrl)>();

                var updateResult = await _service.ProductImageService.CreateProductImage(productId, trackChanges: false, imgTuple.publicId!, imgTuple.absoluteUrl!);

                if (!updateResult.IsSuccess) return ProcessError(updateResult);

                createdProductImages.Add(imgTuple.absoluteUrl!);
            }
            return Ok(createdProductImages);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage([FromQuery]string publicId)
        {
            var resultCheck = await _service.ProductImageService.DeleteProductImage(publicId);
            if(!resultCheck.IsSuccess) return ProcessError(resultCheck);

            await _service.CloudinaryService.RemoveImage(publicId);
            return NoContent();
        }
    }
}
