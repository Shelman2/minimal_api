using Api.Managers;

namespace Api.Extensions;
public static class RouteBuilderExtension
{
    public static void MapWeatherRoutes(this WebApplication app)
    {
        var weatherApi = app.MapGroup("/weather");
        weatherApi.MapGet("/{city}", async (string city, WeatherManager weatherManager) =>
            await weatherManager.GetWeather(city));
    }
}