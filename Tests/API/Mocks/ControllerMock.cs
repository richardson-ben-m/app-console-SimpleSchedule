using API;

namespace Tests.API.Mocks;

/// <summary>
/// Mock of the <see cref="Controller"/> class, for testing.
/// </summary>
internal class ControllerMock : Controller
{
    public ControllerMock() : base(new CommandFactoryMock()) { }

    /// <summary>
    /// Uses a <see cref="CapsCommand"/> to test <see cref="Controller.RunCommand(string?)"/> method functionality.
    /// </summary>
    /// <param name="command">A string to capitalize.</param>
    /// <returns>The string param as all caps.</returns>
    public override string RunCommand(string? command)
    {
        var args = new string[] { command ?? "" };
        return new CapsCommand().Run(args);
    }
}
