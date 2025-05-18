using ShopeeKorean.Extensions;

var builder = WebApplication.CreateBuilder(args);
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

// Health check route for Railway
app.MapGet("/", () => "App is running!");

// Map your controllers
app.MapControllers();

// Run the app on the correct port (this is important for Railway!)
app.Run($"http://0.0.0.0:{port}");
