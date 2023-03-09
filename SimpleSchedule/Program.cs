using API;
using Logic;
using Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleSchedule;

class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services
            .AddSingleton(BuildConfiguration());
        ConfigureServices(services);
        //services
        //    .AddSingleton<Startup>()
        //    .BuildServiceProvider()
        //    .GetRequiredService<Startup>()
        //    .Run();
        Startup.Run();
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
            .RegisterStorage()
            .RegisterLogic();
    }
}