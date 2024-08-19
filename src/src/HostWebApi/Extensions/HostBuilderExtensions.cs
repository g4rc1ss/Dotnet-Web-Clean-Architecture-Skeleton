using OpenTelemetry.Resources;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Events;
using OpenTelemetry.Exporter;
using Microsoft.Extensions.Caching.Distributed;
using WeatherForecast.Infraestructure.Events.WeatherForecastSyncConsumer;

namespace HostWebApi.Extensions;

public static class HostBuilderExtensions
{

    internal static IHostBuilder AddLoggerConfiguration(this IHostBuilder hostBuilder, IConfiguration configuration)
    {
        hostBuilder.UseSerilog((context, loggerConfiguration) =>
        {
            loggerConfiguration
                .MinimumLevel.Information()
                .Enrich.WithProperty("Application", "HostWebApi")
                .WriteTo.OpenTelemetry(options => options.Endpoint = configuration["ConnectionStrings:OpenTelemetry"]!);

            if (context.HostingEnvironment.IsDevelopment())
            {
                loggerConfiguration.WriteTo.Console(LogEventLevel.Debug);
            };

        });
        return hostBuilder;
    }

    internal static IServiceCollection AddOpenTelemetry(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(configuration["AppName"]!))
            .WithTracing(trace =>
            {
                trace.AddSource(nameof(WeatherForecastSyncHandler));
                trace.AddAspNetCoreInstrumentation();
                trace.AddHttpClientInstrumentation();
                trace.AddSource("MongoDB.Driver.Core.Extensions.DiagnosticSources");
                trace.AddSource(nameof(IDistributedCache));
                trace.AddOtlpExporter(exporter => exporter.Endpoint = new Uri(configuration["ConnectionStrings:OpenTelemetry"]!));
            })
            .WithMetrics(metric =>
            {
                metric.AddMeter("HostWebApi");
                metric.AddAspNetCoreInstrumentation();
                metric.AddRuntimeInstrumentation();
                metric.AddHttpClientInstrumentation();
                metric.AddProcessInstrumentation();

                metric.AddOtlpExporter(exporter =>
                {
                    exporter.Endpoint = new Uri(configuration["ConnectionStrings:OpenTelemetry"]!);
                    exporter.Protocol = OtlpExportProtocol.Grpc;
                });
            });

        return services;
    }
}
