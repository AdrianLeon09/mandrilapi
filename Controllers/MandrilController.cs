using MandrilAPI.DatabaseContext;
using MandrilAPI.Interfaces;
using MandrilAPI.Models;
using MandrilAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;


namespace MandrilAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MandrilController(IMandrilAndSkillsReadRepository RepositoryRead, IMandrilAndSkillsWriteRepository RepositoryWrite) : ControllerBase
    {
    
        private readonly IMandrilAndSkillsReadRepository _RepositoryReadMandrilSkills = RepositoryRead;
        private readonly IMandrilAndSkillsWriteRepository _RepositoryWriteMandrilSkills = RepositoryWrite;
   

        [HttpGet]
    public ActionResult<Mandril> GetAllMandriles()
    {
         
            var mandriles = _RepositoryReadMandrilSkills.GetAllMandrilsFromDb(); ;
            if (mandriles.Count is 0) { 
                return NotFound(MessageDefaultsUsers.MandrilNotFound);
            }
            else {
                return Ok(mandriles);}
            
            
           
    }
    
    [HttpGet("{targetMandrilId}")]
    public ActionResult<Mandril> GetMandrilById(int targetMandrilId)
    {
            var mandril = _RepositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);

        if (mandril.Count is  0)
        {
            return BadRequest(MessageDefaultsUsers.MandrilNotFound);  
        }
            return Ok(mandril);
              
    }
    
    [HttpPut("{targetMandrilId}")]
    public ActionResult<Mandril> UpdateMandril(int targetMandrilId, [FromBody] MandrilDTO mandrilDto)
    {

            
            var qryMandril = _RepositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);

            if (qryMandril.Count is 0)
            {
                return NotFound(MessageDefaultsUsers.MandrilNotFound);
            }
            else
            {
                mandrilDto.name = mandrilDto.name.Replace(" ", "");
                mandrilDto.lastName = mandrilDto.lastName.Replace(" ", "");

                if (mandrilDto.name.Length < 3 || mandrilDto.lastName.Length < 3)
                {
                    return BadRequest(MessageDefaultsUsers.EntryInvalid);

                }
                else
                {
                    _RepositoryWriteMandrilSkills.UpdateOneMandrilToDb(targetMandrilId, mandrilDto);

                    return Ok(MessageDefaultsUsers.MandrilUpdateSucceeded);

                }
            }
    }
    
    
    [HttpDelete("{targetMandrilId}")]
        public ActionResult<Mandril> DeleteMandril(int targetMandrilId)
    {
            var checkDelete = _RepositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);
            if (checkDelete.Count is 0)
            { 
            return NotFound(MessageDefaultsUsers.MandrilNotFound);
            }
            else
            {
            _RepositoryWriteMandrilSkills.DeleteOneMandrilFromDb(targetMandrilId);
           
            return Ok(MessageDefaultsUsers.DeleteMandrilSucceeded);
        }
    }
        [HttpPost]

        
        public ActionResult<Mandril> AddMandril([FromBody]MandrilDTO mandrilDto)
        {
            mandrilDto.name = mandrilDto.name.Replace(" ", "");
            mandrilDto.lastName = mandrilDto.lastName.Replace(" ", "");
            if (mandrilDto.name.Length < 3 || mandrilDto.lastName.Length < 3)
            {
                return BadRequest(MessageDefaultsUsers.EntryInvalid);
            }
            else
            {
            _RepositoryWriteMandrilSkills.AddNewMandrilToDb(mandrilDto);

                 return Ok(MessageDefaultsUsers.MandrilCreatedSuccessfully);
            }
        }
    
    }
    }


