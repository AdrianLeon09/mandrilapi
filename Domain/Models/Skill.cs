

namespace MandrilAPI.Domain.Models
{
    public class Skill
    {
        public  int id { get; set; }
        public string name { get; set; } = string.Empty;
        internal int Power { get; set; } = 0; //default power value     
        internal PowerEnum PotenciaAsString { get; set; }
          
        public Skill(string nameSkill)
        {
            name = nameSkill;          
        }
        public Skill() { }
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
