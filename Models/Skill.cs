using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MandrilAPI.Models
{
    public class Skill
    {
        //Cada habilidad tiene su potencia que es medida por el enum Epotencia
        public  int id { get; set; }
        public string Nombre { get; set; }

        [NotMapped]
        internal int Power { get; set; } = 0;
        
    [NotMapped]
        internal PowerEnum PotenciaAsString { get; set; }
    

       

        //Constructor habilidad por cada habilidad creada se crea automaticamente el id
        //Al final se agrega automaticamente la habilidad nueva a una lista de habilidades 
        public Skill(string nameSkill)
        {
            this.Nombre = nameSkill;
            
        }
        public Skill()
        {

        }
    //enum de la propiedad potencia en habilidad por ahora estara aca porque no tengo donde ponerla
    public enum PowerEnum
    {
        Suave,
        Moderado,
        Intenso,
        MuyIntenso,
        Extremo
        }

   }


}
