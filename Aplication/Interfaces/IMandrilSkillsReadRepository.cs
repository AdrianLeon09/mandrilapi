using MandrilAPI.Domain.Models;
using MandrilAPI.Infrastructure.Authentication.AuthModels;
using MandrilAPI.Infrastructure.DatabaseContext;
using MandrilAPI.Infrastructure.DTOs;

namespace MandrilAPI.Aplication.Interfaces
{
    public interface IMandrilSkillsReadRepository
    {
        Task<IReadOnlyList<Skill>> GetOneSkillFromDb(int targetSkillId); // only admins
        Task<IReadOnlyList<Skill>> GetAllSkillsFromDb(); // only admins
        Task<IReadOnlyList<Mandril>> GetOneMandrilsFromDb(int targetMandrilId); // only admins
        Task<IReadOnlyList<Mandril>> GetAllMandrilsFromDb(); // only admins

        Task<IReadOnlyList<RelationMandrilSkillsDto>> GetOneMandrilWithOneSkillFromUser(int targetMandrilId,
            int targetSkillId, string userId);

        Task<IReadOnlyList<RelationMandrilSkillsDto>> SelectAllMandrilWithSkillsFromUser(string userId);
        Task<IReadOnlyList<RelationMandrilSkillsDto>> SelectOneMandrilWithAllSkillsFromUser(
            int targetMandrilId, string userId);

        Task<IReadOnlyList<AllUsersDto>> GetAllUsersFromDb(); // only admins
        Task<IReadOnlyList<UserRelationshipsDto>> GetAllRelationsFromDb(); // only admins
    }
}
