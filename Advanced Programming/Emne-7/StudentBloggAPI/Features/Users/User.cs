using System.ComponentModel.DataAnnotations;

namespace StudentBloggAPI.Features.Users;

public class User
{
    [Key]
    public Guid Id { get; init;  }
    
    [Required]
    [MinLength(3), MaxLength(30)]
    public string UserName { get; set; } = string.Empty;
    
    [Required]
    [MinLength(2), MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MinLength(2), MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public string HashedPassword { get; set; } = string.Empty;
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    public DateTime UpdatedAt { get; set; }
    
    [Required]
    public bool IsAdmin { get; set; }
}