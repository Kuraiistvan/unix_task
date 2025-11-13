using System;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("profile")]
public class ProfileController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProfile()
    {
        var username = HttpContext.Items["Username"]?.ToString();
        if (username == null)
            return Unauthorized(new { message = "Token missing or invalid" });

        return Ok(new { message = $"Welcome, {username}!" });
    }
}
