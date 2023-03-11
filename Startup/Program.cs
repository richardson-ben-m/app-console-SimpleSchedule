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

        var factoryObj = services.BuildServiceProvider().GetService(typeof(Controller)) 
            ?? throw new ApplicationException("CommandFactory not initialized");
        App.Run((Controller) factoryObj);
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