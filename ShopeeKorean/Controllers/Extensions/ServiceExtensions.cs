using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Security.Cryptography.X509Certificates;

namespace ShopeeKorean.Controllers.Extensions
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
    }
}
