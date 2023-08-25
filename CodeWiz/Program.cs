using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POC.CodeWiz;

public class Program
{
    public static void Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();
        using var scope = host.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        var app = serviceProvider.GetRequiredService<App>();
        app.Run();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
             .ConfigureServices((hostContext, services) =>
             {
                 services.AddTransient<IHelper, Helper>();
                 services.AddScoped<App>();
             });
}