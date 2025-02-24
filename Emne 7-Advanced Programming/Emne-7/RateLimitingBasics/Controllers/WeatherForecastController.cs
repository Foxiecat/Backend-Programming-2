using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace RateLimitingBasics.Controllers;

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
    
    [EnableRateLimiting("fixed")]
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

    [HttpGet("roles", Name = "GetUserAndRoles")]
    public ActionResult<IEnumerable<string>> GetUserAndRoles()
    {
        List<string> results = [];
        if (HttpContext.Items.ContainsKey("UserId"))
        {
            if (HttpContext.Items["UserId"] is string userId)
                results.Add(userId);
        }
        
        if (HttpContext.Items.ContainsKey("Roles"))
        {
            if (HttpContext.Items["Roles"] is IEnumerable<string> roles)
                results.AddRange(roles);
        }

        return Ok(results);
    }
}