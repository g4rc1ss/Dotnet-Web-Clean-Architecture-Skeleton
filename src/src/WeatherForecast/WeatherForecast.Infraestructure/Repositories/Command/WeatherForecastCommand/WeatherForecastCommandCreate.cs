using WeatherForecast.Interfaces.Infraestructure.Command.WeatherForecastCommandContracts;
using Infraestructure.MongoDatabase.MongoDbEntities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using WeatherForecast.Domain.Application.WeatherForecast.ComandCreate;
using WeatherForecast.Infraestructure.MapperProfiles.WeatherForecastProfiles;

namespace WeatherForecast.Infraestructure.Repositories.Command.WeatherForecastCommand;

public class WeatherForecastCommandCreate(MongoClient mongoClient, IDistributedCache distributedCache, ILogger<WeatherForecastCommandCreate> logger) 
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

        return 1;
    }
}
