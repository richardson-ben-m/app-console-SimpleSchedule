using Microsoft.Extensions.DependencyInjection;

namespace API;

public static class ServiceExtensions
{

    public static IServiceCollection RegisterControllers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<Controller>();
        serviceCollection.AddSingleton<ICommandFactory, CommandFactory>();

        serviceCollection.RegisterCommands();
        return serviceCollection;
    }

    private static IServiceCollection RegisterCommands(this IServiceCollection serviceCollection)
    {
        CommandFactory.RegisterCommands();
        foreach (var type in CommandFactory.RegisteredCommands.Values)
            serviceCollection.AddTransient(type);
        return serviceCollection;
    }
}
