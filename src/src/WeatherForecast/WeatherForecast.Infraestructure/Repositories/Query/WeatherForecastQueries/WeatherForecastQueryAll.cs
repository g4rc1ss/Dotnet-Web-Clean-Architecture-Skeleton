using System.Text.Json;
using WeatherForecast.Interfaces.Infraestructure.Query.WeatherForecastQueryContracts;
using AutoMapper;
using Infraestructure.MongoDatabase.MongoDbEntities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using WeatherForecast.Domain.Application.WeatherForecast.QueryAll;

namespace WeatherForecast.Infraestructure.Repositories.Query.WeatherForecastQueries;

internal class WeatherForecastQueryAll(ILogger<WeatherForecastQueryAll> logger, IMapper mapper, IDistributedCache distributedCache, MongoClient mongoClient) : IWeatherForecastQueryAllContract
{
    public async Task<List<WeatherForecastQueryAllResponse>> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        var weatherList = new List<WeatherForecastQueryAllResponse>();
        var cacheWeatherList = await distributedCache.GetStringAsync("WeatherForecasts", cancellationToken);

        if (string.IsNullOrEmpty(cacheWeatherList))
        {
            var collection = mongoClient.GetDatabase("CleanArchitecture")
                .GetCollection<WeatherForecastEntity>("WeatherForecast");
            var find = await collection.FindAsync(FilterDefinition<WeatherForecastEntity>.Empty, cancellationToken: cancellationToken);
            var weathers = await find.ToListAsync(cancellationToken: cancellationToken);

            weatherList = mapper.Map<List<WeatherForecastQueryAllResponse>>(weathers);
            cacheWeatherList = JsonSerializer.Serialize(weatherList);
            await distributedCache.SetStringAsync("WeatherForecasts", cacheWeatherList, cancellationToken);
        }
        else
        {
            weatherList = JsonSerializer.Deserialize<List<WeatherForecastQueryAllResponse>>(cacheWeatherList);
        }
        logger.LogInformation("Devolviendo los datos: {@datos}", weatherList);
        return weatherList!;
    }
}
