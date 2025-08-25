using MandrilAPI.Domain.Models;
using MandrilAPI.Infrastructure.DatabaseContext;
using MandrilAPI.Infrastructure.DTOs;

namespace MandrilAPI.Aplication.Interfaces
{
    public interface IMandrilSkillsWriteRepository
    {
      public Mandril AddNewMandrilToDb(MandrilDto newMandrilDto);
      public Mandril UpdateOneMandrilToDb(int targetMandrilId, MandrilDto mandrilDto);
      public Mandril DeleteOneMandrilFromDb(int targetIdMandril);
             
      public Skill AddNewSkillToDb(SkillDto newSkillDto);
      public Skill UpdateOneSkillToDb(int targetSkillId, SkillDto skillDto);
      public Skill DeleteOneSkillFromDb(int targetSkillId);
  
      public MandrilWithSkillsIntermediateTable AssignOneSkillToMandril(int targetMandrilId, int targetSkillId, string userId);
      public MandrilWithSkillsIntermediateTable DeleteSkillFromMandrilForUser(int targetMandrilId,int targetSkillId, string userId);
      public MandrilWithSkillsIntermediateTable UpdatePowerOfSkillForMandril(int targetMandrilId,int targetSkillId, int newPower, string userId);       
    }
}
