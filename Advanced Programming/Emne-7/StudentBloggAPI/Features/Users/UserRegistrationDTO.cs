﻿using System.ComponentModel.DataAnnotations;

namespace StudentBloggAPI.Features.Users;

public class UserRegistrationDTO
{
    public string? UserName { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? Password { get; set; }
}