using MandrilAPI.Domain.Models;
using MandrilAPI.Infrastructure.DatabaseContext;
using MandrilAPI.Infrastructure.DTOs;
using MandrilAPI.Infrastructure.ModelsDTOs;

namespace MandrilAPI.Aplication.Interfaces
{
    public interface IMandrilSkillsWriteRepository
    {
      public Task<Mandril> AddNewMandrilToDb(MandrilDto newMandrilDto);
      public Task<Mandril> UpdateOneMandrilToDb(int targetMandrilId, MandrilDto mandrilDto);
      public Task<Mandril> DeleteOneMandrilFromDb(int targetIdMandril);
             
      public Task<Skill> AddNewSkillToDb(SkillDto newSkillDto);
      public Task<Skill> UpdateOneSkillToDb(int targetSkillId, SkillDto newSkillDto);
      public Task<Skill> DeleteOneSkillFromDb(int targetSkillId);
  
      public Task<MandrilWithSkillsIntermediateTable> AssignOneSkillToMandril(int targetMandrilId, int targetSkillId, string userId);
      public Task<MandrilWithSkillsIntermediateTable> DeleteSkillFromMandrilForUser(int targetMandrilId,int targetSkillId, string userId);
      public Task<MandrilWithSkillsIntermediateTable> UpdatePowerOfSkillForMandril(int targetMandrilId,int targetSkillId, int newPower, string userId);

      public Task<MandrilWithSkillsIntermediateTable> DeleteMandrilForUser(int targetMandrilId, string userId);
    }
}
