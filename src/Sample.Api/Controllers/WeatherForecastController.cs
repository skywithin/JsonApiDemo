using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.Api.Models;
using Sample.Data;

namespace Sample.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly AppDbContext _dbContext;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecastDto>> Get()
    {
        var person = await _dbContext.People.Where(x => x.FirstName != null).ToListAsync();

        var forecasts =
            Enumerable
                .Range(1, 5)
                .Select(index => 
                    new WeatherForecastDto
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = person.FirstOrDefault()?.FirstName,
                    })
                .ToArray();

        return forecasts;
    }

}
