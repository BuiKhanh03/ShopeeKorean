using ShopeeKorean.Shared.ResultModel;
using System.Dynamic;
using ShopeeKorean.Shared.RequestFeatures;
using ShopeeKorean.Shared.DataTransferObjects.Category;

namespace ShopeeKorean.Service.Contracts
{
    public interface ICategoryService
    {
        public Task<Result<CategoryDto>> GetCategory(Guid categoryId, bool trackChanges = false, string? isInclude = default);
        public Task<Result<IEnumerable<ExpandoObject>>> GetCategories(CategoryParameters categoryParameters, bool trackChanges = false, string? isInclude = default);
    }
}
