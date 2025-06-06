using Microsoft.AspNetCore.Http;

namespace ShopeeKorean.Shared.DataTransferObjects.Image
{
    public class UpdateUserImageDto
    {
        public IFormFile File { get; set; }
    }
}
