using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAuthorization.Configuration;
using JWTAuthorization.Models;
using JWTAuthorization.Models.Interfaces;
using JWTAuthorization.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace JWTAuthorization.Services;

public class TokenService(IOptions<JwtOptions> jwtOptions) : ITokenService
{
    public async Task<IIdentityUser> LoginAsync(string username, string password)
    {
        await Task.Delay(10);
        return new IdentityUser
        {
            Id = Guid.NewGuid(),
            UserName = username,
            Roles =
            [
                new Role { Id = Guid.NewGuid(), Name = "Admin" },
                new Role { Id = Guid.NewGuid(), Name = "Developer" }
            ]
        };
    }

    public async Task<string?> GenerateJwtTokenAsync(IIdentityUser user)
    {
        await Task.Delay(10);

        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()!),
            new(ClaimTypes.Name, user.UserName!)
        ];
        
        // Legg til roller
        foreach (IRole role in user.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Name!));
        }
        
        byte[] secrets = Encoding.UTF8.GetBytes(jwtOptions.Value.Key!);
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = jwtOptions.Value.Issuer,
            Audience = jwtOptions.Value.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(secrets), 
                SecurityAlgorithms.HmacSha256)
        };
        
        JwtSecurityTokenHandler tokenHandler = new();
        SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }

    public (string? userId, IEnumerable<string> roles) ValidateAccessToken(string accessToken)
    {
        try
        {
            JwtSecurityTokenHandler tokenHandler = new();
            SymmetricSecurityKey key = new (Encoding.UTF8.GetBytes(jwtOptions.Value.Key!));
            
            tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = key,
                ValidIssuer = jwtOptions.Value.Issuer,
                ValidAudience = jwtOptions.Value.Audience
                
            }, out SecurityToken? validatedToken);
            
            JwtSecurityToken jwtSecurityToken = (JwtSecurityToken)validatedToken;
            
            string? userId = jwtSecurityToken.Claims
                .FirstOrDefault(claim => claim.Type == "nameid")?.Value;
            
            IEnumerable<string> roles = jwtSecurityToken.Claims
                .Where(claim => claim.Type == "role")
                .Select(claim => claim.Value);
            
            return (userId, roles);
        }
        catch (Exception exception)
        {
            // Legg til logger !!!
            return (null, null)!;
        }
    }
}