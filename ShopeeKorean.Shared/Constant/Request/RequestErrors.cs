using ShopeeKorean.Shared.ErrorModel;

namespace ShopeeKorean.Shared.Constant.Request
{
    public class RequestErrors
    {
        #region Error Message
        public const string FileNotFound = "No file uploaded.";
        public const string FileTooLarge = "File size exceeds the maximum limit (10MB).";
        public const string FileExtensionInvalid = "Invalid file extension.";
        public const string FileTypeInvalid = "Invalid file type.";
        #endregion

        #region Static Method
        public static ErrorsResult GetFileNotFoundErrors()
        {
            return new ErrorsResult
            {
                Code = nameof(FileNotFound),
                Description = FileNotFound
            };
        }

        public static ErrorsResult GetFileTooLargeErrors()
        {
            return new ErrorsResult
            {
                Code = nameof(FileTooLarge),
                Description = FileTooLarge
            };
        }

        public static ErrorsResult GetFileExtensionInvalidErrors()
        {
            return new ErrorsResult
            {
                Code = nameof(FileExtensionInvalid),
                Description = FileExtensionInvalid
            };
        }

        public static ErrorsResult GetFileTypeInvalidErrors()
        {
            return new ErrorsResult
            {
                Code = nameof(FileTypeInvalid),
                Description = FileTypeInvalid
            };
        }
        #endregion

    }
}
