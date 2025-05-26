using Contracts;
using Repository;
using LoggerService;
using ShopeeKorean.Service;
using ShopeeKorean.Contracts;
using ShopeeKorean.Repository;
using Microsoft.EntityFrameworkCore;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;

namespace ShopeeKorean.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }
        public static void ConfigureIISIntegration(this IServiceCollection services)
        => services.Configure<IISOptions>(options => { });

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<RepositoryContext>(otps => otps.UseSqlServer(configuration.GetConnectionString("sqlConnection"), otps =>
        {
            otps.EnableRetryOnFailure();
        }));

        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, Roles>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = true;
                o.Password.RequireUppercase = true;
                o.Password.RequireNonAlphanumeric = true;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
            // add EntityFrameworkStores implementation with the default token providers. 
        }
    }
}
