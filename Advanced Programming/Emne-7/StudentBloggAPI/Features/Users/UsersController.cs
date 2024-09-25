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

   [HttpGet("{id}", Name = "GetUserById")]
    public async Task<ActionResult<UserDTO>> GetUserByIdAsync(Guid id)
    {
        UserDTO? userDtos = await _userService.GetByIdAsync(id);
        return userDtos is null
            ? BadRequest("No users found")
            : Ok(userDtos);
    }

    [HttpPost(Name = "AddUser")]
    public async Task<ActionResult<UserDTO>> AddUserAsync(UserDTO userDTO)
    {
        UserDTO? dtoResponse = await _userService.AddAsync(userDTO);
        
        return dtoResponse is null
            ? BadRequest("Failed to add User")
            : Ok(dtoResponse);
    }
}