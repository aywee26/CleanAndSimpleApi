using Application.Common.Interfaces.Persistence;
using Domain;
using MediatR;

namespace Application.WeatherService.Queries;

public record GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecast>>
{
    public class Handler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>
    {
        private readonly IForecastRepository _forecastRepository;

        public Handler(IForecastRepository forecastRepository)
        {
            _forecastRepository = forecastRepository;
        }

        public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            return _forecastRepository.GetWeatherForecast();
        }
    }
}
