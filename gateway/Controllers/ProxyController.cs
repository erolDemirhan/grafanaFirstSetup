using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProxyController : ControllerBase
{
    private readonly HttpClient _client;

    public ProxyController(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient();
    }

    [HttpGet("python")]
    public async Task<IActionResult> FromPython()
    {
        var res = await _client.GetStringAsync("http://python-service:8000");
        return Ok(res);
    }

    [HttpGet("dotnet")]
    public async Task<IActionResult> FromDotnet()
    {
        var res = await _client.GetStringAsync("http://dotnet-service:80/");
        return Ok(res);
    }

    [HttpGet("python-hello")]
    public async Task<IActionResult> PythonHello()
    {
        try
        {
            var response = await _client.GetStringAsync("http://python-service:8000");
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception while calling python-service: {ex.Message}");
            return StatusCode(500, $"Proxy error: {ex.Message}");
        }
    }

    [HttpGet("dotnet-hello")]
    public async Task<IActionResult> DotnetHello()
    {
        try
        {
            var response = await _client.GetStringAsync("http://dotnet-service:80/api/hello");
            return Ok(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception while calling dotnet-service: {ex.Message}");
            return StatusCode(500, $"Proxy error: {ex.Message}");
        }
    }


}
