using Application.Interfaces.Infraestructure.Command.WeatherForecastCommandContracts;
using Application.Interfaces.Infraestructure.Query.WeatherForecastQueryContracts;
using Infraestructure.DataAccess.Repositories.Command.WeatherForecastCommand;
using Infraestructure.MongoDatabase;
using Infraestructure.DataAccess.Repositories.Query.WeatherForecastQueries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherForecast.Infraestructure;

public static class WeatherForecastInfraestructureExtensions
{
    public static IServiceCollection AddDataAccessService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMongoDbConfig(configuration);
        services.AddRepositoryServices();

        return services;
    }

    private static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastQueryAllContract, WeatherForecastQueryAll>();
        services.AddScoped<IWeatherForecastCommandCreateContract, WeatherForecastCommandCreate>();

        return services;
    }
}