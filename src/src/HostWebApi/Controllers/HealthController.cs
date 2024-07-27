using Microsoft.AspNetCore.Mvc;

namespace HostWebApi;

[ApiController]
public class HealthController : Controller
{

    public HealthController()
    {
    }

    [HttpGet("/health")]
    public IActionResult Health()
    {
        return Ok("healthy PRO");
    }

}
