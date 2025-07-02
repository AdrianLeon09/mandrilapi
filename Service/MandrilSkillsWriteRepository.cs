using MandrilAPI.DatabaseContext;
using MandrilAPI.Interfaces;
using MandrilAPI.Models;

namespace MandrilAPI.Service
{
    public class MandrilSkillsWriteRepository(MandrilDbContext contextDb, ILogger logger) : IMandrilAndSkillsWriteRepository
    {
        private readonly MandrilDbContext _contextDb = contextDb;
        private readonly ILogger _logger = logger;

        public Skill AddNewSkillToDb(SkillDTO newSkillDto)
        {
            Skill skill = new Skill();
            skill.Nombre = newSkillDto.Nombre;
           
            _contextDb.Skills.Add(skill);
            _contextDb.SaveChanges();
            return skill;
        }

        public Mandril AddNewMandrilToDb(MandrilDTO newMandrilDto)
        {
            Mandril mandril = new Mandril();
            mandril.Nombre = newMandrilDto.Nombre;

            _contextDb.Mandrils.Add(mandril);
            _contextDb.SaveChanges();
            return mandril;
        }

        public MandrilWithSkillsIntermediateTable AssignOneSkillToMandril(int targetMandrilId, int targetSkillId)
        {
            var mandril = _contextDb.Mandrils.FirstOrDefault(m => m.id == targetMandrilId);
            var skill = _contextDb.Skills.FirstOrDefault(h => h.id == targetSkillId);
            var relation = new MandrilWithSkillsIntermediateTable();
           
            
            if(mandril is null || skill is null)
            {
                _logger.LogWarning(DefaultsMessageDevs.DatabaseNull);
                _logger.LogWarning(DefaultsMessageDevs.relationNotCreated_EntityNotFound, targetMandrilId, targetSkillId);
                return relation;
            }
            else
            {
            relation.MandrilId = targetMandrilId;
            relation.SkillId = targetSkillId;
            relation.PowerMS = 0; //default

                _logger.LogInformation(DefaultsMessageDevs.relationHasBeenCreated, targetMandrilId, targetSkillId, relation.PowerMS);
                _contextDb.MandrilWithSkills.Add(relation);
                _contextDb.SaveChanges();
                return relation;

            }
        }

        public MandrilWithSkillsIntermediateTable DeleteSkillFromMandril(int targetMandrilId, int targetSkillId)
        {
            var relation = _contextDb.MandrilWithSkills
                  .FirstOrDefault(m => m.MandrilId == targetMandrilId && m.SkillId == targetSkillId);
            if (relation is null)
            {
                _logger.LogWarning(DefaultsMessageDevs.DatabaseNull);
                _logger.LogWarning(DefaultsMessageDevs.NotFoundRelationSkill, targetSkillId, targetMandrilId);
                _logger.LogWarning(DefaultsMessageDevs.DeleteFailed);
                return relation;
            }
            else
            {
                _contextDb.MandrilWithSkills.Remove(relation);
                _contextDb.SaveChanges();
                _logger.LogInformation(DefaultsMessageDevs.DeleteSucceeded);
                return relation;
            }
        }

        public Skill DeleteOneSkillFromDb(int targetSkillId)
        {
            return null;
        }

        public Mandril DeleteOneMandrilFromDb(int targetIdMandril)
        {
            return null;
        }

        public Skill UpdateOneSkillToDb(int targetSkillId, SkillDTO skillDto)
        {
             return null;
        }

        public Mandril UpdateOneMandrilToDb(int targetMandrilId, MandrilDTO mandrilDto)
        {
            return null;
        }

        public MandrilWithSkillsIntermediateTable UpdatePotenciaOfSkillForMandril(int targetMandrilId, int targetSkillId, int newPotencia)
        {
            return null;
        }
    }
}
