namespace Input;

/// <summary>
/// Factory class for getting SimpleSchedule command objects.
/// </summary>
public class CommandFactory
{
    /// <summary>
    /// Gets a Command object based on the given string.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public Commands GetCommand(string command)
    {
        return Commands.Save;
    }
}
