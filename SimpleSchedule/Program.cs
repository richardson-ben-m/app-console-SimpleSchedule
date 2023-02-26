//Startup _ = new(args);

//using Logic;
using Microsoft.Extensions.DependencyInjection;
using Output;
using SimpleSchedule;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        services
            .AddSingleton<Startup>()
            .BuildServiceProvider()
            .GetRequiredService<Startup>()
            .Run(args);
        Console.ReadLine();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.RegisterOutput();
    }
}