using Microsoft.Extensions.DependencyInjection;

namespace API;

public class CommandFactory : ICommandFactory
{
    internal static readonly Dictionary<string, Type> RegisteredCommands = new Dictionary<string, Type>
    {
        {"save", typeof(SaveCommand)}
    };

    private readonly IServiceProvider _serviceProvider;

    public CommandFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ICommand GetCommand(string commandName) 
    {
        if (string.IsNullOrEmpty(commandName)) throw new ArgumentException($"Command not passed.");
        if (!RegisteredCommands.ContainsKey(commandName)) throw new ArgumentException($"{commandName} is not a valid Command");
        var commandType = RegisteredCommands[commandName] ?? throw new ArgumentException($"{commandName} is not a valid Command");
        var command = _serviceProvider.GetRequiredService(commandType) as ICommand;
        return command ?? throw new ArgumentException($"{commandName} is not a valid Command");
    }
}
