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
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IMailService> _mailService;
        private readonly Lazy<ICloudinaryService> _cloudinaryService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<ICategoryService> _categoryService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, IDataShaperManager dataShaper,UserManager<User> userManager, IOptions<JwtConfiguration> configuration, IOptions<MailConfiguration> mailConfiguration, IOptions<CloudinaryConfiguration> cloudinaryConfiguration)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                                     new AuthenticationService(loggerManager, mapper, userManager, configuration));
            _mailService = new Lazy<IMailService>(() => new MailService(loggerManager, mailConfiguration, repositoryManager));
            _userService = new Lazy<IUserService>(() => new UserService(mapper, loggerManager, repositoryManager));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(mapper, loggerManager, repositoryManager, dataShaper));
            _cloudinaryService = new Lazy<ICloudinaryService>(() => new CloudinaryService(cloudinaryConfiguration));
        }
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public IMailService MailService => _mailService.Value;

        public IUserService UserService => _userService.Value;

        public ICloudinaryService CloudinaryService => _cloudinaryService.Value;
    }
}
