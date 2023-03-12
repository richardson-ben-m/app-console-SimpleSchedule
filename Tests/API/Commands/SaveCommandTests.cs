using API.Commands;
using Logic.Classes;
using Logic.Models;
using System.Text.Json;
using Tests.Storage;

namespace Tests.API.Commands;

internal class SaveCommandTests
{
    private SaveCommand _command;

    [SetUp]
    public void SetUp()
    {
        _command = new SaveCommand(new Service(new ReminderRepositoryMock()));
    }

    [Test]
    public void Run_FirstArgIsValidReminderDto_ReturnsOk()
    {
        var dto = new ReminderDto();
        var json = JsonSerializer.Serialize(dto);

        var result = _command.Run(new string[] { json });

        result.Should().Be("OK");
    }

    [Test]
    public void Run_FirstArgIsNotValidReminderDto_ReturnsErrorDetails() =>
        TestForErrorDetails(new string[] { "not valid" });

    [Test]
    public void Run_NoArgPassed_ReturnsErrorDetails() =>
        TestForErrorDetails(Array.Empty<string>());

    private void TestForErrorDetails(string[] args)
    {
        var result = _command.Run(args);
        result.Should().NotBe("OK").And.StartWith("Error");
    }
}
