namespace StudentBloggAPI.Features.Users.Interfaces;

public interface IUserMapper
{
    UserDTO MapToDTO(User user);
    User MapToModel(UserDTO userDTO);
}