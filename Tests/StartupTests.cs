using Startup;

namespace Tests;

public class StartupTests
{
    private StringWriter _writer;
    private TextReader _reader;

    [SetUp]
    public void SetUp()
    {
        _writer = new StringWriter();
        _reader = new StringReader("");

        Console.SetOut(_writer);
        Console.SetIn(_reader);
    }

    [Test]
    public void AppStarts()
    {
        Application.Run();

        _writer.ToString().Should().NotBeNullOrEmpty();
    }
}