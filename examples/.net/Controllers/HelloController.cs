using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController(ILogger<WeatherForecastController> _logger) : ControllerBase
    {
        [HttpGet()]
        public string Get()
        {
            return "Hello Jenkins 2: Test ===>" + Environment.GetEnvironmentVariable("TEST_ENV");
        }
    }
}
