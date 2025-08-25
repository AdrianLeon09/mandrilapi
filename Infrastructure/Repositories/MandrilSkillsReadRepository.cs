using MandrilAPI.Aplication.Interfaces;
using MandrilAPI.Aplication.Service;
using MandrilAPI.Domain.Models;
using MandrilAPI.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.Infrastructure.Repositories
{
    public class MandrilSkillsReadRepository(MandrilDbContext contextDb, ILogger<MandrilSkillsReadRepository> logger) : IMandrilSkillsReadRepository
    {
        protected readonly MandrilDbContext _contextDb = contextDb;
        private ILogger<MandrilSkillsReadRepository> _logger = logger;

        public IReadOnlyList<Skill> GetOneSkillFromDb(int targetSkillId) // only admins
        {
            var Skill = _contextDb.Skills.Where(h => h.id == targetSkillId).AsNoTracking().ToList();
            
            if (Skill.Count is 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.SkillNotFound, targetSkillId);
                return Skill;
            }
            else
            {
                _logger.LogInformation(MessageDefaultsDevs.AllSkillsRetrieved);
                return Skill;
            }
        }

        
        public IReadOnlyList<Skill> GetAllSkillsFromDb() // only admins
        {
            var Skill = _contextDb.Skills.AsNoTracking().ToList();
            
            if (Skill.Count is 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.SkillsNotFound);
                return Skill;
            }
            else {
                _logger.LogInformation(MessageDefaultsDevs.AllSkillsRetrieved);
                return Skill; 
            }
        }

        
        public IReadOnlyList<Mandril> GetOneMandrilsFromDb(int targetMandrilId) //only admins
        {
            var Skill = _contextDb.Mandrils.Where(m => m.id == targetMandrilId).AsNoTracking().ToList();
            
            if (Skill.Count is 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.MandrilNotFound, targetMandrilId);
                return Skill;
            }
            else {
                _logger.LogInformation(MessageDefaultsDevs.AllMandrilsRetrieved);
                 return Skill;
            }
           
        }

        
        public IReadOnlyList<Mandril> GetAllMandrilsFromDb() // only admins
        {
            var Mandril = _contextDb.Mandrils.AsNoTracking().ToList();
            
            if (Mandril.Count is 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.AllMandrilsNotFound);
                return Mandril;
            }
            else
            {
                _logger.LogInformation(MessageDefaultsDevs.AllMandrilsRetrieved);
                return Mandril;
            }
        }

        
        public IReadOnlyList<MandrilWithSkillsIntermediateTable> GetOneMandrilWithOneSkillFromUser(int targetMandrilId, int targetSkillId, string userId)
        {
            var relation = _contextDb.MandrilWithSkills.Include(m => m.Mandril).Include(h => h.Skill).Where(m => m.MandrilId == targetMandrilId && m.SkillId == targetSkillId && EF.Functions.Collate(m.UserId,"SQL_Latin1_General_CP1_CI_AS") == userId).AsNoTracking().ToList();

            if (relation.Count is 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.RelationMandrilWithSkillAndUserNotFound,targetSkillId,targetMandrilId, userId);
                return relation;
            }
            else
            {
                _logger.LogInformation(MessageDefaultsDevs.MandrilWithSkillRetrieved, targetMandrilId, targetSkillId);
                return relation;
            }
        }

        
        public IReadOnlyList<MandrilWithSkillsIntermediateTable> SelectAllMandrilWithSkillsFromUser(string userId)
        {
           
            
            var relation = _contextDb.MandrilWithSkills.Include(mandriles => mandriles.Mandril).Include(mandrilSkills => mandrilSkills.Skill)
                .Include(p => p.PowerMS)
                .Where( u=> EF.Functions.Collate(u.UserId,"SQL_Latin1_General_CP1_CI_AS") == userId).AsNoTracking().ToList();

            if (relation.Count is 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.UserMandrilSkillsNotFound, userId);
                
                
                return relation;
            }
            else {

                _logger.LogInformation(MessageDefaultsDevs.AllMandrilsWithSkillsRetrieved);
                return relation;
            };
        }

        
        public IReadOnlyList<MandrilWithSkillsIntermediateTable> SelectOneMandrilWithAllSkillsFromUser(int targetMandrilId, string userId)
        {
            var relation = _contextDb.MandrilWithSkills.Include(mandriles => mandriles.Mandril).Include(skills => skills.Skill).Where(m => m.Mandril.id == targetMandrilId && EF.Functions.Collate(m.UserId,"SQL_Latin1_General_CP1_CI_AS") == userId).AsNoTracking().ToList();

            if (relation.Count is 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.UserMandrilSkillsNotFound, userId);
                return relation;
            }
            else
            {
                _logger.LogInformation(MessageDefaultsDevs.MandrilWithAllSkillsRetrieved, targetMandrilId);
                return relation;
            }
        }
    }
}
