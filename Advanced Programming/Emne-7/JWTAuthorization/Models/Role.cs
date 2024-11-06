using JWTAuthorization.Models.Interfaces;

namespace JWTAuthorization.Models;

public class Role : IRole
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}