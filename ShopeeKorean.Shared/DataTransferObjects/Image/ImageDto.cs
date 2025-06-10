using Microsoft.AspNetCore.Http;

namespace ShopeeKorean.Shared.DataTransferObjects.Image
{
    public class ImageDto
    {
        public IFormFile File { get; set; }
    }
}
