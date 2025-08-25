using MandrilAPI.Domain.Models;
using MandrilAPI.Infrastructure.DatabaseContext;

namespace MandrilAPI.Aplication.Interfaces
{
    public interface IMandrilSkillsReadRepository
    {
        public IReadOnlyList<MandrilWithSkillsIntermediateTable> GetOneMandrilWithOneSkillFromUser(int targetMandrilId,
            int targetHabilidadId, string userId);
        
        public  IReadOnlyList<Mandril> GetOneMandrilsFromDb(int targetMandrilId);
    public IReadOnlyList<Skill> GetOneSkillFromDb(int targetHabilidadId);
          public IReadOnlyList<Mandril> GetAllMandrilsFromDb();
        public IReadOnlyList<Skill> GetAllSkillsFromDb();

        IReadOnlyList<MandrilWithSkillsIntermediateTable> SelectAllMandrilWithSkillsFromUser(string UserId);
        IReadOnlyList<MandrilWithSkillsIntermediateTable> SelectOneMandrilWithAllSkillsFromUser(int targetMandrilId, string UserId);
}
    }  
