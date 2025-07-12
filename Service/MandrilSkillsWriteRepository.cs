using MandrilAPI.DatabaseContext;
using MandrilAPI.Interfaces;
using MandrilAPI.Models;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;

namespace MandrilAPI.Service
{
    public class MandrilSkillsWriteRepository(MandrilDbContext contextDb, ILogger<MandrilSkillsWriteRepository> logger) : IMandrilAndSkillsWriteRepository
    {
        private readonly MandrilDbContext _contextDb = contextDb;
        private readonly ILogger _logger = logger;

        public Skill AddNewSkillToDb(SkillDTO newSkillDto)
        {
            // ahora implementar las validaciones de seguridad para las skills
            Skill skill = new Skill();
            skill.name = newSkillDto.name.Replace(" ", "");
            _contextDb.Skills.Add(skill);
            _contextDb.SaveChanges();
            return skill;
        }

        public Mandril AddNewMandrilToDb(MandrilDTO newMandrilDto)
        {
            newMandrilDto.name = newMandrilDto.name.Replace(" ", "");
            newMandrilDto.lastName = newMandrilDto.lastName.Replace(" ","");

            if (string.IsNullOrWhiteSpace(newMandrilDto.name) || string.IsNullOrWhiteSpace(newMandrilDto.lastName))
            {

              _logger.LogWarning(DefaultsMessageDevs.ObjectIsNull, newMandrilDto);
                return null;
              
            }
            else
            {

                if (newMandrilDto.name.Length < 3 ||  newMandrilDto.lastName.Length < 3)
                {
                    _logger.LogWarning(DefaultsMessageDevs.EntryInvalid);
                    _logger.LogWarning(DefaultsMessageDevs.NotCreatedMandril);
                    return null;
                }
                else
                {
                 Mandril mandril = new Mandril();
                    mandril.name = newMandrilDto.name;
                    mandril.lastName = newMandrilDto.lastName;

                    _contextDb.Mandrils.Add(mandril);
                    _contextDb.SaveChanges();
                    _logger.LogInformation(DefaultsMessageDevs.MandrilAddedSuccessfully);

                    return mandril;
                }

            }
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
                return null;
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
            var skill = _contextDb.Skills.FirstOrDefault(s => s.id == targetSkillId);
            
            if (skill is not null)
            {
                _contextDb.Skills.Remove(skill); 
                _contextDb.SaveChanges();
                _logger.LogInformation(DefaultsMessageDevs.DeleteSucceeded);
                return skill;
            }
            else
            {
                _logger.LogWarning(DefaultsMessageDevs.NotFoundSkill, targetSkillId);
                _logger.LogWarning(DefaultsMessageDevs.DeleteFailed);
                return null;
            }
            
        }

        public Mandril DeleteOneMandrilFromDb(int targetMandrilId)
        {
            var mandril = _contextDb.Mandrils.FirstOrDefault(m => m.id == targetMandrilId);

            if (mandril is not null)
            {
                _contextDb.Mandrils.Remove(mandril);
                _contextDb.SaveChanges();
                _logger.LogInformation(DefaultsMessageDevs.DeleteSucceeded);
                return mandril;
            }
            else
            {
                _logger.LogWarning(DefaultsMessageDevs.NotFoundSkill);
                _logger.LogWarning(DefaultsMessageDevs.DeleteFailed);
                
                return null;
            }

            
        }

        public Skill UpdateOneSkillToDb(int targetSkillId, SkillDTO skillDto)
        {
            var skill = _contextDb.Skills.FirstOrDefault(s => s.id == targetSkillId);
            if (skill is not null)
            {
                skill.name = skillDto.name;
                _contextDb.Skills.Update(skill);
                _contextDb.SaveChanges();
                _logger.LogInformation(DefaultsMessageDevs.UpdateSkillSucceeded);
                return skill;
            }
            else
            {
                _logger.LogWarning(DefaultsMessageDevs.NotFoundSkill, targetSkillId);
                return null;
            }
          
        }

        public Mandril UpdateOneMandrilToDb(int targetMandrilId, MandrilDTO mandrilDto)
        {
            var mandril = _contextDb.Mandrils.FirstOrDefault(m => m.id == targetMandrilId);

            if (mandril is not null)
            {
                if (!string.IsNullOrEmpty(mandrilDto.name) || !string.IsNullOrEmpty(mandrilDto.lastName))
                {
                    mandrilDto.name = mandrilDto.name.Replace(" ", "");
                     mandrilDto.lastName = mandrilDto.lastName.Replace(" ", "");

                    if (mandrilDto.name.Length < 3 || mandrilDto.lastName.Length < 3)
                    {
                        _logger.LogWarning(DefaultsMessageDevs.EntryInvalid);
                        _logger.LogWarning(DefaultsMessageDevs.UpdateFailed, targetMandrilId);
                        return null;
                    }
                    else
                    {
                        mandril.name = mandrilDto.name;
                        mandril.lastName = mandrilDto.lastName;
                        _contextDb.Mandrils.Update(mandril);
                        _contextDb.SaveChanges();
                        _logger.LogInformation(DefaultsMessageDevs.UpdateMandrilSucceeded);
                        return mandril;

                    }

                }
                else
                {
                    _logger.LogWarning(DefaultsMessageDevs.EntryInvalid);
                    return null;
                }
            }
            else
            {
                _logger.LogWarning(DefaultsMessageDevs.NotFoundMandril, targetMandrilId);
                _logger.LogWarning(DefaultsMessageDevs.UpdateFailed, targetMandrilId);
                return null;
            }
            
        }
              
               
              
            
           
        

        public MandrilWithSkillsIntermediateTable UpdatePotenciaOfSkillForMandril(int targetMandrilId, int targetSkillId, int newPower)
        {
            var relation = _contextDb.MandrilWithSkills.FirstOrDefault(m => m.MandrilId == targetMandrilId && m.SkillId == targetSkillId);
            if (relation is not null)
            {
                relation.PowerMS = newPower;
                _contextDb.MandrilWithSkills.Update(relation);
                _contextDb.SaveChanges();
                _logger.LogInformation(DefaultsMessageDevs.UpdatePowerSucceeded,targetSkillId, targetMandrilId, newPower);
                return relation;
            }
            else
            {
                _logger.LogWarning(DefaultsMessageDevs.NotFoundRelationSkill, targetSkillId, targetMandrilId);
                _logger.LogWarning(DefaultsMessageDevs.UpdateRelationFailed, targetSkillId, targetMandrilId);
            }
            return null;
        }
    }
}
