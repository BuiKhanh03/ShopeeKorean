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
app.Urls.Add($"http://*:{port}");
app.MapGet("/health", () => Results.Ok("Healthy"));

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from the middleware component.");
});
