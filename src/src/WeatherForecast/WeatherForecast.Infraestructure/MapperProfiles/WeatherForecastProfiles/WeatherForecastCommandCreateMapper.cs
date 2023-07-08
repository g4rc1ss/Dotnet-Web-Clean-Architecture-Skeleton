using AutoMapper;
using Domain.Application.WeatherForecast.ComandCreate;
using Infraestructure.MongoDatabase.MongoDbEntities;

namespace Infraestructure.DataAccess.MapperProfiles.WeatherForecastProfiles
{
    public class WeatherForecastCommandCreateMapper : Profile
    {
        public WeatherForecastCommandCreateMapper()
        {
            CreateMap<WeatherForecastCommandCreateRequest, WeatherForecastEntity>();
        }
    }
}
