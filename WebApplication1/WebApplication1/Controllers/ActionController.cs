using Microsoft.AspNetCore.Mvc;
using WebApplication1.Errors;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ActionController : ControllerBase
{
    private readonly IActionService _service;

    public ActionController(IActionService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("{idAction:int}")]
    public async Task<IActionResult> Get([FromRoute] int idAction)
    {
        try
        {
            var result = await _service.GetAction(idAction);

            return Ok(result);
        }
        catch (NotFoundError e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete]
    [Route("{idAction:int}")]
    public async Task<IActionResult> Delete([FromRoute] int idAction)
    {
        try
        {
            var deletedActionId = await _service.DeleteAction(idAction);

            return Ok(deletedActionId);
        }
        catch (NotFoundError e)
        {
            return NotFound(e.Message);
        }
        catch (CompletedActionError e)
        {
            return NotFound(e.Message);
        }
    }
}