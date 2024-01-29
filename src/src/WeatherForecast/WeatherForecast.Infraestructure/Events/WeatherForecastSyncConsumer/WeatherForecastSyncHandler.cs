using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace WeatherForecast.Infraestructure;

public class WeatherForecastSyncHandler(ILogger<WeatherForecastSyncHandler> logger)
: INotificationHandler<WeatherForecastSyncRequest>
{
    private ActivitySource activitySource = new(nameof(WeatherForecastSyncHandler));
    public async Task Handle(WeatherForecastSyncRequest notification, CancellationToken cancellationToken)
    {
        using var activity = activitySource.StartActivity("Ejecucion del Handler", ActivityKind.Consumer);
        logger.LogInformation("Ejecutando handler @{HandlerName}", nameof(WeatherForecastSyncHandler));        
        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);

        activity?.SetStatus(ActivityStatusCode.Ok);
    }
}
