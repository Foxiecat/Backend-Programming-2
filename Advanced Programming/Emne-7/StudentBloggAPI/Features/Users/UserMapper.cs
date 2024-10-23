using StudentBloggAPI.Features.Common.Interfaces;

namespace StudentBloggAPI.Features.Users;

public class UserMapper : IMapper<User, UserDTO>
{
    public UserDTO MapToDTO(User model)
    {
        return new UserDTO()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.UserName,
            Email = model.Email,
            Created = model.Created,
            Updated = model.Updated,
        };
    }

    public User MapToModel(UserDTO dto)
    {
        return new User()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            UserName = dto.UserName,
            Email = dto.Email,
            Created = dto.Created,
            Updated = dto.Updated,
            // HashedPassword => registrerings process -> da blir denne satt
            // IsAdminUser => ved innlogging -> httpcontext som vi senere kan bruke !
        };
    }
}