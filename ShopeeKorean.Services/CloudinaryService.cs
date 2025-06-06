using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.Constant.Request;
using ShopeeKorean.Shared.ResultModel;
using System.Net;

namespace ShopeeKorean.Service
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        private readonly ShopeeKorean.Entities.ConfigurationModels.CloudinaryConfiguration _configuration;
        private readonly long _maxFileSize = 10 * 1024 * 1024; //10MB

        private static readonly string[] _permittedExtensions = { ".jpg", ".jpeg", ".png" };
        private static readonly string[] _permittedmimeTypes = { "image/jpg", "image/jpeg", "image/png" };

        private const string _userFolder = "User";
        private const string _errorCode = "CloudiaryError";

        public CloudinaryService(IOptions<ShopeeKorean.Entities.ConfigurationModels.CloudinaryConfiguration> configuration)
        {
            _configuration = configuration.Value;
            var account = new Account(
                _configuration.CloudName,
                _configuration.ApiKey,
                _configuration.ApiSecret
                );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<Result<(string? publicId, string? absoluteUrl)>> UploadUserImageAsync(IFormFile file)
         => await UploadImageAsync(file, _userFolder);
        private async Task<Result<(string? publicId, string? absoluteUrl)>> UploadImageAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0) return Result<(string? publicId, string? absolutedId)>.BadRequest([RequestErrors.GetFileNotFoundErrors()]);
            if(file.Length > _maxFileSize) return Result<(string? publicId, string? absolutedId)>.BadRequest(RequestErrors.GetFileTooLargeErrors());
            //Trích xuất phần mở rộng (extension) của tên tệp. Ví dụ: với "avatar.png" → trả về ".png".
            //.ToLowerInvariant()	Chuyển phần mở rộng về chữ thường một cách nhất quán theo chuẩn invariant culture (đảm bảo không phụ thuộc ngôn ngữ/locale).
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if(string.IsNullOrEmpty(extension) || !_permittedExtensions.Contains(extension)) return Result<(string? publicId, string? absolutedId)>.BadRequest([ RequestErrors.GetFileTypeInvalidErrors()]);

            if (!_permittedmimeTypes.Contains(file.ContentType.ToLowerInvariant())) return Result<(string? publicId, string? absoluteUrl)>.BadRequest([RequestErrors.GetFileTypeInvalidErrors()]);
            //Mở file dưới dạng Stream để đọc dữ liệu. Không tải toàn bộ vào bộ nhớ, mà đọc theo luồng.
            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                //Truyền ảnh cần upload, gồm tên file và stream dữ liệu (được lấy từ file.OpenReadStream()).
                File = new FileDescription(file.FileName, stream),
                //Cloudinary sẽ tự động tạo tên file duy nhất (ví dụ: ab12c3_photo.jpg) để tránh trùng lặp.
                UniqueFilename = true,
                AssetFolder = folderName,
                //Dùng đường dẫn thư mục làm tiền tố cho public_id, giúp quản lý file rõ ràng hơn.
                UseAssetFolderAsPublicIdPrefix = true,
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            if (uploadResult.StatusCode == HttpStatusCode.OK)
            {
                return Result<(string? publicId, string? absoluteUrl)>.Ok((publicId: uploadResult.PublicId, absoluteUrl: uploadResult.SecureUrl.AbsoluteUri));
            }

            return Result<(string? publicId, string? absoluteUrl)>.Failure(uploadResult.StatusCode, [new()
            {
                Code = _errorCode,
                Description = uploadResult.Error.Message
            }]);
        }

        public async Task<Result<string>> RemoveImage(string publicId)
        {
            var deletionParam = new DeletionParams(publicId)
            {
                ResourceType = ResourceType.Image,
            };

            var result = await _cloudinary.DestroyAsync(deletionParam);

            if (result.Error != null)
                return Result<string>.Failure(result.StatusCode, [new()
                {
                    Code = _errorCode,
                    Description = result.Error.Message
                }]);
            return Result<string>.Ok(result.Result);
        }
    }
}
