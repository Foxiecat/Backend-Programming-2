using Microsoft.AspNetCore.Mvc;
using StudentBloggAPI.Features.Users.Interfaces;

namespace StudentBloggAPI.Features.Users;


[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUserService _userService;

    // Henter logger fra DI-Container, gjøres alltid i konstructoren
    public UsersController(ILogger<UsersController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }
    
    [HttpGet("hello", Name = "SayHello")]
    public async Task<ActionResult<string>> SayHello()
    {
        _logger.LogInformation("SayHello");
        
        await Task.Delay(20);
        return Ok("Hello from API");
    }
    
    [HttpGet(Name = "GetUser")]
    public async Task<ActionResult<IEnumerable<UserDTO[]>>> GetUsersAsync()
    {
        IEnumerable<UserDTO> userDTOS = await _userService.GetPagedAsync(0, 0);
        
        return userDTOS.Any()
            ? BadRequest("No users found!")
            : Ok(userDTOS);
    }
}