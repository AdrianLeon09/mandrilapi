

namespace MandrilAPI.Domain.Models
{
    public class Mandril

    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        
        public Mandril(string name, string lastname)
        {
            this.name = name;
            this.lastName = lastname;
        }
        public Mandril(){}

    }

}

