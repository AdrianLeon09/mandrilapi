using MandrilAPI.Service;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MandrilAPI.Models;

public class PowerDTO
{
    [Required(ErrorMessage = "Error no se admiten letras ni caracteres especiales.")]
    [Range(0,4, ErrorMessage = DefaultsMessageUsers.PotenciaInvalid) ]
    public int Power { get; set; } = 0;
}