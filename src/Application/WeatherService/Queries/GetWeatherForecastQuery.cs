using Domain;
using MediatR;

namespace Application.WeatherService.Queries;

public record GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecast>>
{
    public class Handler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>
    {
        private static readonly string[] Summaries = new[]
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

        public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 30),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
            return result;
        }
    }
}
