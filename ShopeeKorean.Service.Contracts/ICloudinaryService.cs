using Microsoft.AspNetCore.Http;
using ShopeeKorean.Shared.ResultModel;

namespace ShopeeKorean.Service.Contracts
{
    public interface ICloudinaryService
    {
        Task<Result<(string? publicId, string? absoluteUrl)>> UploadUserImageAsync(IFormFile file);
        Task<Result<(string? publicId, string? absoluteUrl)>> UploadProductImageAsync(IFormFile file);
        public Task<Result<string>> RemoveImage(string publicId);
    }
}
