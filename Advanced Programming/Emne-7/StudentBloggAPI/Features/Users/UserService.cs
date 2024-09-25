using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using StudentBloggAPI.Features.Common.Interfaces;
using StudentBloggAPI.Features.Users.Interfaces;

namespace StudentBloggAPI.Features.Users;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IMapper<User,UserDTO> _userMapper;

    public UserService(ILogger<UserService> logger, IMapper<User, UserDTO> userMapper)
    {
        _logger = logger;
        _userMapper = userMapper;
    }
    
    /*public async Task<IEnumerable<UserDTO>?> GetAllUsersAsync()
    {
        await Task.Delay(20);

        User model = new()
            {
                Id = Guid.NewGuid(),
                UserName = "Ola",
                FirstName = "Ola",
                LastName = "Normann",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Email = "ola@gmail.com",
            };

        // MAPPING -> FRA User -> UserDTO
        UserDTO dto = _userMapper.MapToDTO(model);
        
        // Legg i liste og return til controller
        return new List<UserDTO>() { dto };
    }*/
    public Task<UserDTO?> AddAsync(UserDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO?> UpdateAsync(UserDTO entity)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO?> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserDTO>> GetPagedAsync(int pageNumber, int pageSize)
    {
        await Task.Delay(20);

        User model = new()
        {
            Id = Guid.NewGuid(),
            UserName = "Ola",
            FirstName = "Ola",
            LastName = "Normann",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Email = "ola@gmail.com",
            HashedPassword = "Squeak-Pox1-Strut",
            IsAdmin = true
        };

        // MAPPING -> FRA User -> UserDTO
        UserDTO dto = _userMapper.MapToDTO(model);
        
        // Legg i liste og return til controller
        return new List<UserDTO>() { dto };
    }

    public Task<IEnumerable<UserDTO>> FindAsync(Expression<Func<UserDTO, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDTO>?> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }
}