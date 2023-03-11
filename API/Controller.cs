namespace API;

public class Controller
{
    private readonly ICommandFactory _commandFactory;

    public Controller(ICommandFactory commandFactory)
    {
        _commandFactory = commandFactory;
    }

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
        return input.Split("/")[0];
    }

    private static string[] ArgsFromInput(string input)
    {
        var args = input.Split("/").ToList();
        args.RemoveAt(0);
        return args.ToArray();
    }
}
