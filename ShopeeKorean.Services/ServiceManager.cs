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
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<ICloudinaryService> _cloudinaryService;
        private readonly Lazy<IProductImageService> _productImageService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, IDataShaperManager dataShaper,UserManager<User> userManager, IOptions<JwtConfiguration> configuration, IOptions<MailConfiguration> mailConfiguration, IOptions<CloudinaryConfiguration> cloudinaryConfiguration)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                                     new AuthenticationService(loggerManager, mapper, userManager, configuration));
            _productService = new Lazy<IProductService> (() => new ProductService(mapper, loggerManager, repositoryManager, dataShaper));
            _mailService = new Lazy<IMailService>(() => new MailService(loggerManager, mailConfiguration, repositoryManager));
            _userService = new Lazy<IUserService>(() => new UserService(mapper, loggerManager, repositoryManager));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(mapper, loggerManager, repositoryManager, dataShaper));
            _cloudinaryService = new Lazy<ICloudinaryService>(() => new CloudinaryService(cloudinaryConfiguration));
            _productImageService = new Lazy<IProductImageService>(() => new ProductImageService(mapper, loggerManager, repositoryManager, dataShaper));
        }
        public IMailService MailService => _mailService.Value;
        public IUserService UserService => _userService.Value;
        public IProductService ProductService => _productService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public ICloudinaryService CloudinaryService => _cloudinaryService.Value;
        public IProductImageService ProductImageService => _productImageService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

    }
}
