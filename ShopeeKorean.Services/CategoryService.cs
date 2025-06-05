using AutoMapper;
using Contracts;
using ShopeeKorean.Contracts;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.DataTransferObjects.Category;
using ShopeeKorean.Shared.RequestFeatures;
using System.Dynamic;
using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Shared.Constant.Category;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.Extension;

namespace ShopeeKorean.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IDataShaperManager _dataShaper;
        private readonly IRepositoryManager _repositoryManager;
        public CategoryService(IMapper mapper, ILoggerManager loggerManager, IRepositoryManager repositoryManager, IDataShaperManager dataShaper)
        {
            _mapper = mapper;
            _dataShaper = dataShaper;
            _loggerManager = loggerManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<Result<IEnumerable<ExpandoObject>>> GetCategories(CategoryParameters categoryParameters, bool trackChanges = false, string? isInclude = null)
        {
            var categoriesWithMetaData = await _repositoryManager.CategoryRepository.GetCategories(categoryParameters, trackChanges, isInclude);
            var categoriestDto = _mapper.Map<IEnumerable<CategoryDto>>(categoriesWithMetaData);
            var categoriesShaped = _dataShaper.Category.ShapeData(categoriestDto, categoryParameters.Field);
            return Result<IEnumerable<ExpandoObject>>.Ok(categoriesShaped, categoriesWithMetaData.MetaData);
        }

        public async Task<Result<CategoryDto>> GetCategory(Guid categoryId, bool trackChanges = false, string? isInclude = null)
        {
           var resultCheck = await this.GetAndCheckCateegory(categoryId, trackChanges, isInclude);
            if (!resultCheck.IsSuccess) return Result<CategoryDto>.BadRequest(resultCheck.Errors!);
            var categoryEntity = resultCheck.GetValue<Category>();
            var categoryDto = _mapper.Map<CategoryDto>(categoryEntity);
            return Result<CategoryDto>.Ok(categoryDto);
        }

        private async Task<Result<Category>> GetAndCheckCateegory(Guid categoryId, bool trackChanges = false, string? isInclude = default)
        {
            var category = await _repositoryManager.CategoryRepository.GetCategory(categoryId, trackChanges, isInclude);
            if (category == null) return Result<Category>.NotFound([CategoryErrors.GetCategoryNotFoundWithIdError(categoryId)]);
            return Result<Category>.Ok(category);
        }
    }
}
