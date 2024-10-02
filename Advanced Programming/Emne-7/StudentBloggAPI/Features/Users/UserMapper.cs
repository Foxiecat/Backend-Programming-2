using StudentBloggAPI.Features.Common.Interfaces;

namespace StudentBloggAPI.Features.Users;

public class UserMapper : IMapper<User, UserDTO>
{
    public UserDTO MapToDTO(User entity)
    {
        return new UserDTO
        {
            Id = entity.Id,
            Email = entity.Email,
            Created = entity.Created,
            Updated = entity.Created,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            UserName = entity.UserName
        };
    }

    public User MapToModel(UserDTO entityDTO)
    {
        return new User()
        {
            Created = entityDTO.Created,
            FirstName = entityDTO.FirstName,
            Email = entityDTO.Email,
            UserName = entityDTO.UserName,
            Updated = entityDTO.Updated,
            Id = entityDTO.Id,
            LastName = entityDTO.LastName
            // HashedPassword => registrerings process -> da blir denne satt
            // IsAdminUser => ved innlogging -> httpcontext som vi senere kan bruke !
        };
    }
}