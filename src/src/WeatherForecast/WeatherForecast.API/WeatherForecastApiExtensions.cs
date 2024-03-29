﻿using WeatherForecast.Application;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Infraestructure;
using DistributedCacheCleanArchitecture;

namespace WeatherForecast.API;

public static class WeatherForecastApiExtensions
{
    public static IServiceCollection InicializarConfiguracionApp(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
        services.AddDistributedCache();
        services.ConfigureDataProtectionProvider(configuration);


        services.AddBusinessServices();
        services.AddDataAccessService(configuration);

        return services;
    }

    public static IServiceCollection ConfigureDataProtectionProvider(this IServiceCollection services, IConfiguration configuration)
    {
        var keysFolder = configuration["keysFolder"]!;
        services.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(keysFolder))
            .SetApplicationName("Aplicacion.WebApi");
        return services;
    }
}
