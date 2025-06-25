using MandrilAPI.Models;
using MandrilAPI.Models.Service;

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
  
      public MandrilWithSkills AssignExistingHabilidadToMandril(int targetMandrilId, int targetHabilidadId);
      public MandrilWithSkills DeleteExistingHabilidadFromMandril(int targetHabilidadId);
      public MandrilWithSkills UpdatePotenciaOfHabilidadForMandril(int targetMandrilId,int targetHabilidadId, int newPotencia);
    }
}
