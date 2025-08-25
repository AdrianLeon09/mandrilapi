using MandrilAPI.Aplication.Interfaces;
using MandrilAPI.Aplication.Service;
using MandrilAPI.Infrastructure.Authentication.AuthDatabaseContext;
using MandrilAPI.Infrastructure.Authentication.AuthModels;
using MandrilAPI.Infrastructure.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MandrilAPI.Presentation.Controllers;


[Route("api/[controller]/relations/")]
public class MandrilSkillsController(
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


    [HttpGet("mandrils/{targetMandrilId}/skills/")]
    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> GetSkillsFromOneMandril(int targetMandrilId)
    {

        var user = await _userM.GetUserAsync(User);


        var relation = _repositoryReadMandrilSkills.SelectOneMandrilWithAllSkillsFromUser(targetMandrilId, user.Id);

        if (relation.Count is 0)
        {
            return NotFound(MessageDefaultsUsers.RelationNotFound);
        }
        else
        {
            return Ok(relation);
        }
    }


    [HttpGet("mandrils/{targetMandrilId}/skill/{targetSkillId}")]
    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> GetOneSkillFromOneMandril(int targetMandrilId, int targetSkillId)
    {
        var user = await _userM.GetUserAsync(User);

        var relation =
            _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromUser(targetMandrilId, targetSkillId, user.Id);

        if (relation.Count is 0)
        {
            return NotFound(MessageDefaultsUsers.RelationNotFound);
        }
        else
        {
            return Ok(relation);
        }

    }


    [HttpPost("mandrils/{targetMandrilId}/skill/{targetSkillId}")] //Only Admins
    //  [Authorize(Policy = "Admin")]
    public async Task<IActionResult> AddSkillToMandril(int targetMandrilId, int targetSkillId,
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
            var mandrilExists = _repositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);
            var skillExists = _repositoryReadMandrilSkills.GetOneSkillFromDb(targetSkillId);


            var relationExists =
                _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromUser(targetMandrilId, targetSkillId, user.Id);

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


    [HttpPut("mandrils/{targetMandrilId}/skill/{targetSkillId}/update-power/")] //Only Admins 
    [Authorize(Policy = "Admin")]
    public async Task<IActionResult> UpdatePowerFromOneSkillInMandril(int targetMandrilId, int targetSkillId,
        [FromBody] PowerDto powerDto, PublicUserNameDto UserToAdd)
    {
        var user = _userM.Users.FirstOrDefault(u =>
            EF.Functions.Collate(u.PublicUserName, "SQL_Latin1_General_CP1_CI_AS") == UserToAdd.PublicUserName);

        if (user is null)
        {
            return NotFound(MessageDefaultsUsers.UserNotFound);
        }
        else
        {
            var relation =
                _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromUser(targetMandrilId, targetSkillId, user.Id);

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


    [HttpDelete("mandrils/{targetMandrilId}/skill/{targetSkillId}")]
    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> DeleteOneSkillFromMandrilFromUser(int targetMandrilId, int targetSkillId)
    {
        var user = await _userM.GetUserAsync(User);

        {
            var relation =
                _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromUser(targetMandrilId, targetSkillId, user.Id);

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
}


