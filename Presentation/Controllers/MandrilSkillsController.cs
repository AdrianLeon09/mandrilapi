using MandrilAPI.Aplication.Interfaces;
using MandrilAPI.Aplication.Service;
using MandrilAPI.Infrastructure.Authentication.AuthDatabaseContext;
using MandrilAPI.Infrastructure.Authentication.AuthModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]/relations/")]

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
    Roles = "Admin,User")]
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
        if (user is null)
        {
            return BadRequest(MessageDefaultsUsers.UserNotFound);
        }else
        {
            var relation =
                await _repositoryReadMandrilSkills.SelectOneMandrilWithAllSkillsFromUser(targetMandrilId, user.Id);

            if (relation.Count is 0)
            {
                return NotFound(MessageDefaultsUsers.RelationNotFound);
            }else
            {
                return Ok(relation);
            }
        }
    }

    [HttpGet("mandrils/get-allrelations/")]
    public async Task<IActionResult> GetAllRelations()
    {
        var user = await _userM.GetUserAsync(User);
        
        if (user is null)
        {
            return NotFound(MessageDefaultsUsers.UserNotFound);
        }else
        {
            var relations = await _repositoryReadMandrilSkills.SelectAllMandrilWithSkillsFromUser(user.Id);
            if(relations.Count is 0)
            {
                return NotFound(MessageDefaultsUsers.EmptyRelations);
            } 
            return Ok(relations);
        }
    }



    [HttpGet("mandrils/{targetMandrilId}/skill/{targetSkillId}")]

    public async Task<IActionResult> GetOneSkillFromOneMandril(int targetMandrilId, int targetSkillId)
    {
        var user = await _userM.GetUserAsync(User);
        
        if (user is null)
        {
            return NotFound(MessageDefaultsAdmin.UserNotFound);
        }
        
        var relation = await
              _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromUser(targetMandrilId, targetSkillId, user.Id);

            if (relation.Count is 0)
            {
                return NotFound(MessageDefaultsUsers.RelationNotFound);
            }else
            {
                return Ok(relation);
            }
    }
    
    [HttpDelete("mandrils/{targetMandrilId}/skill/{targetSkillId}")]
    public async Task<IActionResult> DeleteOneSkillFromMandril(int targetMandrilId, int targetSkillId)
    {
        var user = await _userM.GetUserAsync(User);

        if (user is null)
        {
            return NotFound(MessageDefaultsAdmin.UserNotFound);
        }else
        {
            var relation =
                await _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromUser(targetMandrilId, targetSkillId, user.Id);

            if (relation.Count is 0)
            {
                return NotFound(MessageDefaultsUsers.RelationNotFound);
            }else
            {
                await _repositoryWriteMandrilSkills.DeleteSkillFromMandrilForUser(targetMandrilId, targetSkillId, user.Id);
                return Ok(MessageDefaultsUsers.DeleteSkillSucceeded);

            }
        }
    }
}


