using ShopeeKorean.Shared.ErrorModel;

namespace ShopeeKorean.Shared.Constant.Category
{
    public class CategoryErrors
    {
        public const string CategoryNotFound = "The category with id {0} is not found";

        public static ErrorsResult GetCategoryNotFoundWithIdError(Guid id) 
            => new () { Code = nameof(CategoryNotFound), Description = string.Format(CategoryNotFound, id) };
    }
}
