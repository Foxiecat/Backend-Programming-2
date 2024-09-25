using StudentBloggAPI.Features.Common.Interfaces;

namespace StudentBloggAPI.Features.Users;

public class UserMapper : IMapper<User, UserDTO>
{
    public UserDTO MapToDTO(User model)
    {
        return new UserDTO()
        {
            Id = model.Id,
            UserName = model.UserName,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt
        };
    }

    public User MapToModel(UserDTO entityDTO)
    {
        return new User()
        {
            Id = entityDTO.Id,
            UserName = entityDTO.UserName,
            FirstName = entityDTO.FirstName,
            LastName = entityDTO.LastName,
            Email = entityDTO.Email,
            CreatedAt = entityDTO.CreatedAt,
            UpdatedAt = entityDTO.UpdatedAt
            // HashedPassword => registrerings process -> da blir denne satt
            // IsAdmin => ved innlogging -> httpcontext som vi senere kan bruke
        };
    }
}