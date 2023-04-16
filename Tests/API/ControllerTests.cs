using API;
using Tests.API.Mocks;

namespace Tests.API;

internal class ControllerTests
{
    private EndpointFactoryMock _endpointFactory;
    private Controller _controller;
    private EndpointMock _endpoint;

    private readonly string ValidEndpoint = EndpointMock.Address;

    [SetUp]
    public void SetUp()
    {
        _endpoint = new EndpointMock();
        _endpointFactory = new EndpointFactoryMock();
        _endpointFactory.AddEndpoint(ValidEndpoint, _endpoint);
        _controller = new Controller(_endpointFactory);
    }

    [Test]
    public void TriggerEndpoint_ReceivesValidEndpoint_ReturnsOutputFromEndpoint()
    {
        var result = _controller.TriggerEndpoint(ValidEndpoint);

        _endpoint.EndpointWasCalled.Should().BeTrue();
        _endpoint.CallEndpointArgs.Should().BeEmpty();
        result.Should().Be(_endpoint.CallEndpointReturnValue);
    }

    [Test]
    public void TriggerEndpoint_ReceivesNull_ThrowsArgumentException()
    {
        var wasThrown = false;
        try
        {
            _controller.TriggerEndpoint(null);
        }
        catch (ArgumentException)
        {
            wasThrown = true;
        }
        wasThrown.Should().BeTrue();
        _endpoint.EndpointWasCalled.Should().BeFalse();
    }

    [Test]
    public void TriggerEndpoint_ReceivesStringWithValidEndpointAndParams_ReturnsOutputFromEndpoint()
    {
        var arg1 = "arg1";
        var arg2 = "arg2";
        var endpointWithArgs = $"{ValidEndpoint} /{arg1} /{arg2}";

        var result = _controller.TriggerEndpoint(endpointWithArgs);

        _endpoint.EndpointWasCalled.Should().BeTrue();
        _endpoint.CallEndpointArgs.Should().HaveCount(2)
            .And.Contain(arg1)
            .And.Contain(arg2);
        result.Should().Be(_endpoint.CallEndpointReturnValue);
    }

}
