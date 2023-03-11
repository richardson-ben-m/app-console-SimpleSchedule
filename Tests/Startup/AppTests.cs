using Startup;
using Tests.API.Mocks;

namespace Tests.Startup;

public class AppTests
{
    private StringWriter _writer;
    private TextReader _reader;

    private ControllerMock _commandFactory;


    [SetUp]
    public void SetUp()
    {
        _writer = new StringWriter();
        _reader = new StringReader("");

        Console.SetIn(_reader);
        Console.SetOut(_writer);

        _commandFactory = new ControllerMock();
    }

    [Test]
    public void Starts()
    {
        App.Run(_commandFactory);

        _writer.ToString().Should().NotBeNullOrEmpty();
    }

    [TestCase("abc")]
    [TestCase("read this")]
    public void RespondsToInput(string inputString)
    {
        var expected = inputString.ToUpper();

        _reader = new StringReader(inputString);
        Console.SetIn(_reader);

        App.Run(_commandFactory);

        var result = _writer.ToString().TrimEnd();

        result.Should().EndWith(expected);
    }
}