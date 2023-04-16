using API.Endpoints;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace API;

/// <summary>
/// The injector system used by the <see cref="Controller"/> to return <see cref="IEndpoint"/> objects by their address.
/// </summary>
public class EndpointFactory : IEndpointFactory
{
    /// <summary>
    /// Add <see cref="IEndpoint"/> items here to be injected.
    /// </summary>
    internal static readonly Dictionary<string, Type> RegisteredEndpoints = new();

    private readonly IServiceProvider _serviceProvider;

    public EndpointFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Returns the <see cref="IEndpoint"/> object by Address.
    /// </summary>
    /// <param name="endpointAddress">The address of the IEndpoint to return.</param>
    /// <returns>The registered <see cref="IEndpoint"/></returns>
    /// <exception cref="ArgumentException">The address passed is not registered or no address passed.</exception>
    public IEndpoint GetEndpoint(string endpointAddress) 
    {
        if (string.IsNullOrEmpty(endpointAddress)) throw new ArgumentException($"Endpoint Address not passed.");
        if (!RegisteredEndpoints.ContainsKey(endpointAddress)) throw new ArgumentException($"{endpointAddress} is not a valid Endpoint.");
        var endpointType = RegisteredEndpoints[endpointAddress] ?? throw new ArgumentException($"{endpointAddress} is not a valid Endpoint.");
        var endpoint = _serviceProvider.GetRequiredService(endpointType) as IEndpoint;
        return endpoint ?? throw new ArgumentException($"{endpointAddress} is not a valid Endpoint.");
    }

    internal static void RegisterEndpoints()
    {
        RegisteredEndpoints.Clear();
        
        var iEndpoints = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IEndpoint)) && !t.IsInterface);
        foreach ( var endpointType in iEndpoints)
        {
            var endpointAddress = endpointType.GetProperty("Address")?.GetValue(null)?.ToString();
            if (endpointAddress != null)
                    RegisteredEndpoints.Add(endpointAddress, endpointType);
        }
    }
}
