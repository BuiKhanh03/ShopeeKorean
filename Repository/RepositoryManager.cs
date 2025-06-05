
using Repository;
using ShopeeKorean.Contracts;
using ShopeeKorean.Repository.Contracts;

namespace ShopeeKorean.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
        }
        //Khởi tạo UserResource
        //UserRepository chỉ được tạo khi bạn gọi RepositoryManager.User
        public IUserRepository UserRepository => _userRepository.Value;
        public ICategoryRepository CategoryRepository => _categoryRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
