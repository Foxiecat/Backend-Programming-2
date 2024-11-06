using StudentBloggAPI.Features.Common.Interfaces;

namespace StudentBloggAPI.Features.Users.Interfaces;

public interface IUserService : IBaseService<UserResponse>
{
    Task<UserResponse?> RegisterAsync(UserRegistrationDTO regDto);
    Task<Guid> AuthenticateUserAsync(string user, string password);
    Task<IEnumerable<UserResponse>> FindAsync(UserSearchParams searchParams);
}