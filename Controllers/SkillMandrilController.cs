
using MandrilAPI.Interfaces;
using MandrilAPI.Models;
using MandrilAPI.Service;
using Microsoft.AspNetCore.Mvc;


namespace MandrilAPI.Controllers;

// Each method will require a mandril ID to be specified in the URL, because the route [Route("api/Mandril/{mandrilID}/[controller]")]

[ApiController]
[Route("api/Mandril/{targetMandrilId}/[controller]")]

public class SkillMandrilController(IMandrilSkillsWriteRepository RepositoryWrite, IMandrilSkillsReadRepository RepositoryRead) : ControllerBase
{
    private readonly IMandrilSkillsReadRepository _repositoryReadMandrilSkills = RepositoryRead;
    private readonly IMandrilSkillsWriteRepository _repositoryWriteMandrilSkills = RepositoryWrite;


    [HttpGet]
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

    
    [HttpGet("{targetSkillId}")]
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

    
    [HttpPut("{targetSkillId}")]
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
  
    
    [HttpPut()] 
    public IActionResult UpdatePowerFromOneSkillInMandril(int targetMandrilId, int targetSkillId, PowerDTO powerDto)
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
    
    
    [HttpDelete("{targetSkillId}")]
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


