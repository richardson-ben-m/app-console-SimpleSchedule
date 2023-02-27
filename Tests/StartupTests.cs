using Logic.Output;
using SimpleSchedule;
using Tests.Input;

namespace Tests;

public class StartupTests
{
    private Mock<IOutput> _textOutput;
    private InputReaderMock _inputReader;

    [SetUp]
    public void Setup()
    {
        _textOutput= new Mock<IOutput>();
        _inputReader= new InputReaderMock();
    }

    [Test]
    public void AppStarts()
    {
        var startup = new Startup(_textOutput.Object, _inputReader);

        startup.Run(Array.Empty<string>());

        _textOutput.Verify(e => e.OutputLineOfText(It.IsAny<string>()), Times.AtLeastOnce);
    }
}