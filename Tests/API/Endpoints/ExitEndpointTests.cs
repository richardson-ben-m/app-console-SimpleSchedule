using API.Endpoints;

namespace Tests.API.Endpoints;

internal class ExitEndpointTests
{
    private ExitEndpoint _exitEndpoint;

    [SetUp]
    public void SetUp()
    {
        _exitEndpoint = new ExitEndpoint();
    }

    [Test]
    public void CallEndpoint_ReturnsShutDown()
    {
        var result = _exitEndpoint.CallEndpoint(Array.Empty<string>());

        result.Should().Be("ShutDown");
    }
}
