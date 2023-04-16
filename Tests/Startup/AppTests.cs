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
    public void AppRunsUntilReceivesShutDownCommand(int numberOfEndpointCalls)
    {
        var expected = SetUpEndpointCalls(numberOfEndpointCalls);

        App.Run(_controller);

        _writer.ToString().TrimEnd().Should().EndWith(expected);
    }

    private string SetUpEndpointCalls(int numberOfEndpointCalls)
    {
        if (numberOfEndpointCalls == 0) 
            return SetUpConsoleInput(null);

        var inputString = "endpointCall";
        string endpointCalls = inputString;

        for (int i = 1; i < numberOfEndpointCalls; i++)
        {
            endpointCalls += newLine + inputString;
        }
        return SetUpConsoleInput(endpointCalls);
    }

    private string SetUpConsoleInput(string? input)
    {
        var commandString = shutDownCommand;
        if (input != null) commandString = input + newLine + commandString;
        Console.SetIn(new StringReader(commandString));
        return commandString;
    }

}