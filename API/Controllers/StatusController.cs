using API.Controllers;
using API.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

public class StatusController : BaseApiController
{
    [HttpGet]
    public IActionResult GetStatus()
    {
        return Ok(new
        {
            status = "OK",
            timestamp = DateTime.UtcNow
        });
    }

    [HttpGet("unauthorized")]
    public IActionResult GetUnauthorized()
    {
        return Unauthorized();
    }

    [HttpGet("badrequest")]
    public IActionResult GetBadRequest()
    {
        return BadRequest();
    }

    [HttpGet("notfound")]
    public IActionResult GetNotFound()
    {
        return NotFound();
    }

    [HttpGet("internalerror")]
    public IActionResult GetInternalError()
    {
        throw new Exception("Internal error");
    }
    
    [HttpPost("validationerror")]
    public IActionResult GetValidationError(ProductDto product)
    {
        return Ok();
    }
}