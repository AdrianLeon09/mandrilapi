using System.ComponentModel.DataAnnotations;

namespace MandrilAPI.Models;

public class MandrilDTO
{
    
    [Required]
    [StringLength(50)]
    public string Nombre { get; set; }
    [Required]
    [StringLength(50)]
    public string Apellido { get; set; }

    // public string message { get; } = "El objeto se ha creado exitosamente";
    
   
   
   // public MandrilInsert(String nombre, String apellido)
    // {
    //     this.Nombre = nombre;
    //     this.Apellido = apellido;
    // }
}