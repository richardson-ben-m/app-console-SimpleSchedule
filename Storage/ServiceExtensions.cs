using Logic.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Storage;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterStorage(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .RegisterReminderRepository();
    }

    private static IServiceCollection RegisterReminderRepository(this IServiceCollection serviceCollection)
    {
        var configuration = serviceCollection.BuildServiceProvider().GetRequiredService<IConfiguration>();
        var storagePath = GetFileRepositoryPath(configuration);
        var repository = new FileReminderRepository(storagePath);
        serviceCollection.AddSingleton<IReminderRepository>(repository);
        return serviceCollection;
    }

    private static string GetFileRepositoryPath(IConfiguration configuration)
    {
        var connectionName = "ReminderRepository";

        var connectionString = configuration.GetConnectionString(connectionName);
        return connectionString == null
            ? throw new ApplicationException($"Expected Connection String {connectionName} not found in Configuration")
            : $"{Environment.GetEnvironmentVariable("USERPROFILE")}/{connectionString}";
    }
}
