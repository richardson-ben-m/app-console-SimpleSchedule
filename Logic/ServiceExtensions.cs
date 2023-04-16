using Logic.Classes;
using Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Logic;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterLogic(this IServiceCollection services)
    {
        services.AddScoped<IReminderCommandService, ReminderCommandService>();
        return services;
    }
}
