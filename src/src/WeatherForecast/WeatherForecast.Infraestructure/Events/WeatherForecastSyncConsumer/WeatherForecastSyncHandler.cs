using System.Diagnostics;

using MediatR;

using Microsoft.Extensions.Logging;

namespace WeatherForecast.Infraestructure.Events.WeatherForecastSyncConsumer;

public class WeatherForecastSyncHandler(ILogger<WeatherForecastSyncHandler> logger)
: INotificationHandler<WeatherForecastSyncRequest>
{
    private readonly ActivitySource _activitySource = new(nameof(WeatherForecastSyncHandler));
    public async Task Handle(WeatherForecastSyncRequest notification, CancellationToken cancellationToken)
    {
        using var activity = _activitySource.StartActivity("Ejecucion del Handler", ActivityKind.Consumer);
        logger.LogInformation("Ejecutando handler @{HandlerName}", nameof(WeatherForecastSyncHandler));
        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);

        activity?.SetStatus(ActivityStatusCode.Ok);
    }
}
