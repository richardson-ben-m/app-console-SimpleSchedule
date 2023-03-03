using Logic.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Input;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterInput(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<UserInputHandlerBase>(new UserTextInputHandler());
        return serviceCollection;
    }
}
