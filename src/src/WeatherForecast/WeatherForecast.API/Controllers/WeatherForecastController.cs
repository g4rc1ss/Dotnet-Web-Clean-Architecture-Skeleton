using WeatherForecast.Interfaces.ApplicationCore;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Shared.Peticiones.Request;
using Microsoft.Extensions.Logging;
using WeatherForecast.API.MapperProfiles.WeatherForecast;

namespace WeatherForecast.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ICreateWeatherForecastContract createWeatherForecast, IGetAllWeatherForecastContract getAllWeatherForecast, ILogger<WeatherForecastController> logger)
: Controller
{
    private readonly WeatherForecastCreateMapper _weatherForecastCreateMapper = new();
    private readonly WeatherForecastQueryMapper _weatherForecastQueryMapper = new();

    [HttpGet("all")]
    public async Task<IActionResult> GetWeatherForecast()
    {
        var weatherForecast = await getAllWeatherForecast.ExecuteAsync();
        var weatherResponse = weatherForecast.Select(_weatherForecastQueryMapper.WeatherForecastQueryAllToResponse);
        logger.LogInformation("Respuesta de consulta all weather {@weatherForecast}", weatherForecast);

        return Json(weatherResponse);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateWeatherForecast(CreateWeatherForecastRequest weatherForecast)
    {
        var newWeather = _weatherForecastCreateMapper.WeatherForecastRequestToCommandRequest(weatherForecast);
        var createWeather = await createWeatherForecast.ExecuteAsync(newWeather);
        logger.LogInformation("Respuesta de create weather {@createWeather}", createWeather);

        return Json(createWeather);
    }
}
