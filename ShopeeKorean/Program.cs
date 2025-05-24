using ShopeeKorean.Controllers.Extensions;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");


// Add services to the container
builder.Services.ConfigureCors();
builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureSqlContext(builder.Configuration);

var app = builder.Build();

app.UseHealthChecks("/health");

// Configure middleware
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();


app.MapControllers();

app.Run();

