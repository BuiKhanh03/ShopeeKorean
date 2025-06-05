using Contracts;
using Repository;
using System.Text;
using LoggerService;
using ShopeeKorean.Service;
using ShopeeKorean.Contracts;
using ShopeeKorean.Repository;
using Microsoft.OpenApi.Models;
using ShopeeKorean.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ShopeeKorean.Service.Contracts;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ShopeeKorean.Entities.ConfigurationModels;
using GarageManagementAPI.Service.DataShaping;
using ShopeeKorean.Service.DataShapping;

namespace ShopeeKorean.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                 builder.WithOrigins("http://localhost:32768", "http://localhost:32769", "http://localhost:8080")
               //  builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
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
        public static void ConfigureDataShaperManager(this IServiceCollection services) => services.AddScoped<IDataShaperManager, DataShaperManager>();

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

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            //Bind ánh xạ dữ liệu cấu hình vào đối tượng C#
            var jwtConfiguration = new JwtConfiguration();
            configuration.Bind(jwtConfiguration.Section, jwtConfiguration);
            var secretKey = jwtConfiguration.SecretKey;

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true, // The token has not expired 
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = jwtConfiguration.ValidIssuer,
                        ValidAudience = jwtConfiguration.ValidAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!))
                    };
                });
        }

        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration) 
          =>  services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));
        
        
        public static void AddMailConfiguration(this IServiceCollection services, IConfiguration configuration)
            => services.Configure<MailConfiguration>(configuration.GetSection("MailSettings"));

        public static void AddCloudinaryConfiguration(this IServiceCollection services, IConfiguration configuration)
            => services.Configure<CloudinaryConfiguration>(configuration.GetSection("CloudinarySettings"));

        public static void ConfigureSwagger(this IServiceCollection services) {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Shopee Korean API",
                    Version = "v1",
                    Description = "API for Shopee Korean application",
                    Contact = new OpenApiContact
                    {
                        Name = "Bùi Duy Khánh",
                        Email = "buikhanh0130@gmail.com",
                    }
                });
                var xmlFile = $"{typeof(Presentation.AssemblyReference).Assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}
