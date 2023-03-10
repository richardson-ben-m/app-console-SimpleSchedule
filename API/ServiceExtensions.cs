using Microsoft.Extensions.DependencyInjection;

namespace API;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterInput(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<CommandFactory>();
        return serviceCollection;
    }
}
