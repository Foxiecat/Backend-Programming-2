﻿namespace StudentBloggAPI.Features.Users.DTO;

public class UserResponse
{
    public Guid Id { get; init; }
    public string UserName { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public DateTime Created { get; init; }
    public DateTime Updated { get; init; }
}