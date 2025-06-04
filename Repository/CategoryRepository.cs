using Microsoft.EntityFrameworkCore;
using Repository;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Repository.Contracts;
using ShopeeKorean.Repository.Extensions.Utility;
using ShopeeKorean.Shared.RequestFeatures;

namespace ShopeeKorean.Repository
{
    public class CategoryRepository : RepositoryBase<Category> ,ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        
        public async Task<PagedList<Category>> GetCategories(CategoryParameters categoryParameters, bool trackChanges = false, string? include = null)
        {
            var categoryQuerys = await FindAll(trackChanges)
                                       .SearchByName(categoryParameters.Name)
                                       .IsInclude(include)
                                       .ToListAsync();
            return PagedList<Category>.ToPagedList(
                categoryQuerys,
                categoryParameters.PageNumber,
                categoryParameters.PageSize
                );
        }

        public Task<Category?> GetCategory(Guid categoryId, bool trackChanges = false, string? include = null)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<Category>> GetCategoryByUser(Guid userId, bool trackChanges = false, string? include = null)
        {
            throw new NotImplementedException();
        }
    }
}
