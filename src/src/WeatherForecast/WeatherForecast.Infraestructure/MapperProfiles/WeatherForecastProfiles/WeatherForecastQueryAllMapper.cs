using Infraestructure.MongoDatabase.MongoDbEntities;

using Riok.Mapperly.Abstractions;

using WeatherForecast.Domain.Application.WeatherForecast.QueryAll;

namespace WeatherForecast.Infraestructure.MapperProfiles.WeatherForecastProfiles;

[Mapper]
public partial class WeatherForecastQueryAllMapper
{
    [MapProperty(nameof(@WeatherForecastEntity.Summary), nameof(WeatherForecastQueryAllResponse.Summary))]
    [MapProperty(nameof(@WeatherForecastEntity.TemperatureC), nameof(WeatherForecastQueryAllResponse.TemperatureC))]
    [MapProperty(nameof(@WeatherForecastEntity.TemperatureF), nameof(WeatherForecastQueryAllResponse.TemperatureF))]
    [MapperIgnoreTarget(nameof(@WeatherForecastEntity.Date))]
    public partial WeatherForecastQueryAllResponse WeatherForecastEntityToQueryAll(WeatherForecastEntity weatherForecastEntity);
}
