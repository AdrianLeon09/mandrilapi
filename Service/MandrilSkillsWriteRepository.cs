using MandrilAPI.DatabaseContext;
using MandrilAPI.Interfaces;
using MandrilAPI.Models;
using Microsoft.EntityFrameworkCore;
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
            Skill skill = new Skill();
            skill.name = newSkillDto.name.Replace(" ", "");

            if (!string.IsNullOrWhiteSpace(newSkillDto.name))
            {
                if (newSkillDto.name.Length < 3)
                {
                    _logger.LogWarning(MessageDefaultsDevs.InvalidEntry);
                    _logger.LogWarning(MessageDefaultsDevs.SkillCreationError);                                //me quede por aca refactorizar los loggers
                    return null;
                }
                else
                {
                    _contextDb.Skills.Add(skill);
                    _contextDb.SaveChanges();
                    _logger.LogInformation(MessageDefaultsDevs.SkillCreated);
                    return skill;
                }
            }
            else
            {
                _logger.LogError(MessageDefaultsDevs.InvalidEntry);
                return null;
            }
        }

        public Mandril AddNewMandrilToDb(MandrilDTO newMandrilDto)
        {
            newMandrilDto.name = newMandrilDto.name.Replace(" ", "");
            newMandrilDto.lastName = newMandrilDto.lastName.Replace(" ", "");

            if (string.IsNullOrWhiteSpace(newMandrilDto.name) || string.IsNullOrWhiteSpace(newMandrilDto.lastName))
            {
                _logger.LogWarning(MessageDefaultsDevs.InvalidEntry);
                _logger.LogWarning(MessageDefaultsDevs.MandrilCreationError);
                return null;
            }
            else
            {
                if (newMandrilDto.name.Length < 3 || newMandrilDto.lastName.Length < 3)
                {
                    _logger.LogWarning(MessageDefaultsDevs.InvalidEntry);
                    _logger.LogWarning(MessageDefaultsDevs.MandrilCreationError);
                    return null;
                }
                else
                {
                    Mandril mandril = new Mandril();
                    mandril.name = newMandrilDto.name;
                    mandril.lastName = newMandrilDto.lastName;

                    _contextDb.Mandrils.Add(mandril);
                    _contextDb.SaveChanges();
                    _logger.LogInformation(MessageDefaultsDevs.MandrilCreated);

                    return mandril;
                }
            }
        }

        public MandrilWithSkillsIntermediateTable AssignOneSkillToMandril(int targetMandrilId, int targetSkillId)
        {
            var mandrilExists = _contextDb.Mandrils.FirstOrDefault(m => m.id == targetMandrilId);
            var skillExists = _contextDb.Skills.FirstOrDefault(h => h.id == targetSkillId);
            var relationExist = _contextDb.MandrilWithSkills.Where(r => r.MandrilId == targetMandrilId && r.SkillId == targetSkillId).ToList();

            var relation = new MandrilWithSkillsIntermediateTable();

            if (mandrilExists is null || skillExists is null)
            {
                _logger.LogWarning(MessageDefaultsDevs.ReturnedObjectIsNull, nameof(relationExist));
                _logger.LogWarning(MessageDefaultsDevs.RelationCreationEntityNotFound, targetMandrilId, targetSkillId);
                return null;
            }
            else if (relationExist.Count > 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.RelationAlreadyExists, targetMandrilId, targetSkillId);
                return null;
            }
            else
            {
                relation.MandrilId = targetMandrilId;
                relation.SkillId = targetSkillId;

                _logger.LogInformation(MessageDefaultsDevs.RelationCreated, targetMandrilId, targetSkillId, relation.PowerMS);
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
                _logger.LogWarning(MessageDefaultsDevs.DatabaseNotFound);
                _logger.LogWarning(MessageDefaultsDevs.RelationMandrilWithSkillNotFound, targetSkillId, targetMandrilId);
                _logger.LogWarning(MessageDefaultsDevs.DeleteError);
                return null;
            }
            else
            {
                _contextDb.MandrilWithSkills.Remove(relation);
                _contextDb.SaveChanges();
                _logger.LogInformation(MessageDefaultsDevs.DeleteSuccess);
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
                _logger.LogInformation(MessageDefaultsDevs.DeleteSuccess);
                return skill;
            }
            else
            {
                _logger.LogWarning(MessageDefaultsDevs.SkillNotFound, targetSkillId);
                _logger.LogWarning(MessageDefaultsDevs.DeleteError);
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
                _logger.LogInformation(MessageDefaultsDevs.DeleteSuccess);
                return mandril;
            }
            else
            {
                _logger.LogWarning(MessageDefaultsDevs.SkillNotFound, targetMandrilId);
                _logger.LogWarning(MessageDefaultsDevs.DeleteError);
                return null;
            }
        }

        public Skill UpdateOneSkillToDb(int targetSkillId, SkillDTO skillDto)
        {
            var skill = _contextDb.Skills.FirstOrDefault(s => s.id == targetSkillId);
            if (skill is not null)
            {
                skillDto.name = skillDto.name.Replace(" ", "");

                if (!string.IsNullOrEmpty(skillDto.name))
                {
                    if (skillDto.name.Length < 3)
                    {
                        _logger.LogWarning(MessageDefaultsDevs.InvalidEntry);
                        _logger.LogWarning(MessageDefaultsDevs.UpdateError, targetSkillId);
                        return null;
                    }
                    else
                    {
                        skill.name = skillDto.name;
                        _contextDb.Skills.Update(skill);
                        _contextDb.SaveChanges();
                        _logger.LogInformation(MessageDefaultsDevs.SkillUpdateSuccess, targetSkillId);
                        return skill;
                    }

                }
                else
                {
                    _logger.LogWarning(MessageDefaultsDevs.InvalidEntry);
                    return null;
                }
            }
            else
            {
                _logger.LogWarning(MessageDefaultsDevs.SkillNotFound, targetSkillId);
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
                        _logger.LogWarning(MessageDefaultsDevs.InvalidEntry);
                        _logger.LogWarning(MessageDefaultsDevs.UpdateError, targetMandrilId);
                        return null;
                    }
                    else
                    {
                        mandril.name = mandrilDto.name;
                        mandril.lastName = mandrilDto.lastName;
                        _contextDb.Mandrils.Update(mandril);
                        _contextDb.SaveChanges();
                        _logger.LogInformation(MessageDefaultsDevs.MandrilUpdateSuccess, targetMandrilId);
                        return mandril;
                    }
                }
                else
                {
                    _logger.LogWarning(MessageDefaultsDevs.InvalidEntry);
                    return null;
                }
            }
            else
            {
                _logger.LogWarning(MessageDefaultsDevs.MandrilNotFound, targetMandrilId);
                _logger.LogWarning(MessageDefaultsDevs.UpdateError, targetMandrilId);
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
                _logger.LogInformation(MessageDefaultsDevs.SkillPowerUpdateSuccess, targetSkillId, targetMandrilId, newPower);
                return relation;
            }
            else
            {
                _logger.LogWarning(MessageDefaultsDevs.RelationMandrilWithSkillNotFound, targetSkillId, targetMandrilId);
                _logger.LogWarning(MessageDefaultsDevs.RelationUpdateError, targetSkillId, targetMandrilId);
            }
            return null;
        }
    }
}
