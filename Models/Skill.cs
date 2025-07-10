using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MandrilAPI.Models
{
    public class Skill
    {
        //Cada habilidad tiene su potencia por default en 0
        public  int id { get; set; }
        public string name { get; set; } = string.Empty;
        internal int Power { get; set; } = 0;      
        internal PowerEnum PotenciaAsString { get; set; }
          
        public Skill(string nameSkill)
        {
            name = nameSkill;          
        }
        public Skill() { }

        //enum de la propiedad potencia en habilidad por ahora estara aca porque no tengo donde ponerla
        public enum PowerEnum
    {
        veryLow,
        Moderate,
        High,
        Intense,
        Extreme
        }
   }


}
