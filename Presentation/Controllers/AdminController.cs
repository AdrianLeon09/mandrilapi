using MandrilAPI.Aplication.Interfaces;
using MandrilAPI.Aplication.Service;
using MandrilAPI.Infrastructure.Authentication.AuthDatabaseContext;
using MandrilAPI.Infrastructure.Authentication.AuthModels;
using MandrilAPI.Infrastructure.DTOs;
using MandrilAPI.Infrastructure.ModelsDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.Presentation.Controllers;

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
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> AddSkillAndMandrilForUser(int targetMandrilId, int targetSkillId,
        [FromBody] PublicUserNameDto UserToAdd)
    {
        var user = await _userM.Users.FirstOrDefaultAsync(u =>
            EF.Functions.Collate(u.PublicUserName, "SQL_Latin1_General_CP1_CI_AS") == UserToAdd.PublicUserName);

        if (user is null)
        {
            return NotFound(MessageDefaultsUsers.UserNotFound);
        }
        else
        {
            var mandrilExists = await _repositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);
            var skillExists = await _repositoryReadMandrilSkills.GetOneSkillFromDb(targetSkillId);


            var relationExists =
                await _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromUser(targetMandrilId, targetSkillId, user.Id);

            if (mandrilExists.Count is 0 || skillExists.Count is 0)
            {
                return BadRequest(MessageDefaultsUsers.RelationCreationEntityNotFound);
            }
            else if (relationExists.Count > 0)
            {
                return BadRequest(MessageDefaultsUsers.RelationAlreadyExists);
            }
            else
            {

                _repositoryWriteMandrilSkills.AssignOneSkillToMandril(targetMandrilId, targetSkillId, user.Id);
                return Ok(MessageDefaultsUsers.AssingSkillToMandrilSucceeded);

            }
        }
    }


    [HttpDelete("delete-skills/mandril/{targetMandrilId}/skill/{targetSkillId}/")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> DeleteOneSkillFromMandrilUser(int targetMandrilId, int targetSkillId,
        PublicUserNameDto UserToDelete)
    {
        var user = await _userM.Users.FirstOrDefaultAsync(u =>
            EF.Functions.Collate(u.PublicUserName, "SQL_Latin1_General_CP1_CI_AS") == UserToDelete.PublicUserName);

        {
            var relation =
                await _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromUser(targetMandrilId, targetSkillId, user.Id);

            if (relation.Count is 0)
            {

                return BadRequest(MessageDefaultsUsers.RelationNotFound);

            }
            else
            {

                _repositoryWriteMandrilSkills.DeleteSkillFromMandrilForUser(targetMandrilId, targetSkillId, user.Id);
                return Ok(MessageDefaultsUsers.DeleteSkillSucceeded);

            }

        }

    }

    [HttpDelete("delete-mandril/{targetMandrilId}/")]
   [Authorize(Policy = "Admin")]
    public async Task<IActionResult> DeleteOneMandrilForUser(int targetMandrilId,
        PublicUserNameDto userToDelete)
    {
        var user = await _userM.Users.FirstOrDefaultAsync(u =>
            EF.Functions.Collate(u.PublicUserName, "SQL_Latin1_General_CP1_CI_AS") == userToDelete.PublicUserName);

        {
            
            if ( user is null)
            {

                return BadRequest(MessageDefaultsAdmin.RelationMandrilUserNotFound);

            }
            else
            {
                var relation =
                    await _repositoryReadMandrilSkills.SelectOneMandrilWithAllSkillsFromUser(targetMandrilId, user.Id);
                
                if (relation.Count is 0)
                {
                    return BadRequest(MessageDefaultsUsers.RelationNotFound);
                }
                else
                {

                    await _repositoryWriteMandrilSkills.DeleteMandrilForUser(targetMandrilId, user.Id);
                    return Ok(MessageDefaultsUsers.DeleteSkillSucceeded);

                }
            }
        }

    }


    [HttpPut("update-power/{targetMandrilId}/skill/{targetSkillId}/")]
    [Authorize(Policy = "Admin")]
    
    public async Task<IActionResult> UpdatePowerFromOneSkillInMandril(int targetMandrilId, int targetSkillId,
        [FromBody] PowerDto powerDto, PublicUserNameDto UserToAdd)
    {
        var user = await _userM.Users.FirstOrDefaultAsync(u =>
            EF.Functions.Collate(u.PublicUserName, "SQL_Latin1_General_CP1_CI_AS") == UserToAdd.PublicUserName);

        if (user is null)
        {
            return NotFound(MessageDefaultsUsers.UserNotFound);
        }
        else
        {
            var relation =
                await _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromUser(targetMandrilId, targetSkillId, user.Id);

            if (relation.Count is 0)
            {
                return BadRequest(MessageDefaultsUsers.RelationMandrilWithSkillAndUserNotFound);
            }
            else
            {

                _repositoryWriteMandrilSkills.UpdatePowerOfSkillForMandril(targetMandrilId, targetSkillId,
                    powerDto.Power, user.Id);
                return Ok(MessageDefaultsUsers.SkillPowerUpdateSuccess);

            }
        }
    }

    [HttpGet("GetAllUsers/")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _repositoryReadMandrilSkills.GetAllUsersFromDb();


        if (users.Count is 0)
        {
            return NotFound(MessageDefaultsDevs.UsersNotFound);
        }
        else
        {
            
            return Ok(users);
        }

    }


    [HttpGet("GetAllRelations")]
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> GetAllRelations()
    {
        var relations = await _repositoryReadMandrilSkills.GetAllRelationsFromDb();


        if (relations.Count is 0)
        {
            return NotFound(MessageDefaultsDevs.RelationshipsNotFound);
        }
        else
        {
            return Ok(relations);
        }

    }
}

    
       
