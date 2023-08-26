using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POC.CodeWiz;

public class Program
{
    public static void Main(string[] args)
    {
        Setup(args, out IHost host, out IServiceScope scope, out App app);
        app.Run();
    }

    private static void Setup(string[] args, out IHost host, out IServiceScope scope, out App app)
    {
        host = CreateHostBuilder(args).Build();
        scope = host.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        app = serviceProvider.GetRequiredService<App>();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
             .ConfigureServices((hostContext, services) =>
             {
                 //services.AddTransient<IHelper, Helper>();
                 //services.AddTransient<IHelper2, Helper2>();
                 services.AddScoped<App>();
             });
}