namespace API;

public interface ICommandFactory
{
    ICommand GetCommand(string commandName);
}
