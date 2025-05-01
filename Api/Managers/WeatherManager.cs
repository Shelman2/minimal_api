using Api.Services;

namespace Api.Managers;

public class WeatherManager
{
    private readonly IWeatherService _weatherService;

    public WeatherManager(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<IResult> GetWeather(string city)
    {
        var response = await _weatherService.GetWeatherAsync(city);

        if (response == null)
            return Results.NotFound(new { Message = "City not found." });

        return Results.Ok(response);
    }
}