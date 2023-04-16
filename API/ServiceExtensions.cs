using Microsoft.Extensions.DependencyInjection;

namespace API;

public static class ServiceExtensions
{

    public static IServiceCollection RegisterControllers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<Controller>();
        serviceCollection.AddSingleton<IEndpointFactory, EndpointFactory>();

        serviceCollection.RegisterEndpoints();
        return serviceCollection;
    }

    private static IServiceCollection RegisterEndpoints(this IServiceCollection serviceCollection)
    {
        EndpointFactory.RegisterEndpoints();
        foreach (var type in EndpointFactory.RegisteredEndpoints.Values)
            serviceCollection.AddTransient(type);
        return serviceCollection;
    }
}
