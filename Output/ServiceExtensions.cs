﻿using Microsoft.Extensions.DependencyInjection;

namespace Output;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterOutput(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<OutputHandlerBase>(new TextOutputHandler());
        return serviceCollection;
    }
}
