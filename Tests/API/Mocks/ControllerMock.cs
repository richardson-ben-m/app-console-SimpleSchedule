using API;
using API.Commands;

namespace Tests.API.Mocks;

/// <summary>
/// Mock of the <see cref="Controller"/> class, for testing.
/// </summary>
internal class ControllerMock : Controller
{
    private ICommand _commandToRun = new EchoCommand();

    public ControllerMock() : base(new CommandFactoryMock()) { }

    /// <summary>
    /// Uses a <see cref="ICommand"/> to test <see cref="Controller.RunCommand(string?)"/> method functionality.
    /// Command can be set by <see cref="SetCommandToRun(ICommand)"/>.
    /// If not set, default is <see cref="EchoCommand"/>.
    /// </summary>
    /// <param name="command">The command string.</param>
    /// <returns>The return value from the ICommand object.</returns>
    public override string RunCommand(string? command)
    {
        var args = new string[] { command ?? "" };
        return _commandToRun.Run(args);
    }

    /// <summary>
    /// Sets the command object used by the Mock for testing.
    /// </summary>
    /// <param name="commandObject">Object of type ICommand</param>
    public void SetCommandToRun(ICommand commandObject)
    {
        _commandToRun = commandObject;
    }
}
