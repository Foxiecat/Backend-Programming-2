using JWTAuthorization.Models.Interfaces;
using JWTAuthorization.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthorization.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class AuthenticationController(ITokenService tokenService) : ControllerBase
{
    [HttpGet("Login")]
    public async Task<ActionResult<string>> Login(string username, string password)
    {
        IIdentityUser user = await tokenService.LoginAsync(username, password);
        string? token = await tokenService.GenerateJwtTokenAsync(user);
        
        return Ok(token);
    }
}