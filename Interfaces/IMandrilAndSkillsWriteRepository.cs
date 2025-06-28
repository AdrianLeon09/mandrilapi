using MandrilAPI.DatabaseContext;
using MandrilAPI.Models;

namespace MandrilAPI.Interfaces
{
    public interface IMandrilAndSkillsWriteRepository
    {
      public Mandril AddNewMandrilToDb(MandrilDTO newMandrilDto);
      public Mandril UpdateOneMandrilToDb(int targetMandrilId, MandrilDTO mandrilDto);
      public Mandril DeleteOneMandrilFromDb(int targetIdMandril);
             
      public Skill AddNewHabilidadToDb(SkillDTO newHabilidadDto);
      public Skill UpdateOneSkillToDb(int targetHabilidadId, SkillDTO habilidadDTO);
      public Skill DeleteOneSkillFromDb(int targetHabilidadId);
  
      public MandrilWithSkillsIntermediateTable AssignExistingHabilidadToMandril(int targetMandrilId, int targetHabilidadId);
      public MandrilWithSkillsIntermediateTable DeleteSkillFromMandril(int targetHabilidadId);
      public MandrilWithSkillsIntermediateTable UpdatePotenciaOfSkillForMandril(int targetMandrilId,int targetHabilidadId, int newPotencia);
    }
}
