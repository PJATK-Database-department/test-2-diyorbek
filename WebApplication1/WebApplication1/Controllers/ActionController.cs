using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ActionController : ControllerBase
{
    private readonly ILogger<ActionController> _logger;

    public ActionController(ILogger<ActionController>logger )
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}