using Contracts;
using AutoMapper;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Entities.ConfigurationModels;

namespace ShopeeKorean.Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMailService> _mailService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<ICartService> _cartService;
        private readonly Lazy<IVnPayService> _vnPayService;
        private readonly Lazy<IOrderService> _orderService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<ICartItemService> _cartItemService;
        private readonly Lazy<IOrderItemService> _orderItemService;
        private readonly Lazy<ICloudinaryService> _cloudinaryService;
        private readonly Lazy<IProductSizeService> _productSizeService;
        private readonly Lazy<IProductImageService> _productImageService;
        private readonly Lazy<IPaymentRecordService> _paymentRecordService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, IDataShaperManager dataShaper,UserManager<User> userManager, IOptions<JwtConfiguration> configuration, IOptions<MailConfiguration> mailConfiguration, IOptions<CloudinaryConfiguration> cloudinaryConfiguration, IOptions<VnPayConfiguration> vnPayConfiguration)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                                     new AuthenticationService(loggerManager, mapper, userManager, configuration, repositoryManager));
            _userService = new Lazy<IUserService>(() => new UserService(mapper, loggerManager, repositoryManager));
            _cloudinaryService = new Lazy<ICloudinaryService>(() => new CloudinaryService(cloudinaryConfiguration));
            _mailService = new Lazy<IMailService>(() => new MailService(loggerManager, mailConfiguration, repositoryManager));
            _cartService = new Lazy<ICartService>(() => new CartService(mapper, loggerManager, repositoryManager, dataShaper));
            _orderService = new Lazy<IOrderService>(() => new OrderService(mapper, loggerManager, repositoryManager, dataShaper));
            _productService = new Lazy<IProductService> (() => new ProductService(mapper, loggerManager, repositoryManager, dataShaper));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(mapper, loggerManager, repositoryManager, dataShaper));
            _cartItemService = new Lazy<ICartItemService>(() => new CartItemService(mapper, loggerManager, repositoryManager, dataShaper));
            _orderItemService = new Lazy<IOrderItemService>(() => new OrderItemService(mapper, loggerManager, repositoryManager, dataShaper));
            _vnPayService = new Lazy<IVnPayService>(() => new VnPayService(mapper, loggerManager, vnPayConfiguration, repositoryManager));
            _productSizeService = new Lazy<IProductSizeService>(() => new ProductSizeService(mapper, loggerManager, repositoryManager, dataShaper));
            _productImageService = new Lazy<IProductImageService>(() => new ProductImageService(mapper, loggerManager, repositoryManager, dataShaper));
            _paymentRecordService = new Lazy<IPaymentRecordService>(() => new PaymentRecordService(mapper, loggerManager, repositoryManager, dataShaper));
        }
        public IMailService MailService => _mailService.Value;
        public IUserService UserService => _userService.Value;
        public ICartService CartService => _cartService.Value;
        public IOrderService OrderService => _orderService.Value;
        public IVnPayService VnPayService => _vnPayService.Value;
        public IProductService ProductService => _productService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public ICartItemService CartItemService => _cartItemService.Value;
        public IOrderItemService OrderItemService => _orderItemService.Value;
        public ICloudinaryService CloudinaryService => _cloudinaryService.Value;
        public IProductSizeService ProductSizeService => _productSizeService.Value;
        public IProductImageService ProductImageService => _productImageService.Value;
        public IPaymentRecordService PaymentRecordService => _paymentRecordService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

    }
}
