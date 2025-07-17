using MandrilAPI.DatabaseContext;
using MandrilAPI.DTOs;
using MandrilAPI.Models;

namespace MandrilAPI.Interfaces
{
    public interface IMandrilSkillsWriteRepository
    {
      public Mandril AddNewMandrilToDb(MandrilDto newMandrilDto);
      public Mandril UpdateOneMandrilToDb(int targetMandrilId, MandrilDto mandrilDto);
      public Mandril DeleteOneMandrilFromDb(int targetIdMandril);
             
      public Skill AddNewSkillToDb(SkillDto newSkillDto);
      public Skill UpdateOneSkillToDb(int targetSkillId, SkillDto skillDto);
      public Skill DeleteOneSkillFromDb(int targetSkillId);
  
      public MandrilWithSkillsIntermediateTable AssignOneSkillToMandril(int targetMandrilId, int targetSkillId);
      public MandrilWithSkillsIntermediateTable DeleteSkillFromMandril(int targetMandrilId,int targetSkillId);
      public MandrilWithSkillsIntermediateTable UpdatePowerOfSkillForMandril(int targetMandrilId,int targetSkillId, int newPower);
    }
}
