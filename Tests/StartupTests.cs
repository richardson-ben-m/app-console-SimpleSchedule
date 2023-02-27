using Logic.Output;
using Logic.Interfaces;
using SimpleSchedule;
using Tests.Input;

namespace Tests;

public class StartupTests
{
    private Mock<IOutput> _textOutput;
    private InputReaderMock _inputReader;
    private Mock<ICommand> _command;

    [SetUp]
    public void Setup()
    {
        _textOutput= new Mock<IOutput>();
        _inputReader= new InputReaderMock();
        _command = new Mock<ICommand>();
    }

    [Test]
    public void AppStarts()
    {
        var startup = new Startup(_textOutput.Object, _inputReader, _command.Object);

        startup.Run(Array.Empty<string>());

        _textOutput.Verify(e => e.OutputLineOfText(It.IsAny<string>()), Times.AtLeastOnce);
    }
}