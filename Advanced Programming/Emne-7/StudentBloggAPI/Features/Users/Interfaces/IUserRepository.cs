using StudentBloggAPI.Features.Common.Interfaces;

namespace StudentBloggAPI.Features.Users.Interfaces;

public interface IUserRepository : IBaseRepository<User, UserDTO>
{
    Task<User?> AddAsync(User entity);
    Task<UserDTO?> UpdateAsync(UserDTO entity);
    Task<UserDTO?> DeleteAsync(Guid id);
    Task<User?> GetByIdAsync(Guid id);

}