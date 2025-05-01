using Api.Managers;
using Api.Services;

namespace Api.Extensions;
public static class DependencyInjection
{
    public static void AddWeatherServices(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IWeatherService, OpenWeatherService>();
        services.AddScoped<WeatherManager>();
    }
}