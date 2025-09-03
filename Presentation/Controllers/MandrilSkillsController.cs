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
[Authorize(Roles = "User,Admin")]
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

    public async Task<IActionResult> GetSkillsFromOneMandril(int targetMandrilId)
    {

        var user = await _userM.GetUserAsync(User);


        var relation =
            await _repositoryReadMandrilSkills.SelectOneMandrilWithAllSkillsFromUser(targetMandrilId, user.Id);

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
 
    public async Task<IActionResult> GetOneSkillFromOneMandril(int targetMandrilId, int targetSkillId)
    {
        
        var user = await _userM.GetUserAsync(User);

        var relation = await 
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
    [HttpDelete("mandrils/{targetMandrilId}/skill/{targetSkillId}")]
  
    public async Task<IActionResult> DeleteOneSkillFromMandril(int targetMandrilId, int targetSkillId)
    {
        var user = await _userM.GetUserAsync(User);

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
}


