using WeatherForecast.Interfaces.Infraestructure.Command.WeatherForecastCommandContracts;
using WeatherForecast.Interfaces.Infraestructure.Query.WeatherForecastQueryContracts;
using Infraestructure.MongoDatabase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Infraestructure.Repositories.Query.WeatherForecastQueries;
using WeatherForecast.Infraestructure.Repositories.Command.WeatherForecastCommand;
using MediatR;

namespace WeatherForecast.Infraestructure;

public static class WeatherForecastInfraestructureExtensions
{
    public static IServiceCollection AddDataAccessService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMongoDbConfig(configuration);
        services.AddRepositoryServices();
        services.AddMediatR(typeof(WeatherForecastInfraestructureExtensions));

        return services;
    }

    private static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastQueryAllContract, WeatherForecastQueryAll>();
        services.AddScoped<IWeatherForecastCommandCreateContract, WeatherForecastCommandCreate>();

        return services;
    }
}
