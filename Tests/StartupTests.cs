using Logic.Output;
using Logic.Interfaces;
using SimpleSchedule;
using Tests.Input;

namespace Tests;

public class StartupTests
{
    private Mock<OutputHandlerBase> _textOutput;
    private UserInputHandlerMock _inputReader;
    private Mock<ICommand> _command;

    [SetUp]
    public void Setup()
    {
        _textOutput= new Mock<OutputHandlerBase>();
        _inputReader= new UserInputHandlerMock();
        _command = new Mock<ICommand>();
    }

    [Test]
    public void AppStarts()
    {
        var startup = new Startup(_textOutput.Object, _inputReader, _command.Object);

        startup.Run();

        _textOutput.Verify(e => e.OutputLineOfText(It.IsAny<string>()), Times.AtLeastOnce);
    }
}