using System.ComponentModel.DataAnnotations;

namespace MandrilAPI.Infrastructure.DTOs;

public class LoginDto
{
    [Required(ErrorMessage = "Username is required")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}