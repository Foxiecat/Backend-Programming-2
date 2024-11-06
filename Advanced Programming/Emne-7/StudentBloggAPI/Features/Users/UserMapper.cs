using StudentBloggAPI.Features.Common.Interfaces;

namespace StudentBloggAPI.Features.Users;

public class UserMapper : IMapper<User, UserResponse>
{
    public UserResponse MapToDTO(User model)
    {
        return new UserResponse()
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

    public User MapToModel(UserResponse response)
    {
        return new User()
        {
            Id = response.Id,
            FirstName = response.FirstName,
            LastName = response.LastName,
            UserName = response.UserName,
            Email = response.Email,
            Created = response.Created,
            Updated = response.Updated,
            // HashedPassword => registrerings process -> da blir denne satt
            // IsAdminUser => ved innlogging -> httpcontext som vi senere kan bruke !
        };
    }
}