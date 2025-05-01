using Api.Models;

namespace Api.Services;

public interface IWeatherService
{
    Task<WeatherResponse> GetWeatherAsync(string city);
}
public class OpenWeatherService : IWeatherService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiKey;

    public OpenWeatherService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _apiKey = configuration["OpenWeatherApiKey"];
    }

    public async Task<WeatherResponse> GetWeatherAsync(string city)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetFromJsonAsync<WeatherApiResponse>($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric");
        if (response == null) return null;

        return new WeatherResponse
        {
            City = response.Name,
            Temperature = response.Main.Temp,
            Condition = response.Weather[0].Description
        };
    }

    private class WeatherApiResponse
    {
        public string Name { get; set; }
        public MainData Main { get; set; }
        public WeatherData[] Weather { get; set; }
    }

    private class MainData
    {
        public double Temp { get; set; }
    }

    private class WeatherData
    {
        public string Description { get; set; }
    }
}