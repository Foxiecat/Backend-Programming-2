using JWTAuthorization.Models.Interfaces;

namespace JWTAuthorization.Models;

public class IdentityUser : IIdentityUser
{
    public Guid? Id { get; set; }
    public string? UserName { get; set; }
    public ICollection<IRole> Roles { get; set; }
}