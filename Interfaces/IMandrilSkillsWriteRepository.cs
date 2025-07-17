using MandrilAPI.DatabaseContext;
using MandrilAPI.Models;

namespace MandrilAPI.Interfaces
{
    public interface IMandrilSkillsWriteRepository
    {
      public Mandril AddNewMandrilToDb(MandrilDTO newMandrilDto);
      public Mandril UpdateOneMandrilToDb(int targetMandrilId, MandrilDTO mandrilDto);
      public Mandril DeleteOneMandrilFromDb(int targetIdMandril);
             
      public Skill AddNewSkillToDb(SkillDTO newSkillDto);
      public Skill UpdateOneSkillToDb(int targetSkillId, SkillDTO skillDto);
      public Skill DeleteOneSkillFromDb(int targetSkillId);
  
      public MandrilWithSkillsIntermediateTable AssignOneSkillToMandril(int targetMandrilId, int targetSkillId);
      public MandrilWithSkillsIntermediateTable DeleteSkillFromMandril(int targetMandrilId,int targetSkillId);
      public MandrilWithSkillsIntermediateTable UpdatePowerOfSkillForMandril(int targetMandrilId,int targetSkillId, int newPower);
    }
}
