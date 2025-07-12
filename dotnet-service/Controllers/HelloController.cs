using Microsoft.AspNetCore.Mvc;

namespace DotnetService.Controllers;

[ApiController]
[Route("api/hello")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello from .NET!");
    }
}


