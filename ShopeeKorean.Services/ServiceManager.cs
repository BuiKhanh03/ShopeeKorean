using Contracts;
using AutoMapper;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Service.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ShopeeKorean.Entities.ConfigurationModels;

namespace ShopeeKorean.Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, UserManager<User> userManager, IOptions<JwtConfiguration> configuration)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                                     new AuthenticationService(loggerManager, mapper, userManager, configuration));
        }
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

    }
}
