using Microsoft.AspNetCore.Mvc;

namespace MRRS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "getMessage")]
    public async Task<string> GetMessage()
    {
        return "d";
    }
}