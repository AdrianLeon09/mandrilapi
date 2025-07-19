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

        public IReadOnlyList<Skill> GetOneSkillFromDb(int targetSkillId)
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

        
        public IReadOnlyList<Skill> GetAllSkillsFromDb()
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

        
        public IReadOnlyList<Mandril> GetOneMandrilsFromDb(int targetMandrilId)
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

        
        public IReadOnlyList<Mandril> GetAllMandrilsFromDb()
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

        
        public IReadOnlyList<MandrilWithSkillsIntermediateTable> GetOneMandrilWithOneSkillFromDb(int targetMandrilId, int targetSkillId)
        {
            var relation = _contextDb.MandrilWithSkills.Include(m => m.Mandril).Include(h => h.Skill)
                .Where(m => m.MandrilId == targetMandrilId && m.SkillId == targetSkillId).ToList();

            if (relation.Count is 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.RelationMandrilWithSkillNotFound,targetSkillId,targetMandrilId);
                return relation;
            }
            else
            {
                _logger.LogInformation(MessageDefaultsDevs.MandrilWithSkillRetrieved, targetMandrilId, targetSkillId);
                return relation;
            }
        }

        
        public IReadOnlyList<MandrilWithSkillsIntermediateTable> SelectAllMandrilWithSkills()
        {
            var relation = _contextDb.MandrilWithSkills.Include(mandriles => mandriles.Mandril).Include(mandrilSkills => mandrilSkills.Skill)
                .Include(p => p.PowerMS)
                .AsNoTracking().ToList();

            if (relation.Count is 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.AllMandrilsWithSkillsError);
                _logger.LogWarning(MessageDefaultsDevs.MandrilsWithSkillsNotFound);
                return relation;
            }
            else {

                _logger.LogInformation(MessageDefaultsDevs.AllMandrilsWithSkillsRetrieved);
                return relation;
            };
        }

        
        public IReadOnlyList<MandrilWithSkillsIntermediateTable> SelectOneMandrilWithAllSkills(int targetMandrilId)
        {
            var relation = _contextDb.MandrilWithSkills.Include(mandriles => mandriles.Mandril).Include(mandrilSkills => mandrilSkills.Skill)
                .Where(m => m.Mandril.id == targetMandrilId).ToList();

            if (relation.Count is 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.MandrilWithSkillsNotFound);
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
