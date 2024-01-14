using System.Net.Http.Json;
using FluentAssertions;
using WeatherForecast.Shared.Peticiones.Request;
using WeatherForecast.Shared.Peticiones.Responses.WeatherForecast;
using Xunit;

namespace WeatherForecast.IntegrationTest.ControllersTest;

[Collection(FixtureWeatherForecastNamesConstants.WeatherForecastTest)]
public class WeatherForecastControllerTest(TestApiConnectionInitializer apiConnection)
{
    [Fact]
    public async Task GetWeatherForecastByAPI_Then_ReturnJsonAndDeserialiceToIEnumerable_NotNullAndOneOrMoreResults()
    {

        var client = apiConnection.ApiClient;
        var response = await client.GetFromJsonAsync<IEnumerable<WeatherForecastResponse>>("WeatherForecast/all");
        response.Should().NotBeNull();

        foreach (var item in response!)
        {
            item.Should().NotBeNull();
        }
    }

    [Fact]
    public async Task CreateWeatherForecastByAPI_Then_ReturnJsonAndDeserialiceToIEnumerable_NotNullAndOneOrMoreResults()
    {

        var client = apiConnection.ApiClient;
        var weather = new CreateWeatherForecastRequest
        {
            Celsius = 1,
            Fahrenheit = 2,
            Descripcion = "Grados en Bilbao"
        };
        var response = await client.PostAsJsonAsync("WeatherForecast/create", weather);
        response.Should().Match(x => x.IsSuccessStatusCode);
    }
}
