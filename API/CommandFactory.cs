using API.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace API;

/// <summary>
/// The injector system used by the <see cref="Controller"/> to return <see cref="ICommand"/> objects by name.
/// </summary>
public class CommandFactory : ICommandFactory
{
    /// <summary>
    /// Add <see cref="ICommand"/> items here to be injected.
    /// </summary>
    internal static readonly Dictionary<string, Type> RegisteredCommands = new();

    private readonly IServiceProvider _serviceProvider;

    public CommandFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Returns the <see cref="ICommand"/> object by name.
    /// </summary>
    /// <param name="commandName">The name of the ICommand to return.</param>
    /// <returns>The registered <see cref="ICommand"/></returns>
    /// <exception cref="ArgumentException">The name passed is not the name of a registered ICommand.</exception>
    public ICommand GetCommand(string commandName) 
    {
        if (string.IsNullOrEmpty(commandName)) throw new ArgumentException($"Command not passed.");
        if (!RegisteredCommands.ContainsKey(commandName)) throw new ArgumentException($"{commandName} is not a valid Command");
        var commandType = RegisteredCommands[commandName] ?? throw new ArgumentException($"{commandName} is not a valid Command");
        var command = _serviceProvider.GetRequiredService(commandType) as ICommand;
        return command ?? throw new ArgumentException($"{commandName} is not a valid Command");
    }

    internal static void RegisterCommands()
    {
        RegisteredCommands.Clear();
        
        var iCommands = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsAssignableTo(typeof(ICommand)) && !t.IsInterface);
        foreach ( var commandType in iCommands)
        {
            var commandString = commandType.GetProperty("CommandWord")?.GetValue(null)?.ToString();
            if (commandString != null)
                    RegisteredCommands.Add(commandString, commandType);
        }
    }
}
