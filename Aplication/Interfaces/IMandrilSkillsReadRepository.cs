using MandrilAPI.Domain.Models;
using MandrilAPI.Infrastructure.DatabaseContext;

namespace MandrilAPI.Aplication.Interfaces
{
    public interface IMandrilSkillsReadRepository
    {
        public  IReadOnlyList<MandrilWithSkillsIntermediateTable> GetOneMandrilWithOneSkillFromDb(int targetMandrilId, int targetHabilidadId);
        public  IReadOnlyList<Mandril> GetOneMandrilsFromDb(int targetMandrilId);
    public IReadOnlyList<Skill> GetOneSkillFromDb(int targetHabilidadId);
          public IReadOnlyList<Mandril> GetAllMandrilsFromDb();
        public IReadOnlyList<Skill> GetAllSkillsFromDb();

        IReadOnlyList<MandrilWithSkillsIntermediateTable> SelectAllMandrilWithSkills();
        IReadOnlyList<MandrilWithSkillsIntermediateTable> SelectOneMandrilWithAllSkills(int targetMandrilId);
}
    }  
