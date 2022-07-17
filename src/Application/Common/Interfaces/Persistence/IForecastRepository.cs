using Domain;

namespace Application.Common.Interfaces.Persistence;

public interface IForecastRepository
{
    IEnumerable<WeatherForecast> GetWeatherForecast();
}
