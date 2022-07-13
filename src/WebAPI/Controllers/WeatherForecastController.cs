using Application.WeatherService.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ISender _mediator;

        public WeatherForecastController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetWeatherForecast")]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get(GetWeatherForecast request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}