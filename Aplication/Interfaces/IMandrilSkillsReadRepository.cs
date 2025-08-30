using MandrilAPI.Domain.Models;
using MandrilAPI.Infrastructure.Authentication.AuthModels;
using MandrilAPI.Infrastructure.DatabaseContext;
using MandrilAPI.Infrastructure.DTOs;

namespace MandrilAPI.Aplication.Interfaces
{
    public interface IMandrilSkillsReadRepository
    {
     
        
        public  IReadOnlyList<Mandril> GetOneMandrilsFromDb(int targetMandrilId);
    public IReadOnlyList<Skill> GetOneSkillFromDb(int targetHabilidadId);
          public IReadOnlyList<Mandril> GetAllMandrilsFromDb();
        public IReadOnlyList<Skill> GetAllSkillsFromDb();

        IReadOnlyList<MandrilWithSkillsIntermediateTable> SelectAllMandrilWithSkillsFromUser(string UserId);
        IReadOnlyList<MandrilWithSkillsIntermediateTable> SelectOneMandrilWithAllSkillsFromUser(int targetMandrilId, string UserId);
        
        public Task<IReadOnlyList<RelationMandrilSkillsDto>> GetOneMandrilWithOneSkillFromUser(int targetMandrilId,
                    int targetHabilidadId, string userId);

        public Task<IReadOnlyList<AllUsersDto>> GetAllUsersFromDb();

        public Task<IReadOnlyList<UserRelationshipsDto>> GetAllRelationsFromDb();
    }
    }  
