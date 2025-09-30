using System.IdentityModel.Tokens.Jwt;
using MandrilAPI.Aplication.Interfaces;
using MandrilAPI.Aplication.Service;
using MandrilAPI.Infrastructure.Authentication.AuthDatabaseContext;
using MandrilAPI.Infrastructure.Authentication.AuthModels;
using MandrilAPI.Infrastructure.DTOs;
using MandrilAPI.Infrastructure.ModelsDTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.Presentation.Controllers;
[ApiController]
[Authorize( AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
    Policy = "AdminOnly")]

[Route("api/admin-management/")]

public class AdminController(
    
    IMandrilSkillsWriteRepository RepositoryWrite,
    IMandrilSkillsReadRepository RepositoryRead,
    AuthDbContext contextDbAuth,
    UserManager<ApplicationUser> usermanager,
    SignInManager<ApplicationUser> signinmanager) : ControllerBase

{

    private readonly UserManager<ApplicationUser> _userM = usermanager;
    private readonly SignInManager<ApplicationUser> _signInM = signinmanager;

    private readonly IMandrilSkillsReadRepository _repositoryReadMandrilSkills = RepositoryRead;
    private readonly IMandrilSkillsWriteRepository _repositoryWriteMandrilSkills = RepositoryWrite;
    private readonly AuthDbContext _contextDbAuth = contextDbAuth;


    [HttpPost("create-relation/mandril/{targetMandrilId}/skill/{targetSkillId}/")]
    
    public async Task<IActionResult> AddSkillAndMandrilForUser(int targetMandrilId, int targetSkillId,
        [FromBody] PublicUserNameDto UserToAdd)
    {

        var user = await _userM.Users.FirstOrDefaultAsync(u =>
            EF.Functions.Collate(u.PublicUserName, "SQL_Latin1_General_CP1_CI_AS") == UserToAdd.PublicUserName);

        if (user is null)
        {
            return NotFound(MessageDefaultsAdmin.UserNotFound);
        }
        else
        {
            var mandrilExists = await _repositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);
            var skillExists = await _repositoryReadMandrilSkills.GetOneSkillFromDb(targetSkillId);


            var relationExists =
                await _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromUser(targetMandrilId, targetSkillId, user.Id);

            if (mandrilExists.Count is 0 || skillExists.Count is 0)
            {
                return NotFound(MessageDefaultsAdmin.RelationCreationEntityNotFound);
            }
            else if (relationExists.Count > 0)
            {
                return Conflict(MessageDefaultsAdmin.RelationAlreadyExist);
            }
            else
            {

               await _repositoryWriteMandrilSkills.AssignOneSkillToMandril(targetMandrilId, targetSkillId, user.Id);
                return Ok(MessageDefaultsAdmin.AssingSkillToMandrilSucceeded);

            }
        }
    }


    [HttpDelete("delete-skills/mandril/{targetMandrilId}/skill/{targetSkillId}/")]
  
    public async Task<IActionResult> DeleteOneSkillFromMandrilUser(int targetMandrilId, int targetSkillId,
        PublicUserNameDto UserToDelete)
    {
        var user = await _userM.Users.FirstOrDefaultAsync(u =>
            EF.Functions.Collate(u.PublicUserName, "SQL_Latin1_General_CP1_CI_AS") == UserToDelete.PublicUserName);

        if (user is null)
        {
            return NotFound(MessageDefaultsAdmin.UserNotFound);
        }
        else
        {

            var relation =
                    await _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromUser(targetMandrilId, targetSkillId, user.Id);

            if (relation.Count is 0)
            {

                return NotFound(MessageDefaultsAdmin.RelationNotFound);

            }
            else
            {

                await _repositoryWriteMandrilSkills.DeleteSkillFromMandrilForUser(targetMandrilId, targetSkillId, user.Id);
                return Ok(MessageDefaultsAdmin.DeleteSkillSucceeded);

            }
        }

    }

    [HttpDelete("delete-mandril/{targetMandrilId}/")]
  
    public async Task<IActionResult> DeleteOneMandrilForUser(int targetMandrilId,
        PublicUserNameDto userToDelete)
    {
        var user = await _userM.Users.FirstOrDefaultAsync(u =>
            EF.Functions.Collate(u.PublicUserName, "SQL_Latin1_General_CP1_CI_AS") == userToDelete.PublicUserName);

        {
            
            if ( user is null)
            {

                return NotFound(MessageDefaultsAdmin.RelationMandrilUserNotFound);

            }
            else
            {
                var relation =
                    await _repositoryReadMandrilSkills.SelectOneMandrilWithAllSkillsFromUser(targetMandrilId, user.Id);
                
                if (relation.Count is 0)
                {
                    return NotFound(MessageDefaultsAdmin.RelationNotFound);
                }
                else
                {

                    await _repositoryWriteMandrilSkills.DeleteMandrilForUser(targetMandrilId, user.Id);
                    return Ok(MessageDefaultsAdmin.DeleteSkillSucceeded);

                }
            }
        }

    }


    [HttpPut("update-power/mandril/{targetMandrilId}/skill/{targetSkillId}/")]
   
    
    public async Task<IActionResult> UpdatePowerFromOneSkillInMandril(int targetMandrilId, int targetSkillId,
        [FromBody]UpdatePowerRequestDto updatePowerRequest)
    {
        var user = await _userM.Users.FirstOrDefaultAsync(u =>
            EF.Functions.Collate(u.PublicUserName, "SQL_Latin1_General_CP1_CI_AS") == updatePowerRequest.PublicUserName);

        if (user is null)
        {
            return NotFound(MessageDefaultsAdmin.UserNotFound);
        }
        else
        {
            var relation =
                await _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromUser(targetMandrilId, targetSkillId, user.Id);

            if (relation.Count is 0)
            {
                return NotFound(MessageDefaultsAdmin.RelationMandrilWithSkillAndUserNotFound);
            }
            else
            {

              await  _repositoryWriteMandrilSkills.UpdatePowerOfSkillForMandril(targetMandrilId, targetSkillId,
                   updatePowerRequest.Power, user.Id);
                return Ok(MessageDefaultsAdmin.SkillPowerUpdateSuccess);

            }
        }
    }

    [HttpGet("GetAllUsers/")]

    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _repositoryReadMandrilSkills.GetAllUsersFromDb();


        if (users.Count is 0)
        {
            return NotFound(MessageDefaultsAdmin.UserNotFound);
        }
        else
        {
            
            return Ok(users);
        }

    }


    [HttpGet("GetAllRelations")]
    
    public async Task<IActionResult> GetAllRelations()
    {
        var relations = await _repositoryReadMandrilSkills.GetAllRelationsFromDb();
        
        if (relations.Count is 0)
        {
            return NotFound(MessageDefaultsAdmin.RelationshipsNotFound);
        }
        else
        {
            return Ok(relations);
        }

    }
}

    
       
