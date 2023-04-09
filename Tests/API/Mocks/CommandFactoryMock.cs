using API;
using API.Commands;
using System.Data;

namespace Tests.API.Mocks;

/// <summary>
/// Mock implementation of the ICommandFactory interface, for testing.
/// </summary>
internal class CommandFactoryMock : ICommandFactory
{
    private Dictionary<string, object> Commands { get; set; }

    public CommandFactoryMock()
    {
        Commands = new Dictionary<string, object>();
    }

    /// <summary>
    /// Add a command to the lookup, so it can be found by the injection system.
    /// </summary>
    /// <param name="commandName"></param>
    /// <param name="commandObject"></param>
    public void AddCommand(string commandName, ICommand commandObject)
    {
        Commands.Add(commandName, commandObject);
    }

    /// <summary>
    /// Implementation of the ICommandFactory interface. Returns the registered <see cref="ICommand"/> with the given name.
    /// </summary>
    /// <param name="commandName">The name of the ICommand to return.</param>
    /// <returns></returns>
    public ICommand GetCommand(string commandName)
    {
        var command = Commands[commandName] ?? throw new ArgumentException($"{commandName} is not a valid command.");
        return command as ICommand ?? throw new ArgumentException($"{commandName} is not a valid command.");
    }
}
