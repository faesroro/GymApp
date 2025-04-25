using System;
using Microsoft.AspNetCore.Mvc;
using GymApp.Auth.DTOs;
using GymApp.Auth.Services;

namespace GymApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var user = await _authService.RegisterAsync(request);
        if (user == null)
            return BadRequest("El usuario ya existe.");
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _authService.LoginAsync(request);
        if (user == null)
            return Unauthorized();
        return Ok(user);
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _authService.GetAllAsync();
        return Ok(users);
    }

}
