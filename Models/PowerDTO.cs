using MandrilAPI.Service;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MandrilAPI.Models;

public class PowerDTO
{
    [Required(ErrorMessage = "Error: Letters and special characters are not allowed.")]
    [Range(0,4, ErrorMessage = MessageDefaultsUsers.PowerInvalid) ]
    
    public int Power { get; set; } = 0;
}