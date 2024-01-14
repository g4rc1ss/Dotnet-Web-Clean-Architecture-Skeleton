using WeatherForecast.Interfaces.ApplicationCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Shared.Peticiones.Responses.WeatherForecast;
using WeatherForecast.Shared.Peticiones.Request;
using WeatherForecast.Domain.Application.WeatherForecast.ComandCreate;
using Microsoft.Extensions.Logging;

namespace WeatherForecast.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(IMapper mapper, ICreateWeatherForecastContract createWeatherForecast, IGetAllWeatherForecastContract getAllWeatherForecast, ILogger<WeatherForecastController> logger)
: Controller
{
    [HttpGet("all")]
    public async Task<IActionResult> GetWeatherForecast()
    {
        var weatherForecast = await getAllWeatherForecast.ExecuteAsync();
        var weatherResponse = mapper.Map<IEnumerable<WeatherForecastResponse>>(weatherForecast);
        logger.LogInformation("Respuesta de consulta all weather {@weatherForecast}", weatherForecast);
        
        return Json(weatherResponse);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateWeatherForecast(CreateWeatherForecastRequest weatherForecast)
    {
        var newWeather = mapper.Map<WeatherForecastCommandCreateRequest>(weatherForecast);
        var createWeather = await createWeatherForecast.ExecuteAsync(newWeather);
        logger.LogInformation("Respuesta de create weather {@createWeather}", createWeather);

        return Json(createWeather);
    }
}
