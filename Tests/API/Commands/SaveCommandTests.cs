using API.Commands;
using Logic.Classes;
using Logic.Interfaces;

namespace Tests.API.Commands;

internal class SaveCommandTests
{
    private IService _service;
    private SaveCommand _command;

    [SetUp]
    public void SetUp()
    {
        _service = new Service();
        _command = new SaveCommand(_service);
    }

    [Test]
    public void Run_StringIsValidReminderDto_ReturnsOk()
    {
        var result = _command.Run(Array.Empty<string>());

        result.Should().Be("OK");
    }
}
