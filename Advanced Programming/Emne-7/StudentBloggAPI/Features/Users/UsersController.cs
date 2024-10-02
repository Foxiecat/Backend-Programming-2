using Microsoft.AspNetCore.Mvc;
using StudentBloggAPI.Features.Users.Interfaces;

namespace StudentBloggAPI.Features.Users;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IUserService _userService;

    // henter logger fra DI-Container, gjøres alltid i konstruktøren 
    public UsersController(ILogger<UsersController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }
    
    [HttpGet("hello", Name = "SayHello")]
    public async Task<ActionResult<string>> SayHello()
    {
        _logger.LogInformation("Hello from API");
        await Task.Delay(20);
        return Ok("hello from API");
    }
    
    [HttpGet(Name = "GetUsers")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersAsync(
        [FromQuery] UserSearchParameters? searchParameters,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
            
        if (searchParameters.UserName is null &&
            searchParameters.FirstName is null &&
            searchParameters.LastName is null &&
            searchParameters.Email is null)
        {
            IEnumerable<UserDTO> userDtos = await _userService.GetPagedAsync(pageNumber, pageSize);
            return Ok(userDtos);
        }
        
        return Ok(await _userService.FindAsync(searchParameters));
    }
    
    [HttpGet("{id}", Name = "GetUserByIdAsync")]
    public async Task<ActionResult<UserDTO>> GetUserByIdAsync(Guid id)
    {
        UserDTO? userDto = await _userService.GetByIdAsync(id);
        return userDto is null
            ? BadRequest("User not found")
            : Ok(userDto);
    }
    
    //  dotnet add package Microsoft.EntityFrameworkCore --version 8.0.8
    // https:localhost:7004/api/users/register
    [HttpPost("register", Name = "RegisterUserAsync")]
    public async Task<ActionResult<UserDTO>> RegisterUserAsync(UserRegistrationDTO registrationDTO)
    {
        var user = await _userService.RegisterAsync(registrationDTO);
        return user is null
            ? BadRequest("User not registered")
            : Ok(user);
    }
    
    //public async Task<ActionResult<UserDTO>> FindAsync()
}