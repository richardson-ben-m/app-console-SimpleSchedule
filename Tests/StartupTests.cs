using SimpleSchedule;
using Logic.Output;

namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AppStarts()
    {
        var textOutput = new Mock<ITextOutput>();
        var startup = new Startup(textOutput.Object);

        startup.Run(Array.Empty<string>());

        textOutput.Verify(e => e.WriteLine(It.IsAny<string>()), Times.AtLeastOnce);
    }
}