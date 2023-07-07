using Application.Interfaces.ApplicationCore;
using AutoMapper;
using Domain.Application.WeatherForecast.ComandCreate;
using Microsoft.AspNetCore.Mvc;
using Shared.Peticiones.Request;
using Shared.Peticiones.Responses.WeatherForecast;

namespace HostWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICreateWeatherForecastContract _createWeatherForecast;
        private readonly IGetAllWeatherForecastContract _getAllWeatherForecast;

        public WeatherForecastController(IMapper mapper, ICreateWeatherForecastContract createWeatherForecast, IGetAllWeatherForecastContract getAllWeatherForecast)
        {
            _mapper = mapper;
            _createWeatherForecast = createWeatherForecast;
            _getAllWeatherForecast = getAllWeatherForecast;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetWeatherForecast()
        {
            var weatherForecast = await _getAllWeatherForecast.ExecuteAsync();
            return Json(_mapper.Map<IEnumerable<WeatherForecastResponse>>(weatherForecast));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateWeatherForecast(CreateWeatherForecastRequest weatherForecast)
        {
            var newWeather = _mapper.Map<WeatherForecastCommandCreateRequest>(weatherForecast);
            var createWeather = await _createWeatherForecast.ExecuteAsync(newWeather);

            return Json(createWeather);
        }
    }
}
