using API.Commands;

namespace Tests.API.Mocks;

/// <summary>
/// Mock implementation of the <see cref="ICommand"/> interface, for testing.
/// </summary>
internal class CommandMock : ICommand
{
    /// <summary>
    /// If the class's <see cref="Run(string[])"/> method was called.
    /// </summary>
    public bool RunWasCalled { get; private set; }

    /// <summary>
    /// Arguments that were passed to the <see cref="Run(string[])"/> method.
    /// </summary>
    public string[] RunArgs { get; private set; }

    /// <summary>
    /// The Value that should be returned by the <see cref="Run(string[])"/> method.
    /// </summary>
    public string RunReturnValue { get; set; }

    public static string CommandWord => "mock";

    private const string DefaultRunReturnValue = "CommandMock.Run";

    public CommandMock()
    {
        RunArgs = Array.Empty<string>();
        RunReturnValue = DefaultRunReturnValue;
    }

    /// <summary>
    /// Method for the mock object to reset its default values.
    /// </summary>
    public void ResetMock()
    {
        RunWasCalled = false;
        RunArgs = Array.Empty<string>();
        RunReturnValue = DefaultRunReturnValue;
    }

    /// <summary>
    /// Implementation of the interface <see cref="ICommand.Run(string[])"/> method.
    /// Sets <see cref="RunWasCalled"/> to true. 
    /// Sets <see cref="RunArgs"/> to the passed in param value.
    /// </summary>
    /// <param name="args"></param>
    /// <returns>the value set in <see cref="RunReturnValue"/></returns>
    public string Run(string[] args)
    {
        RunWasCalled = true;
        RunArgs = args;
        return RunReturnValue;
    }
}
