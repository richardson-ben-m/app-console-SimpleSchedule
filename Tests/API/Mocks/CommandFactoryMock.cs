using API;

namespace Tests.API.Mocks;

internal class CommandFactoryMock : ICommandFactory
{
    private Dictionary<string, ICommand> Commands { get; set; }

    public CommandFactoryMock()
    {
        Commands = new Dictionary<string, ICommand>();
    }

    public void AddCommand(string commandName, ICommand commandObject)
    {
        Commands.Add(commandName, commandObject);
    }

    public ICommand GetCommand(string commandName)
    {
        return Commands[commandName];
    }
}
