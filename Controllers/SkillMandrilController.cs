using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using MandrilAPI.DatabaseContext;
using MandrilAPI.Interfaces;
using MandrilAPI.Middleware;
using MandrilAPI.Models;
using MandrilAPI.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MandrilAPI.Controllers;

//// Cada método requerirá que se le especifique un mandrilID en la URL, porque la ruta [Route("api/Mandril/{mandrilID}/[controller]")]
/// lo define como parte obligatoria. Esto permite saber con qué Mandril se está trabajando
[ApiController]
[Route("api/Mandril/{targetMandrilId}/[controller]")]

public class SkillMandrilController(IMandrilAndSkillsWriteRepository RepositoryWrite, IMandrilAndSkillsReadRepository RepositoryRead) : ControllerBase
{
    private readonly IMandrilAndSkillsReadRepository _repositoryReadMandrilSkills = RepositoryRead;
    private readonly IMandrilAndSkillsWriteRepository _repositoryWriteMandrilSkills = RepositoryWrite;


    [HttpGet]
    public IActionResult GetSkillsFromOneMandril(int targetMandrilId)
    {
        var mandrilSkills = _repositoryReadMandrilSkills.SelectOneMandrilWithAllSkills(targetMandrilId);

        
        if (mandrilSkills.Count == 0)
        {
            return NotFound(MessageDefaultsUsers.MandrilNotFound + " \n " + MessageDefaultsUsers.SkillNotFound);
        }
        else
        {
            return Ok(mandrilSkills);
        }
    }

    
    [HttpGet("{targetSkillId}")]
    public IActionResult GetOneSkillFromOneMandril(int targetMandrilId, int targetSkillId)
    {
        var relation = _repositoryReadMandrilSkills.GetOneMandrilWithOneSkillFromDb(targetMandrilId, targetSkillId);
        
        if (relation.Count == 0)
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


