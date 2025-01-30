using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthzController : ControllerBase
    {
        [HttpGet()]
        public string Get()
        {
            return "Oke";
        }
    }
}
