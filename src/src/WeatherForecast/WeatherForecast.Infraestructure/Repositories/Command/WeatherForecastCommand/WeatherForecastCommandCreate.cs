﻿using System.Text.Json;
using WeatherForecast.Interfaces.Infraestructure.Command.WeatherForecastCommandContracts;
using AutoMapper;
using Infraestructure.MongoDatabase.MongoDbEntities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using WeatherForecast.Domain.Application.WeatherForecast.ComandCreate;

namespace WeatherForecast.Infraestructure.Repositories.Command.WeatherForecastCommand;

public class WeatherForecastCommandCreate : IWeatherForecastCommandCreateContract
{
    private readonly MongoClient _mongoClient;
    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<WeatherForecastCommandCreate> _logger;
    private readonly IMapper _mapper;

    public WeatherForecastCommandCreate(MongoClient mongoClient, IDistributedCache distributedCache, ILogger<WeatherForecastCommandCreate> logger, IMapper mapper)
    {
        _mongoClient = mongoClient;
        _distributedCache = distributedCache;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<int> ExecuteAsync(WeatherForecastCommandCreateRequest weather, CancellationToken cancellationToken = default)
    {
        var weatherForecast = _mapper.Map<WeatherForecastEntity>(weather);

        weatherForecast.Date = DateTime.Now;

        var collection = _mongoClient.GetDatabase("CleanArchitecture")
            .GetCollection<WeatherForecastEntity>("WeatherForecast");

        await collection.InsertOneAsync(weatherForecast, new InsertOneOptions { }, cancellationToken);

        _logger.LogInformation("Guardando los datos en BBDD: {datos}", JsonSerializer.Serialize(weatherForecast));

        await _distributedCache.RemoveAsync("WeatherForecasts", cancellationToken);

        return 1;
    }
}
