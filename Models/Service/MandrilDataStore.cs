namespace MandrilAPI.Models.Service
{
    public class MandrilDataStore
    {
        protected static List<Mandril> mandriles = new List<Mandril>();

        public static MandrilDataStore Current { get; } = new MandrilDataStore();


        //Se crea una lista simulada con los mandriles disponibles
        //NO se debe llamar mas de una vez caso contrario ocurriran bugs de duplicado y bucle
        //Lista Statica
        public static List<Mandril> InicializarMandrilesData()
        {

            mandriles.Add(new Mandril("Adrian", "leon", Habilidad.SeleccionarHabilidad()[0]));
            mandriles.Add(new Mandril("Jose", "Alcachofa", Habilidad.SeleccionarHabilidad()[1]));
            mandriles.Add(new Mandril("Paola", "Hernandez", Habilidad.SeleccionarHabilidad()[2]));

            return mandriles;
        }


        //metodo que devuelve la lista de mandriles de MandrilDataStore para uso
        public List<Mandril> UsarListaMandriles()
        {
            return mandriles;
        }



    }

}
