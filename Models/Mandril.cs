using System.Text.Json.Serialization;
using MandrilAPI.Models.Service;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.Models
{
    public class Mandril
    {
        public int id { get; set; }
        protected static int ide = 0;
        public String Nombre { get; set; } = string.Empty;
        public String Apellido { get; set; } = string.Empty;
       //Si NO se quiere mostrar las Habiliades en el getMandriles de controller, cambiar el modificador de acceso a protected
        public List<Habilidad>? Habilidades { get; set; }

        //constructor mandril que recibe una habilidad y luego hace una lista personalizada de habilidades
        public Mandril( string nombre, string apellido,Habilidad habilidad) {

           Habilidades = new List<Habilidad>();
            
           this.id = ide;
            ide++;
            this.Nombre = nombre; this.Apellido = apellido;

            Habilidades.Add(habilidad);
        }

        public Mandril(String nombre, String apellido)
        {
            this.Nombre = nombre; 
            this.Apellido = apellido;
            //this.id = ide;
            //ide++;

        }
        
        public Mandril(){}
        //Lista con las habiliades del objeto mandril creado
        public  List<Habilidad> HabilidadMandril() { return Habilidades; }

        }


}

