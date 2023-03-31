namespace API;

/// <summary>
/// Class for running commands using string inputs.
/// </summary>
public class Controller
{
    private readonly ICommandFactory _commandFactory;

    public Controller(ICommandFactory commandFactory)
    {
        _commandFactory = commandFactory;
    }

    /// <summary>
    /// Runs a command using the given input.
    /// </summary>
    /// <param name="input">A string separated by '/'. The first element is the command to execute. Other elements are the params used to execute the command.</param>
    /// <returns>A string result from the executed command.</returns>
    /// <exception cref="ArgumentException"></exception>
    public virtual string RunCommand(string? input)
    {
        if (input == null) throw new ArgumentException($"Command is empty.");

        var commandType = CommandFromInput(input);
        var command = _commandFactory.GetCommand(commandType);

        var args = ArgsFromInput(input);
        return command.Run(args);
    }

    private static string CommandFromInput(string input)
    {
        return input.Split("/")[0].Trim();
    }

    private static string[] ArgsFromInput(string input)
    {
        var inArgs = input.Split("/");
        var outArgs = new string[inArgs.Length - 1];
        for (int i = 1; i < inArgs.Length; i++)
        {
            outArgs[i - 1] = inArgs[i].Trim();
        }
        return outArgs;
    }
}
