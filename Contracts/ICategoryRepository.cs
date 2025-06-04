using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.RequestFeatures;

namespace ShopeeKorean.Repository.Contracts
{
    public interface ICategoryRepository
    {
        public Task<Category?> GetCategory(Guid categoryId, bool trackChanges = false, string? include = default);
        public Task<PagedList<Category>> GetCategoryByUser(Guid userId, bool trackChanges = false, string? include = default);
        public Task<PagedList<Category>> GetCategories(CategoryParameters categoryParameters, bool trackChanges = false, string? include = default);
    }
}
