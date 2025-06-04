using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using ShopeeKorean.Application.Extensions;
using ShopeeKorean.Presentation.ActionFilters;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

NewtonsoftJsonPatchInputFormatter GetJonPatchInputFormatter() => new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
                                                                     .Services.BuildServiceProvider()
                                                                     .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
                                                                     .OfType<NewtonsoftJsonPatchInputFormatter>().First();

// Add services to the container
builder.Services.ConfigureCors();
builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureRepositoryManager();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddMailConfiguration(builder.Configuration);
builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters()
  .AddApplicationPart(typeof(ShopeeKorean.Presentation.AssemblyReference).Assembly);
//tùy chỉnh phản hồi lỗi (custom validation response).
//sử dụng FluentValidation hoặc validation logic riêng và không muốn ASP.NET Core tự động trả về lỗi.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.InputFormatters.Insert(0, GetJonPatchInputFormatter());
}).AddXmlDataContractSerializerFormatters();

builder.Services.ConfigureSwagger();
/*builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Shopee Korean API",
        Version = "v1",
        Description = "API for Shopee Korean application"
    });
});*/

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
app.UseExceptionHandler(opt => { });
if (app.Environment.IsProduction())
    app.UseHsts();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHealthChecks("/health");

// Configure middleware
//app.UseHttpsRedirection();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
});
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
