namespace StudentBloggAPI.Features.Users.Interfaces;

public interface IUserMapper
{
    UserResponse MapToDTO(User model);
    User MapToModel(UserResponse response);
}