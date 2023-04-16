using API.Endpoints;

namespace Tests.API.Mocks;

/// <summary>
/// Mock implementation of the <see cref="IEndpoint"/> interface, for testing.
/// </summary>
internal class EndpointMock : IEndpoint
{
    /// <summary>
    /// If the class's <see cref="CallEndpoint(string[])"/> method was called.
    /// </summary>
    public bool EndpointWasCalled { get; private set; }

    /// <summary>
    /// Arguments that were passed to the <see cref="CallEndpoint(string[])"/> method.
    /// </summary>
    public string[] CallEndpointArgs { get; private set; }

    /// <summary>
    /// The Value that should be returned by the <see cref="CallEndpoint(string[])"/> method.
    /// </summary>
    public string CallEndpointReturnValue { get; set; }

    public static string Address => "mock";

    private const string DefaultCallReturnValue = "EndpointMock.CallEndpoint";

    public EndpointMock()
    {
        CallEndpointArgs = Array.Empty<string>();
        CallEndpointReturnValue = DefaultCallReturnValue;
    }

    /// <summary>
    /// Method for the mock object to reset its default values.
    /// </summary>
    public void ResetMock()
    {
        EndpointWasCalled = false;
        CallEndpointArgs = Array.Empty<string>();
        CallEndpointReturnValue = DefaultCallReturnValue;
    }

    /// <summary>
    /// Implementation of the interface <see cref="IEndpoint.CallEndpoint(string[])"/> method.
    /// Sets <see cref="EndpointWasCalled"/> to true. 
    /// Sets <see cref="CallEndpointArgs"/> to the passed in param value.
    /// </summary>
    /// <param name="args"></param>
    /// <returns>the value set in <see cref="CallEndpointReturnValue"/></returns>
    public string CallEndpoint(string[] args)
    {
        EndpointWasCalled = true;
        CallEndpointArgs = args;
        return CallEndpointReturnValue;
    }
}
