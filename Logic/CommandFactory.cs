namespace Input;

/// <summary>
/// Factory class for getting SimpleSchedule command objects.
/// </summary>
public class CommandFactory
{
    /// <summary>
    /// Gets a Command object based on the given string.
    /// Throws Argument Exception if the string is not a valid command name.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public ICommand? GetCommand(string command)
    {
        if (command.ToLower() == "save")
            return new SaveCommand();

        throw new ArgumentException($"Command {command} is not valid.");
    }
}
