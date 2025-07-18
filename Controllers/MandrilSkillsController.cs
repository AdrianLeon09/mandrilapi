
using MandrilAPI.Interfaces;
using MandrilAPI.Models;
using MandrilAPI.Service;
using Microsoft.AspNetCore.Mvc;
namespace MandrilAPI.Controllers;


[Route("api/[controller]/relations/")]
public class MandrilSkillsController(IMandrilSkillsWriteRepository RepositoryWrite, IMandrilSkillsReadRepository RepositoryRead) : ControllerBase
{
    private readonly IMandrilSkillsReadRepository _repositoryReadMandrilSkills = RepositoryRead;
    private readonly IMandrilSkillsWriteRepository _repositoryWriteMandrilSkills = RepositoryWrite;

    [HttpGet("mandrils/{targetMandrilId}/skills/")]
    public IActionResult GetSkillsFromOneMandril(int targetMandrilId)
    {
        var relation = _repositoryReadMandrilSkills.SelectOneMandrilWithAllSkills(targetMandrilId);

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
    public IActionResult GetOneSkillFromOneMandril(int targetMandrilId, int targetSkillId)
    {
        var relation = _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromDb(targetMandrilId, targetSkillId);

        if (relation.Count is 0)
        {
            return NotFound(MessageDefaultsUsers.RelationNotFound);
        }
        else
        {
            return Ok(relation);
        }
        
    }

    
    [HttpPost("mandrils/{targetMandrilId}/skill/{targetSkillId}")]
    public IActionResult AddSkillToMandril(int targetMandrilId, int targetSkillId)
    {
        var mandrilExists = _repositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);
        var skillExists = _repositoryReadMandrilSkills.GetOneSkillFromDb(targetSkillId);
        var relationExists = _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromDb(targetMandrilId, targetSkillId);

        if (mandrilExists.Count is 0 || skillExists.Count is 0 )
        {                                                                       
            return BadRequest( MessageDefaultsUsers.RelationCreationEntityNotFound);
        }
        else if (relationExists.Count > 0)
        {
           return BadRequest(MessageDefaultsUsers.RelationAlreadyExists);
        }
        else
        {
            
            _repositoryWriteMandrilSkills.AssignOneSkillToMandril(targetMandrilId, targetSkillId);
            return Ok(MessageDefaultsUsers.AssingSkillToMandrilSucceeded);
            
        }
 
    } 
  
    
    [HttpPut("mandrils/{targetMandrilId}/skill/{targetSkillId}/update-power/")] 
    public IActionResult UpdatePowerFromOneSkillInMandril(int targetMandrilId, int targetSkillId, [FromBody]PowerDto powerDto)
    {
         var MandrilSkillRelation = _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromDb(targetMandrilId, targetSkillId);

        if(MandrilSkillRelation.Count is 0) { 
            return BadRequest(MessageDefaultsUsers.RelationNotFound);
        }
        else
        {
            
         _repositoryWriteMandrilSkills.UpdatePowerOfSkillForMandril(targetMandrilId, targetSkillId, powerDto.Power);
            return Ok(MessageDefaultsUsers.SkillPowerUpdateSuccess);
            
        }
    }
    
    
    [HttpDelete("mandrils/{targetMandrilId}/skill/{targetSkillId}")]
    public IActionResult DeleteOneSkillFromMandril(int targetMandrilId, int targetSkillId)
    {
        var relation = _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromDb (targetMandrilId, targetSkillId);
       
        if (relation.Count is 0 )
        {

            return BadRequest(MessageDefaultsUsers.RelationNotFound);

        }
        else {

            _repositoryWriteMandrilSkills.DeleteSkillFromMandril(targetMandrilId, targetSkillId);
            return Ok(MessageDefaultsUsers.DeleteSkillSucceeded);

        }
        
    }

}


