namespace MandrilAPI.Models
{
    public class Habilidad
    {
        //Cada habilidad tiene su potencia que es medida por el enum Epotencia
       public  int Id { get; set; }
       static int ide = 0;
        public string Nombre { get; set; }

        //Si se quiere mostrar la potencia en numero en el getMandriles de controller, cambiar el modificador de acceso a public
        public EPotencia Potencia { get; set; }
        public string PotenciaString { get; set; }
        
      protected static List<Habilidad> ListaHabilidades = new List<Habilidad>();

       

        //Constructor habilidad por cada habilidad creada se crea automaticamente el id
        //Al final se agrega automaticamente la habilidad nueva a una lista de habilidades 
        public Habilidad(string nombreHabilidad, int potenciaHabilidad)
        {

            this.Id = ide;
            ide++;
            this.Nombre = nombreHabilidad;
            this.Potencia = (EPotencia)potenciaHabilidad;
           this.PotenciaString = this.Potencia.ToString();
            ListaHabilidades.Add(this);
            

        }
        
        //constructor vacio
        public Habilidad()
        {
            this.Id = ide;
            ide++;
            ListaHabilidades.Add(this);
        }
    


    //enum de la propiedad potencia de la habilidad
    public enum EPotencia
    {
        Suave,
        Moderado,
        Intenso,
        MuyIntenso,
        Extremo
        }


//Metodo statico que inicia la lista de habilidades
// NO se usa para mostrar listas
    public  static List<Habilidad> IniciarListaHabilidades()
       //bug resuelto duplicado de habilidades resuelto = en el constructor de habilidades al crear unanueva instancia de habilidad
       //este se agregaba a la lista tanto en el constructor como en la lista statica
       //solucion = instanciar los metodos directamente en el metodo statico IniciarListaHabilidades, debido a la naturaleza del constructor
        //este se agregara a la lista automaticamente y una vez
    {
      new Habilidad( "Bola de Fuego", 0);
       new Habilidad( "Bola de aire", 1);
        new Habilidad( "Bola de lava", 2);
      new Habilidad( "Ataque mortal", 3);

        return ListaHabilidades;

    }

        //Metodo statico que permite el uso directo de las habilidades por medio de la lista
        public  static List<Habilidad> SeleccionarHabilidad() { return ListaHabilidades ; }

        public static void AgregarHabilidadToList(Habilidad habilidad)
        {
            ListaHabilidades.Add(habilidad);
            
        }
   }


}
