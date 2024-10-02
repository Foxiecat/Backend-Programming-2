using System.Linq.Expressions;
using StudentBloggAPI.Features.Common.Interfaces;
using StudentBloggAPI.Features.Users.Interfaces;
using static BCrypt.Net.BCrypt;

namespace StudentBloggAPI.Features.Users;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IMapper<User, UserDTO> _userMapper;
    private readonly IMapper<User, UserRegistrationDTO> _userRegistrationMapper;
    private readonly IUserRepository _userRepository;


    public UserService(ILogger<UserService> logger, 
        IMapper<User, UserDTO> userMapper,
        IMapper<User, UserRegistrationDTO> registrationMapper,
        IUserRepository userRepository)
    {
        _logger = logger;
        _userMapper = userMapper;
        _userRepository = userRepository;
        _userRegistrationMapper = registrationMapper;
    }
    public async Task<UserDTO?> AddAsync(UserDTO dto)
    {
        User model = _userMapper.MapToModel(dto);
        User? modelResponse = await _userRepository.AddAsync(model);
        return modelResponse is null
            ? null
            : _userMapper.MapToDTO(modelResponse);
    }

    public Task<UserDTO?> UpdateAsync(UserDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO?> DeleteByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDTO?> GetByIdAsync(Guid id)
    {
        User? model = await _userRepository.GetByIdAsync(id);
        return model is null
            ? null
            : _userMapper.MapToDTO(model);
    }

    public async Task<IEnumerable<UserDTO>> GetPagedAsync(int pageNumber, int pageSize)
    {
        List<User> users = (await _userRepository.GetPagedAsync(pageNumber, pageSize)).ToList();
        
        return users
            .Select(user => _userMapper.MapToDTO(user))
            .ToList();
    }

    public async Task<UserDTO?> RegisterAsync(UserRegistrationDTO registerDTO)
    {
        User user = _userRegistrationMapper.MapToModel(registerDTO);
        user.Id = Guid.NewGuid();
        user.Created = DateTime.UtcNow;
        user.Updated = DateTime.UtcNow;
        user.IsAdminUser = false;
        
        // legger til hashed password
        user.HashedPassword = HashPassword(registerDTO.Password);
        
        // Legge til user i database
        User? addedUser = await _userRepository.AddAsync(user);

        // Return UserDTO
        return (addedUser is null
            ? null
            : _userMapper.MapToDTO(addedUser))!;
    }

    public Task<Guid> AuthenticateUserAsync(string user, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserDTO>> FindAsync(UserSearchParameters searchParameters)
    {
        // Bygge opp predicate dynamisk
        Expression<Func<User, bool>> predicate = user =>
            (string.IsNullOrEmpty(searchParameters.UserName) || user.UserName.Contains(searchParameters.UserName)) &&
            (string.IsNullOrEmpty(searchParameters.FirstName) || user.FirstName.Contains(searchParameters.FirstName)) &&
            (string.IsNullOrEmpty(searchParameters.LastName) || user.LastName.Contains(searchParameters.LastName)) &&
            (string.IsNullOrEmpty(searchParameters.Email) || user.Email.Contains(searchParameters.Email));

        IEnumerable<User> users = await _userRepository.FindAsync(predicate);
        return users.Select(user => _userMapper.MapToDTO(user));
    }
}