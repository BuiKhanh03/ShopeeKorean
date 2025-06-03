using ShopeeKorean.Shared.ErrorModel;

namespace ShopeeKorean.Shared.Constant.Authentication
{
    public static class UserErrors
    {
        //Email errors 
        public const string EmailNotFound = "The email {0} is not found";

        public const string UserNotFound = "The user not found with id {0}";

        public static ErrorsResult GetUserNotFoundWithEmailError(string email)
        {
            return new()
            {
                Code = nameof(EmailNotFound),
                Description = string.Format(EmailNotFound, email)
            };
        }

        public static ErrorsResult GetUserNotFoundWithIdError(Guid id)
        {
            return new()
            { Code = nameof(UserNotFound), Description = string.Format(UserNotFound, id) };
        }
    }
}
