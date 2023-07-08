using AutoMapper;
using Infraestructure.MongoDatabase.MongoDbEntities;
using WeatherForecast.Domain.Application.WeatherForecast.ComandCreate;

namespace WeatherForecast.Infraestructure.MapperProfiles.WeatherForecastProfiles;

public class WeatherForecastCommandCreateMapper : Profile
{
    public WeatherForecastCommandCreateMapper()
    {
        CreateMap<WeatherForecastCommandCreateRequest, WeatherForecastEntity>();
    }
}
