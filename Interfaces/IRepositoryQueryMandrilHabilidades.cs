using MandrilAPI.Models;
using MandrilAPI.Models.Service;

namespace MandrilAPI.Interfaces
{
    public interface IRepositoryQueryMandrilHabilidades
    {
        public  MandrilHabilidades SelectMandrilWithHabilidadesFromDb(int targetIdMandril, int targetIdHabilidad);
        public  Mandril SelectOneMandrilsFromDb(int targetIdMandril);
        public List<Mandril> SelectAllMandrilsFromDb();
        public  Habilidad SelectOneHabilidadesFromDb(int targetIdHabilidad);
    }
}
