using API;
using Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Startup;
using Storage;

class Program
{
    /// <summary>
    /// Entry point of the application. Sets up Configuration and Injection. Calls <see cref="App"/> class to execute.
    /// </summary>
    /// <exception cref="ApplicationException"></exception>
    static void Main()
    {
        var services = new ServiceCollection();
        services
            .AddSingleton(BuildConfiguration());
        RegisterServices(services);

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

    private static void RegisterServices(IServiceCollection services)
    {
        services
            .RegisterControllers()
            .RegisterStorage()
            .RegisterLogic();
    }
}