using Microsoft.Extensions.DependencyInjection;

namespace Logic;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterLogic(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
