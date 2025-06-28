using MandrilAPI.Models;
using MandrilAPI.DatabaseContext;

namespace MandrilAPI.Interfaces
{
    public interface IMandrilAndSkillsReadRepository
    {
        public  IReadOnlyList<MandrilWithSkillsIntermediateTable> GetOneMandrilWithHabilidadesFromDb(int targetMandrilId, int targetHabilidadId);
        public  IReadOnlyList<Mandril> GetOneMandrilsFromDb(int targetMandrilId);
    public IReadOnlyList<Skill> GetOneHabilidadesFromDb(int targetHabilidadId);
          public IReadOnlyList<Mandril> GetAllMandrilsFromDb();
        public IReadOnlyList<Skill> GetAllHabilidadesFromDb();
}
    }  
