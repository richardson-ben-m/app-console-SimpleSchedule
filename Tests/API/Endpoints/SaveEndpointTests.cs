using API.Endpoints;
using Logic.Classes;
using Logic.Models;
using System.Text.Json;
using Tests.Storage.Mocks;

namespace Tests.API.Endpoints;

internal class SaveEndpointTests
{
    private SaveEndpoint _endpoint;

    [SetUp]
    public void SetUp()
    {
        _endpoint = new SaveEndpoint(new ReminderCommandService(new ReminderRepositoryMock()));
    }

    [Test]
    public void CallEndpoint_FirstArgIsValidReminderDto_ReturnsOk()
    {
        var dto = new ReminderCommandDto
        {
            Title = "test title",
            RemindInValue = 1
        };
        var json = JsonSerializer.Serialize(dto);

        var result = _endpoint.CallEndpoint(new string[] { json });

        result.Should().Be("OK");
    }

    [Test]
    public void CallEndpoint_FirstArgIsNotValidReminderDto_ReturnsErrorDetails() =>
        TestForErrorDetails(new string[] { "not valid" });

    [Test]
    public void CallEndpoint_NoArgPassed_ReturnsErrorDetails() =>
        TestForErrorDetails(Array.Empty<string>());

    private void TestForErrorDetails(string[] args)
    {
        var result = _endpoint.CallEndpoint(args);
        result.Should().NotBe("OK").And.StartWith("Error");
    }
}
