using Domain;
using MediatR;

namespace Application.WeatherService.Queries;

public record GetWeatherForecast() : IRequest<IEnumerable<WeatherForecast>>
{
    public class Handler : IRequestHandler<GetWeatherForecast, IEnumerable<WeatherForecast>>
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

        public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecast request, CancellationToken cancellationToken)
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
            return result;
        }
    }
}
