using System;
using Microsoft.AspNetCore.Mvc;

namespace User.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IHttpClientFactory httpClientFactory)
 : Controller
{

    [HttpGet("user")]
    public async Task<IActionResult> EndpointUser()
    {
        using var httpClient = httpClientFactory.CreateClient();
        var google = await httpClient.GetAsync("https://google.es");
        var response = await google.Content.ReadAsStreamAsync();
        return Ok(response.Length);
    }
}

