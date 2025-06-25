
using Repository;
using ShopeeKorean.Contracts;
using ShopeeKorean.Repository.Contracts;

namespace ShopeeKorean.Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<ICartRepository> _cartRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IProductSizeRepository> _productSizeRepository;
        private readonly Lazy<IProductImageRepository> _productImageRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _cartRepository = new Lazy<ICartRepository>(() => new CartRepository(repositoryContext));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
            _productSizeRepository = new Lazy<IProductSizeRepository>(() => new ProductSizeRepository(repositoryContext));
            _productImageRepository = new Lazy<IProductImageRepository> (() => new ProductImageRepository(repositoryContext));
        }
        //Khởi tạo UserResource
        //UserRepository chỉ được tạo khi bạn gọi RepositoryManager.User
        public IUserRepository UserRepository => _userRepository.Value;
        public ICartRepository CartRepository => _cartRepository.Value;
        public IProductRepository ProductRepository => _productRepository.Value;
        public ICategoryRepository CategoryRepository => _categoryRepository.Value;
        public IProductSizeRepository ProductSizeRepository => _productSizeRepository.Value;
        public IProductImageRepository ProductImageRepository => _productImageRepository.Value;


        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
