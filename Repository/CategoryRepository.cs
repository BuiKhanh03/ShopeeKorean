using Repository;
using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using ShopeeKorean.Repository.Contracts;
using ShopeeKorean.Shared.RequestFeatures;
using ShopeeKorean.Repository.Extensions.Utility;

namespace ShopeeKorean.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
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

        public async Task<Category?> GetCategory(Guid categoryId, bool trackChanges = false, string? include = null)
        {
            return await FindByCondition(c => c.Id.Equals(categoryId), trackChanges).IsInclude(include).SingleOrDefaultAsync();
        }
    }
}
