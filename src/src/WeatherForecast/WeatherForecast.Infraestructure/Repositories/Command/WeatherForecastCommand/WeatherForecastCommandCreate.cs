using WeatherForecast.Interfaces.Infraestructure.Command.WeatherForecastCommandContracts;
using Infraestructure.MongoDatabase.MongoDbEntities;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using WeatherForecast.Domain.Application.WeatherForecast.ComandCreate;
using WeatherForecast.Infraestructure.MapperProfiles.WeatherForecastProfiles;
using DistributedCacheCleanArchitecture;
using MediatR;

namespace WeatherForecast.Infraestructure.Repositories.Command.WeatherForecastCommand;

public class WeatherForecastCommandCreate(MongoClient mongoClient,
    IDistributedCleanArchitectureCache distributedCache, ILogger<WeatherForecastCommandCreate> logger, IMediator mediator) 
: IWeatherForecastCommandCreateContract
{
    private readonly WeatherForecastCommandCreateMapper weatherCommandMapper = new();

    public async Task<int> ExecuteAsync(WeatherForecastCommandCreateRequest weather, CancellationToken cancellationToken = default)
    {
        var weatherForecast = weatherCommandMapper.WeatherRequestToEntity(weather);

        weatherForecast.Date = DateTime.Now;

        var collection = mongoClient.GetDatabase("CleanArchitecture")
            .GetCollection<WeatherForecastEntity>("WeatherForecast");

        await collection.InsertOneAsync(weatherForecast, new InsertOneOptions { }, cancellationToken);

        logger.LogInformation("Guardando los datos en BBDD: {@datos}", weatherForecast);

        await distributedCache.RemoveAsync("WeatherForecasts", cancellationToken);

        _ = mediator.Publish(new WeatherForecastSyncRequest(), cancellationToken);
        logger.LogInformation("Evento de creacion de WeatherForecast ejecutado");

        return 1;
    }
}
