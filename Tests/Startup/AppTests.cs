using NUnit.Framework;
using Startup;
using Tests.API.Mocks;

namespace Tests.Startup;

public class AppTests
{
    private StringWriter _writer;
    private TextReader _reader;

    private ControllerMock _controller;

    [SetUp]
    public void SetUp()
    {
        _writer = new StringWriter();
        _reader = new StringReader("");

        Console.SetIn(_reader);
        Console.SetOut(_writer);

        _controller = new ControllerMock();
    }

    [Test]
    public void Starts()
    {
        App.Run(_controller);

        _writer.ToString().Should().NotBeNullOrEmpty();
    }

    [TestCase("abc")]
    [TestCase("read this")]
    public void RespondsToInput(string inputString)
    {
        var expected = inputString.ToUpper();

        _reader = new StringReader(inputString);
        Console.SetIn(_reader);

        App.Run(_controller);

        _writer.ToString().TrimEnd().Should().EndWith(expected);
    }

    [Test]
    public void ControllerReturnsShutDown_AppCloses()
    {
        var inputString = "ShutDown";
        Console.SetIn(new StringReader(inputString));
        _controller.SetCommandToRun(new EchoCommand());

        App.Run(_controller);

        _writer.ToString().TrimEnd().Should().EndWith(inputString);
    }

    [Test]
    public void ControllerReturnsAnythingButShutDown_AppContinuesRunning()
    {

    }
}