﻿using StudentBloggAPI.Features.Common.Interfaces;

namespace StudentBloggAPI.Features.Users.Interfaces;

public interface IUserService : IBaseService<UserDTO>
{
    Task<UserDTO?> RegisterAsync(UserRegistrationDTO registerDTO);
    Task<Guid> AuthenticateUserAsync(string user, string password);
    
    Task<IEnumerable<UserDTO>> FindAsync(UserSearchParameters searchParameters);
}