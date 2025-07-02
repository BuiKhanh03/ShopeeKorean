
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
        private readonly Lazy<IOrderRepository> _orderRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IShippingRepository> _shippingRepository;
        private readonly Lazy<ICartItemRepository> _cartItemRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IOrderItemRepository> _orderItemRepository;
        private readonly Lazy<IPaymentRecordRepository> _paymentRepository;
        private readonly Lazy<IProductSizeRepository> _productSizeRepository;
        private readonly Lazy<IProductImageRepository> _productImageRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _cartRepository = new Lazy<ICartRepository>(() => new CartRepository(repositoryContext));
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(repositoryContext));
            _cartItemRepository = new Lazy<ICartItemRepository>(() => new CartItemRepository(repositoryContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
            _shippingRepository = new Lazy<IShippingRepository>(() => new ShippingRepository(repositoryContext));
            _orderItemRepository = new Lazy<IOrderItemRepository>(() => new OrderItemRepository(repositoryContext));
            _paymentRepository = new Lazy<IPaymentRecordRepository>(() => new PaymentRepository(repositoryContext));
            _productSizeRepository = new Lazy<IProductSizeRepository>(() => new ProductSizeRepository(repositoryContext));
            _productImageRepository = new Lazy<IProductImageRepository> (() => new ProductImageRepository(repositoryContext));
        }
        //Khởi tạo UserResource
        //UserRepository chỉ được tạo khi bạn gọi RepositoryManager.User
        public IUserRepository UserRepository => _userRepository.Value;
        public ICartRepository CartRepository => _cartRepository.Value;
        public IOrderRepository OrderRepository => _orderRepository.Value;
        public IProductRepository ProductRepository => _productRepository.Value;
        public ICartItemRepository CartItemRepository => _cartItemRepository.Value;
        public IShippingRepository ShippingRepository => _shippingRepository.Value;
        public ICategoryRepository CategoryRepository => _categoryRepository.Value;
        public IOrderItemRepository OrderItemRepository => _orderItemRepository.Value;
        public IPaymentRecordRepository PaymentRecordRepository => _paymentRepository.Value;

        public IProductSizeRepository ProductSizeRepository => _productSizeRepository.Value;
        public IProductImageRepository ProductImageRepository => _productImageRepository.Value;


        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
