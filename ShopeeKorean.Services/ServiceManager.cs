using Contracts;
using AutoMapper;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Service.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ShopeeKorean.Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                                     new AuthenticationService(loggerManager, mapper, userManager, configuration));
        }
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

    }
}
