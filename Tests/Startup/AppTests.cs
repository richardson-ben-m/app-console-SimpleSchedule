using Startup;
using Tests.API.Mocks;

namespace Tests.Startup;

public class AppTests
{
    private StringWriter _writer;

    private ControllerMock _controller;

    private readonly string newLine = Environment.NewLine;
    private readonly string shutDownCommand = "ShutDown";

    [SetUp]
    public void SetUp()
    {
        _writer = new StringWriter();

        Console.SetOut(_writer);

        _controller = new ControllerMock();
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(99)]
    public void AppRunsUntilReceivesShutDownCommand(int numberOfCommands)
    {
        var expected = SetUpCommandsToRun(numberOfCommands);

        App.Run(_controller);

        _writer.ToString().TrimEnd().Should().EndWith(expected);
    }

    private string SetUpCommandsToRun(int numberOfCommands)
    {
        if (numberOfCommands == 0) 
            return SetUpConsoleInput(null);

        var inputString = "cmd";
        string commands = inputString;

        for (int i = 1; i < numberOfCommands; i++)
        {
            commands += newLine + inputString;
        }
        return SetUpConsoleInput(commands);
    }

    private string SetUpConsoleInput(string? input)
    {
        var cmd = shutDownCommand;
        if (input != null) cmd = input + newLine + cmd;
        Console.SetIn(new StringReader(cmd));
        return cmd;
    }

}