using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MandrilAPI.Models;

public class HabilidadDTOPotencia
{
    [Required(ErrorMessage = "Error no se admiten letras ni caracteres especiales.")]
    public int Potencia { get; set; } = 0;

    public bool potenciaIsValid()
    {
        if (Potencia <= 4)
        {
            return true;
        }
        else
        {
           
            return false;
        }
    }
}