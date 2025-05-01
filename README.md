# Weather API (.NET Minimal API Example)

This project demonstrates how to structure a maintainable and testable HTTP API in .NET using the **Minimal API** pattern introduced in .NET 6+. It uses **dependency injection**, **route grouping**, **configuration**, and **xUnit tests with FluentAssertions**. The API integrates with the [OpenWeatherMap](https://openweathermap.org/api) service to return current weather information based on city name.

## Features

- Clean separation of concerns using services and managers
- Static route registration via extension methods
- Swagger UI enabled in development mode
- Unit tested with xUnit, Moq, and FluentAssertions
- Configuration via `appsettings.json`

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- An [OpenWeatherMap API Key](https://openweathermap.org/api)

### Setup

```bash
git clone https://github.com/your-username/WeatherApi.git
cd WeatherApi

# Restore dependencies
dotnet restore

# Set your API key in the appsettings.json
cd Api
# Edit appsettings.json to include:
# {
#   "OpenWeatherApiKey": "your_actual_api_key_here"
# }
