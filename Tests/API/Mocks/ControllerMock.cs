using API;
using API.Endpoints;

namespace Tests.API.Mocks;

/// <summary>
/// Mock of the <see cref="Controller"/> class, for testing.
/// </summary>
internal class ControllerMock : Controller
{
    private IEndpoint _endpointToTrigger = new EchoEndpoint();

    public ControllerMock() : base(new EndpointFactoryMock()) { }

    /// <summary>
    /// Uses a <see cref="IEndpoint"/> to test <see cref="Controller.TriggerEndpoint(string?)"/> method functionality.
    /// Endpoint can be set by <see cref="SetEndpoint(IEndpoint)"/>.
    /// If not set, default is <see cref="EchoEndpoint"/>.
    /// </summary>
    /// <param name="endpointAddress">The endpointAddress string.</param>
    /// <returns>The return value from the IEndpoint object.</returns>
    public override string TriggerEndpoint(string? endpointAddress)
    {
        var args = new string[] { endpointAddress ?? "" };
        return _endpointToTrigger.CallEndpoint(args);
    }

    /// <summary>
    /// Sets the endpointAddress object used by the Mock for testing.
    /// </summary>
    /// <param name="endpointObject">Object of type IEndpoint</param>
    public void SetEndpoint(IEndpoint endpointObject)
    {
        _endpointToTrigger = endpointObject;
    }
}
