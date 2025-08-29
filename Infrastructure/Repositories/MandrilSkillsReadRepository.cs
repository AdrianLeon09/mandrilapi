using MandrilAPI.Aplication.Interfaces;
using MandrilAPI.Aplication.Service;
using MandrilAPI.Domain.Models;
using MandrilAPI.Infrastructure.Authentication.AuthDatabaseContext;
using MandrilAPI.Infrastructure.Authentication.AuthModels;
using MandrilAPI.Infrastructure.DatabaseContext;
using MandrilAPI.Infrastructure.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.Infrastructure.Repositories
{
    public class MandrilSkillsReadRepository(
        MandrilDbContext contextDb,
        ILogger<MandrilSkillsReadRepository> logger,
        AuthDbContext contextDbAuth,
        UserManager<ApplicationUser> usermanager,
        SignInManager<ApplicationUser> signinmanager) : IMandrilSkillsReadRepository
    {
        protected readonly MandrilDbContext _contextDb = contextDb;
        private ILogger<MandrilSkillsReadRepository> _logger = logger;

        private readonly UserManager<ApplicationUser> _userM = usermanager;
        private readonly SignInManager<ApplicationUser> _signInM = signinmanager;



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
            else
            {
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
            else
            {
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


        public IReadOnlyList<MandrilWithSkillsIntermediateTable> GetOneMandrilWithOneSkillFromUser(int targetMandrilId,
            int targetSkillId, string userId)
        {
            var relation = _contextDb.MandrilWithSkills.Include(m => m.Mandril).Include(h => h.Skill).Where(m =>
                m.MandrilId == targetMandrilId && m.SkillId == targetSkillId &&
                EF.Functions.Collate(m.UserId, "SQL_Latin1_General_CP1_CI_AS") == userId).AsNoTracking().ToList();

            if (relation.Count is 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.RelationMandrilWithSkillAndUserNotFound, targetSkillId,
                    targetMandrilId, userId);
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


            var relation = _contextDb.MandrilWithSkills.Include(mandriles => mandriles.Mandril)
                .Include(mandrilSkills => mandrilSkills.Skill)
                .Include(p => p.PowerMS)
                .Where(u => EF.Functions.Collate(u.UserId, "SQL_Latin1_General_CP1_CI_AS") == userId).AsNoTracking()
                .ToList();

            if (relation.Count is 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.UserMandrilSkillsNotFound, userId);


                return relation;
            }
            else
            {

                _logger.LogInformation(MessageDefaultsDevs.AllMandrilsWithSkillsRetrieved);
                return relation;
            }

        }

        public IReadOnlyList<MandrilWithSkillsIntermediateTable> SelectOneMandrilWithAllSkillsFromUser(
            int targetMandrilId, string userId)
        {
            var relation = _contextDb.MandrilWithSkills.Include(mandriles => mandriles.Mandril)
                .Include(skills => skills.Skill).Where(m =>
                    m.Mandril.id == targetMandrilId &&
                    EF.Functions.Collate(m.UserId, "SQL_Latin1_General_CP1_CI_AS") == userId).AsNoTracking().ToList();

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

        public async Task<IReadOnlyList<AllUsersDto>> GetAllUsersFromDb() // only admins
        {
            var users = await _userM.Users.ToListAsync();
            var allUsers = new List<AllUsersDto>();



            if (users.Count is 0)
            {
                _logger.LogWarning(MessageDefaultsDevs.UserNotFound);
                return allUsers;
            }
            else
            {
                foreach (var user in users)
                {
                    var Mandrils = await _contextDb.MandrilWithSkills.Where(u => u.UserId == user.Id)
                        .Select(m => m.MandrilId).Distinct().CountAsync();

                    var usersDto = new AllUsersDto();
                    usersDto.FirstName = user.FirstName;
                    usersDto.LastName = user.LastName;
                    usersDto.PublicUserName = user.PublicUserName;
                    usersDto.Email = user.Email;
                    usersDto.NumberOfMandrils = Mandrils;
                    usersDto.CreateAt = user.CreatedAt;



                    allUsers.Add(usersDto);

                }

                _logger.LogInformation(MessageDefaultsDevs.AllUsersRetrieved);
                return allUsers;
            }
        }

        public async Task<IReadOnlyList<UserRelationshipsDto>> GetAllRelationsFromDb() // only admins
        {
            var users = await _userM.Users.ToListAsync();

            var relationsMandrilSkills = await _contextDb.MandrilWithSkills.Include(mandriles => mandriles.Mandril)
                .Include(mandrilSkills => mandrilSkills.Skill).ToListAsync();

            var group = relationsMandrilSkills.GroupBy(u => u.UserId)
                .Select(userkey => new UserRelationshipsDto()
                {
                    
                    PublicUserName = userkey.FirstOrDefault().UserId.ToString(),

                    Mandril = userkey.GroupBy(m=> new {mandrilid = m.MandrilId, mandrilName = m.Mandril.name })
                        .Select(m => new RelationMandrilSkillsDto { Id = m.Key.mandrilid, Name = m.Key.mandrilName, 
                        
                        Skills = userkey
                            .GroupBy(s=>  new {skillId = s.SkillId, skillName = s.Skill.name })
                            .Select(s => new SkillRelationDto() { Id = s.Key.skillId, Name = s.Key.skillName }).Distinct()
                            .ToList()
                        
                    }).Distinct().ToList()
                }).Distinct().ToList();
        
            
            return group.ToList();
            
        }
        /*var lista = new List<UserRelationshipsDto>();

        foreach (var relation in group)
        {
            var dto = new UserRelationshipsDto();

            foreach (var mandril in relation.mandriles)
            {
                dto.Mandriles.Add(new RelationMandrilSkillsDto()
                {
                    Id = mandril.mandrilId,
                     Name = mandril.mandrilNombre
                });

                foreach (var skill in relation.skills)
                {

                }

            }

            lista.Add(dto);

        }
    return lista;*/
        



    }



}

