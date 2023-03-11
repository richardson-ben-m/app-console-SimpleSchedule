using API;

namespace Tests.API;

internal class CommandFactoryMock
{
    private Dictionary<string,ICommand> Commands { get; set; }

    public CommandFactoryMock()
    {
        Commands = new Dictionary<string, ICommand>();    
    }

    public void AddCommand(string commandName, ICommand commandObject)
    {
        Commands.Add(commandName, commandObject);
    }

    public ICommand FactoryFunction(string command)
    {
        return Commands[command];
    }
}
