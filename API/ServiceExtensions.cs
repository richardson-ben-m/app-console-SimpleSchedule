using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace API;

public delegate ICommand CommandFactory(string commandName);

public static class ServiceExtensions
{

    private static readonly Dictionary<string, Type> RegisteredCommands = new Dictionary<string, Type>
    {
        {"save", typeof(SaveCommand)}
    };

    public static IServiceCollection RegisterControllers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<Controller>();
        serviceCollection.AddSingleton<CommandFactory>(sp => commandName =>
        {
            if (string.IsNullOrEmpty(commandName)) throw new ArgumentException($"Command not passed.");

            if (!RegisteredCommands.ContainsKey(commandName)) throw new ArgumentException($"{commandName} is not a valid Command");

            var commandType = RegisteredCommands[commandName] ?? throw new ArgumentException($"{commandName} is not a valid Command");
            var command = sp.GetRequiredService(commandType) as ICommand;
            return command ?? throw new ArgumentException($"{commandName} is not a valid Command");
        });

        serviceCollection.RegisterCommands();
        return serviceCollection;
    }

    private static IServiceCollection RegisterCommands(this IServiceCollection serviceCollection)
    {
        foreach (var type in RegisteredCommands.Values)
            serviceCollection.AddTransient(type);
        return serviceCollection;
    }
}
