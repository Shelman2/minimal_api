using Api.Managers;
using Api.Models;
using Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace Tests;

public class WeatherManagerTests
{
    [Fact]
    public async Task GetWeather_ReturnsOkResult_WhenCityExists()
    {
        // Arrange: simulate a successful service response
        var mockService = new Mock<IWeatherService>();
        var expected = new WeatherResponse
        {
            City = "Boston",
            Temperature = 20,
            Condition = "Clear"
        };

        mockService.Setup(s => s.GetWeatherAsync("Boston")).ReturnsAsync(expected);

        var manager = new WeatherManager(mockService.Object);

        // Act: call the method with a known city
        var result = await manager.GetWeather("Boston");

        // Assert: the result should be a successful 200 OK with the expected WeatherResponse
        result.Should().BeOfType<Ok<WeatherResponse>>();
        var okResult = result as Ok<WeatherResponse>;
        okResult!.Value.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetWeather_ReturnsNotFound_WhenCityIsMissing()
    {
        // Arrange
        var mockService = new Mock<IWeatherService>();
        mockService.Setup(s => s.GetWeatherAsync("Atlantis")).ReturnsAsync((WeatherResponse)null);

        var manager = new WeatherManager(mockService.Object);

        // Act
        var result = await manager.GetWeather("Atlantis");

        // Assert: confirm it returns a NotFound<T> result, indicating the city wasn't found
        result.Should().BeAssignableTo<IResult>();
        result.GetType().GetGenericTypeDefinition().Should().Be(typeof(NotFound<>));
    }
}
