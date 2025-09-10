using System.Text.Json.Serialization;
using api;
using dataaccess;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApiDocument();
        services.AddScoped<PetService>();
        services.AddDbContext<MyDbContext>((services, options) =>
        {
            options.UseNpgsql(services.GetRequiredService<IConfiguration>()
                .GetValue<string>("Db"));
        });
    }
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();
        ConfigureServices(builder.Services);
        var app = builder.Build();
        app.UseOpenApi();
        app.UseSwaggerUi();
        app.MapControllers();
        app.Run();
    }
}


