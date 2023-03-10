namespace API;

public class CommandFactory
{
    public virtual string RunCommand(string? input)
    {
        if (input == null) throw new ArgumentException($"Command is empty.");

        var commandType = CommandFromInput(input);
        var command = commandType switch
        {
            "save" => new SaveCommand(),
            "" => throw new ArgumentException($"Command is empty."),
            _ => throw new ArgumentException($"{commandType} is not a valid Command"),
        };

        var args = ArgsFromInput(input);
        return command.Run(args);
    }

    private static string CommandFromInput(string input)
    {
        return input.Split(" ")[0];
    }

    private static string[] ArgsFromInput(string input)
    {
        var args = input.Split(" ").ToList();
        args.RemoveAt(0);
        return args.ToArray();
    }
}
