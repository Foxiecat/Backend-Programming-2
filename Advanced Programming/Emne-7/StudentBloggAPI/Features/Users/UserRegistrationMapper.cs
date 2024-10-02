using StudentBloggAPI.Features.Common.Interfaces;

namespace StudentBloggAPI.Features.Users;

public class UserRegistrationMapper : IMapper<User, UserRegistrationDTO>
{
    public UserRegistrationDTO MapToDTO(User entity)
    {
        return new UserRegistrationDTO()
        {
            UserName = entity.UserName,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email
        };
    }

    public User MapToModel(UserRegistrationDTO entityDTO)
    {
        return new User()
        {
            UserName = entityDTO.UserName!,
            FirstName = entityDTO.FirstName!,
            LastName = entityDTO.LastName!,
            Email = entityDTO.Email ?? string.Empty
        };
    }
}