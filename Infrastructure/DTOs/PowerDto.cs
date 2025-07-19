using System.ComponentModel.DataAnnotations;
using MandrilAPI.Aplication.Service;

namespace MandrilAPI.Infrastructure.DTOs;

public class PowerDto
{
    [Required(ErrorMessage = "Error: Letters and special characters are not allowed.")]
    [Range(0,4, ErrorMessage = MessageDefaultsUsers.PowerInvalid) ]
    
    public int Power { get; set; } = 0;
}