using Microsoft.Extensions.DependencyInjection;
using Input;
using Output;
using SimpleSchedule;
using Logic;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services
            .AddSingleton(BuildConfiguration());
        ConfigureServices(services);
        services
            .AddSingleton<Startup>()
            .BuildServiceProvider()
            .GetRequiredService<Startup>()
            .Run();
        Console.ReadLine();
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
            .RegisterInput()
            .RegisterOutput()
            .RegisterStorage()
            .RegisterLogic();
    }
}