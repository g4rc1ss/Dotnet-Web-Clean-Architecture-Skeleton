using HostWebApi.Extensions;
using MongoDB.Driver;
using User.API;
using WeatherForecast.API;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddLoggerConfiguration(builder.Configuration);
builder.Services.AddOpenTelemetry(builder.Configuration);

// Add services to the container.
builder.Services.InicializarConfiguracionApp(builder.Configuration);
builder.Services.AddProblemDetails();


builder.Services.AddControllers()
    .AddApplicationPart(typeof(WeatherForecastApiExtensions).Assembly)
    .AddApplicationPart(typeof(UserApiExtensions).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseHttpLogging();

app.MapControllers();

Console.WriteLine(app.Configuration["AppName"]!);

await app.RunAsync();

public partial class Program { }
