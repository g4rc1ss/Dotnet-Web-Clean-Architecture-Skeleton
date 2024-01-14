using Infraestructure.MongoDatabase.MongoDbEntities;
using Riok.Mapperly.Abstractions;
using WeatherForecast.Domain.Application.WeatherForecast.ComandCreate;

namespace WeatherForecast.Infraestructure.MapperProfiles.WeatherForecastProfiles;

[Mapper]
public partial class WeatherForecastCommandCreateMapper
{
    public partial WeatherForecastEntity WeatherRequestToEntity(WeatherForecastCommandCreateRequest weatherForecastCommandCreate);
}
