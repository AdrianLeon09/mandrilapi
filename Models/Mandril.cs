using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MandrilAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.Models
{
    public class Mandril

    {
        public int id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;

        //Si NO se quiere mostrar las Habiliades en el getMandriles de controller, cambiar el modificador de acceso a protected
        public Mandril(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }
        public Mandril()
        {
        }

    }

}

