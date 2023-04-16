using API;
using API.Endpoints;

namespace Tests.API.Mocks;

/// <summary>
/// Mock implementation of the IEndpointFactory interface, for testing.
/// </summary>
internal class EndpointFactoryMock : IEndpointFactory
{
    private Dictionary<string, object> Endpoints { get; set; }

    public EndpointFactoryMock()
    {
        Endpoints = new Dictionary<string, object>();
    }

    /// <summary>
    /// Add a endpoint to the lookup, so it can be found by the injection system.
    /// </summary>
    /// <param name="endpointAddress"></param>
    /// <param name="endpointObject"></param>
    public void AddEndpoint(string endpointAddress, IEndpoint endpointObject)
    {
        Endpoints.Add(endpointAddress, endpointObject);
    }

    /// <summary>
    /// Implementation of the IEndpointFactory interface. Returns the registered <see cref="IEndpoint"/> with the given name.
    /// </summary>
    /// <param name="endpointAddress">The name of the IEndpoint to return.</param>
    /// <returns></returns>
    public IEndpoint GetEndpoint(string endpointAddress)
    {
        var endpoint = Endpoints[endpointAddress] ?? throw new ArgumentException($"{endpointAddress} is not a valid Endpoint.");
        return endpoint as IEndpoint ?? throw new ArgumentException($"{endpointAddress} is not a valid Endpoint.");
    }
}
