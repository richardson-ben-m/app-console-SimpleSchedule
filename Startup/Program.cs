using API;
using Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Startup;
using Storage;

class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services
            .AddSingleton(BuildConfiguration());
        ConfigureServices(services);

        var controller = services.BuildServiceProvider().GetService<Controller>()
            ?? throw new ApplicationException("Controller not initialized");
        App.Run(controller);
    }

    private static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services
            .RegisterControllers()
            .RegisterStorage()
            .RegisterLogic();
    }
}