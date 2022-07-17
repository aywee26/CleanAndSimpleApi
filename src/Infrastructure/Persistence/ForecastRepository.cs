using Application.Common.Interfaces.Persistence;
using Domain;

namespace Infrastructure.Persistence;

public class ForecastRepository : IForecastRepository
{
    private static readonly string[] _summaries = new[]
    {
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching"
    };

    public IEnumerable<WeatherForecast> GetWeatherForecast()
    {
        for (int i = 1; i <= 5; i++)
        {
            var result = new WeatherForecast
            {
                Date = DateTime.Now.AddDays(i),
                TemperatureC = Random.Shared.Next(-20, 30),
                Summary = _summaries[Random.Shared.Next(_summaries.Length)]                
            };

            yield return result;
        }
    }
}
