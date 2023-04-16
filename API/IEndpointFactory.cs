using API.Endpoints;

namespace API;

public interface IEndpointFactory
{
    /// <summary>
    /// Returns the <see cref="IEndpoint"/> registered under the given address.
    /// </summary>
    /// <param name="endpointAddress">The address of the <see cref="IEndpoint"/> to return.</param>
    /// <returns>The registered <see cref="IEndpoint"/> object.</returns>
    IEndpoint GetEndpoint(string endpointAddress);
}
