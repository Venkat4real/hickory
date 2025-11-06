using Microsoft.AspNetCore.Mvc;

namespace Hickory.Api.Controllers;

/// <summary>
/// Provides weather forecast data.
/// </summary>


[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    
    /// <summary>
    /// **Gets a random five-day weather forecast.**
    /// </summary>
    
    /// <remarks>
    /// This endpoint returns simulated weather data for the next five days, 
    /// </remarks>
    
    /// <returns>
    /// **A list of WeatherForecast objects** containing temperature and summary data.
    /// </returns>
}

