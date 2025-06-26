using MandrilAPI.Models;

namespace MandrilAPI.Interfaces
{
    public interface IMandrilAndSkillsWriteRepository
    {
      public Mandril AddNewMandrilToDb(MandrilDTO newMandrilDto);
      public Mandril UpdateOneMandrilToDb(int targetMandrilId, MandrilDTO mandrilDto);
      public Mandril DeleteOneMandrilFromDb(int targetIdMandril);
             
      public Skill AddNewHabilidadToDb(SkillDTO newHabilidadDto);
      public Skill UpdateOneHabilidadToDb(int targetHabilidadId, SkillDTO habilidadDTO);
      public Skill DeleteOneHabilidadFromDb(int targetHabilidadId);
  
      public MandrilWithSkillsIntermediateDb AssignExistingHabilidadToMandril(int targetMandrilId, int targetHabilidadId);
      public MandrilWithSkillsIntermediateDb DeleteHabilidadFromMandril(int targetHabilidadId);
      public MandrilWithSkillsIntermediateDb UpdatePotenciaOfHabilidadForMandril(int targetMandrilId,int targetHabilidadId, int newPotencia);
    }
}
