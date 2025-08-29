using MandrilAPI.Aplication.Interfaces;
using MandrilAPI.Aplication.Service;
using MandrilAPI.Domain.Models;
using MandrilAPI.Infrastructure.Authentication.AuthDatabaseContext;
using MandrilAPI.Infrastructure.Authentication.AuthModels;
using MandrilAPI.Infrastructure.DatabaseContext;
using MandrilAPI.Infrastructure.DTOs;
using MandrilAPI.Infrastructure.ModelsDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.Infrastructure.Repositories
{
    public class MandrilSkillsWriteRepository(MandrilDbContext contextDb, ILogger<MandrilSkillsWriteRepository> logger, AuthDbContext contextDbAuth,
    UserManager<ApplicationUser> usermanager,
    SignInManager<ApplicationUser> signinmanager) : IMandrilSkillsWriteRepository
    {
        private readonly UserManager<ApplicationUser> _userM = usermanager;
        private readonly SignInManager<ApplicationUser> _signInM = signinmanager;
        
        private readonly MandrilDbContext _contextDb = contextDb;
        private readonly ILogger _logger = logger;

        public Skill AddNewSkillToDb(SkillDto newSkillDto)
        {
            Skill skill = new Skill();
            skill.name = newSkillDto.Name.Replace(" ", "");

            if (!string.IsNullOrWhiteSpace(newSkillDto.Name))
            {
                if (newSkillDto.Name.Length < 3)
                {
                    _logger.LogWarning(MessageDefaultsDevs.InvalidEntry);
                    _logger.LogWarning(MessageDefaultsDevs.SkillCreationError);      
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

        public Mandril AddNewMandrilToDb(MandrilDto newMandrilDto)
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


        public Skill UpdateOneSkillToDb(int targetSkillId, SkillDto newSkillDto)
        {
            var skill = _contextDb.Skills.FirstOrDefault(s => s.id == targetSkillId);

            if (skill is not null)
            {
                newSkillDto.Name = newSkillDto.Name.Replace(" ", "");

                if (!string.IsNullOrEmpty(newSkillDto.Name))
                {
                    if (newSkillDto.Name.Length < 3)
                    {

                        _logger.LogWarning(MessageDefaultsDevs.InvalidEntry);
                        _logger.LogWarning(MessageDefaultsDevs.UpdateError, targetSkillId);
                        return null;
                    }
                    else
                    {

                        skill.name = newSkillDto.Name;
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


        public Mandril UpdateOneMandrilToDb(int targetMandrilId, MandrilDto mandrilDto)
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


 public MandrilWithSkillsIntermediateTable AssignOneSkillToMandril(int targetMandrilId, int targetSkillId, string userId) //Only Admins
        {
            var relation = new MandrilWithSkillsIntermediateTable();
            
            var mandrilExists = _contextDb.Mandrils.FirstOrDefault(m => m.id == targetMandrilId);
            var skillExists = _contextDb.Skills.FirstOrDefault(h => h.id == targetSkillId);
            var userExist = _userM.Users.FirstOrDefault(u=> EF.Functions.Collate(u.Id, "SQL_Latin1_General_CP1_CI_AS") == userId) ;

            var relationExist = _contextDb.MandrilWithSkills.Where(r => r.MandrilId == targetMandrilId && r.SkillId == targetSkillId
                && EF.Functions.Collate(r.UserId,"SQL_Latin1_General_CP1_CI_AS") == userId).ToList();
            
           
  if (userExist is null)
            {
                _logger.LogWarning(MessageDefaultsDevs.UserNotFound, userId);
                return null;

            }
            else  if (mandrilExists is null || skillExists is null)
                
            {
                _logger.LogWarning(MessageDefaultsDevs.ReturnedObjectIsNull, nameof(relationExist));
                _logger.LogWarning(MessageDefaultsDevs.RelationCreationEntityNotFound, targetMandrilId, targetSkillId);
                return null;
            }
          
            else if (relationExist.Count > 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.RelationAlreadyExists, targetMandrilId, targetSkillId, userId);
                return null;
            }
            else
            {

                relation.MandrilId = targetMandrilId;
                relation.SkillId = targetSkillId;
                relation.UserId = userId;

                _logger.LogInformation(MessageDefaultsDevs.RelationCreated, targetMandrilId, targetSkillId, userId, relation.PowerMS);
                _contextDb.MandrilWithSkills.Add(relation);
                _contextDb.SaveChanges();
                return relation;

            }
        }


        public MandrilWithSkillsIntermediateTable DeleteSkillFromMandrilForUser(int targetMandrilId, int targetSkillId, string userId) // Only Admins
        {
            var relation = _contextDb.MandrilWithSkills
                  .FirstOrDefault(m => m.MandrilId == targetMandrilId && m.SkillId == targetSkillId && EF.Functions.Collate(m.UserId, "SQL_Latin1_General_CP1_CI_AS") == userId) ;

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
        
        public async Task<MandrilWithSkillsIntermediateTable> DeleteMandrilForUser(int targetMandrilId, string userId) // Only Admins
        {
            var relation = await  _contextDb.MandrilWithSkills
                .FirstOrDefaultAsync(m => m.MandrilId == targetMandrilId && EF.Functions.Collate(m.UserId, "SQL_Latin1_General_CP1_CI_AS") == userId) ;

            if (relation is null)
            {

                _logger.LogWarning(MessageDefaultsDevs.DatabaseNotFound);
                _logger.LogWarning(MessageDefaultsDevs.RelationMandrilUserNotFound, targetMandrilId, userId );
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


        public MandrilWithSkillsIntermediateTable UpdatePowerOfSkillForMandril(int targetMandrilId, int targetSkillId, int newPower, string userId) //Only Admins
        {
            var relation = _contextDb.MandrilWithSkills.FirstOrDefault(m => m.MandrilId == targetMandrilId && m.SkillId == targetSkillId && EF.Functions.Collate(m.UserId, "SQL_Latin1_General_CP1_CI_AS") == userId);

            if (relation is not null)
            {

                relation.PowerMS = newPower;
                _contextDb.MandrilWithSkills.Update(relation);
                _contextDb.SaveChanges();
                _logger.LogInformation(MessageDefaultsDevs.SkillPowerUpdateSuccess, targetSkillId, targetMandrilId, newPower,userId);
                return relation;

            }
            else
            {
                _logger.LogWarning(MessageDefaultsDevs.RelationMandrilWithSkillAndUserNotFound, targetSkillId, targetMandrilId, userId);
                _logger.LogWarning(MessageDefaultsDevs.RelationUpdateError, targetSkillId, targetMandrilId);
                return null;
            }
            
        }
    }
}
