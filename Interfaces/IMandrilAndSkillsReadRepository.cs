using MandrilAPI.Models;
using MandrilAPI.Models.Service;

namespace MandrilAPI.Interfaces
{
    public interface IMandrilAndSkillsReadRepository
    {
        public  IReadOnlyList<MandrilWithSkillsIntermediateDb> GetOneMandrilWithHabilidadesFromDb(int targetMandrilId, int targetHabilidadId);
        public  IReadOnlyList<Mandril> GetOneMandrilsFromDb(int targetMandrilId);
    public IReadOnlyList<Skill> GetOneHabilidadesFromDb(int targetHabilidadId);
          public IReadOnlyList<Mandril> GetAllMandrilsFromDb();
        public IReadOnlyList<Skill> GetAllHabilidadesFromDb();
}
    }  
