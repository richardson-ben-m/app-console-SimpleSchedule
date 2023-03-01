using Logic.Storage;
using Microsoft.Extensions.DependencyInjection;
using Storage;

namespace Input;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterStorage(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IReminderRepository>(new FileReminderRepository());
        return serviceCollection;
    }
}
