using System.Text.Json;
using System.Text.Json.Serialization;
using api;
using dataaccess;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void ConfigureServices(IServiceCollection services)
    {
        var myConnstring = Environment.GetEnvironmentVariable("MyEnvironmentVariable");
        services.AddSingleton<MyAppOptions>(provider =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var appOptions = new MyAppOptions();
            configuration.GetSection(nameof(MyAppOptions)).Bind(appOptions);
            return appOptions;
        });
        services.AddControllers();
        services.AddOpenApiDocument();
        services.AddScoped<PetService>();
        services.AddDbContext<MyDbContext>((services, options) =>
        {
            options.UseNpgsql(services.GetRequiredService<MyAppOptions>()
                .Db);
        });
    }
    public static void Main()
    {
        
        var builder = WebApplication.CreateBuilder();
        ConfigureServices(builder.Services);
        var app = builder.Build();

        var config = app.Services.GetRequiredService<MyAppOptions>();
        Console.WriteLine(JsonSerializer.Serialize(config));
        app.UseOpenApi();
        app.UseSwaggerUi();
        app.MapControllers();
        
        app.GenerateApiClientsFromOpenApi("/../client/src/generated-client.ts").GetAwaiter().GetResult();
        
        app.Run();
    }
}


