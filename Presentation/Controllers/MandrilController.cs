using MandrilAPI.Aplication.Interfaces;
using MandrilAPI.Aplication.Service;
using MandrilAPI.Domain.Models;
using MandrilAPI.Infrastructure.DTOs;
using MandrilAPI.Infrastructure.ModelsDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]

    public class MandrilController(
        IMandrilSkillsReadRepository RepositoryRead,
        IMandrilSkillsWriteRepository RepositoryWrite) : ControllerBase
    {

        private readonly IMandrilSkillsReadRepository _repositoryReadMandrilSkills = RepositoryRead;
        private readonly IMandrilSkillsWriteRepository _repositoryWriteMandrilSkills = RepositoryWrite;


        [HttpGet]

        public async Task<IActionResult> GetAllMandriles()
        {
            var mandriles = await _repositoryReadMandrilSkills.GetAllMandrilsFromDb();
            
            
            if (mandriles.Count is 0)
            {
                return NotFound(MessageDefaultsUsers.DataBaseNotFound);
            }
            else
            {
                return Ok(mandriles);
            }

        }

        [HttpGet("{targetMandrilId}")]

        public async Task<IActionResult> GetMandrilById(int targetMandrilId)
        {
            var mandril = await _repositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);

            
            if (mandril.Count is 0)
            {
                return BadRequest(MessageDefaultsUsers.MandrilNotFound);
            }

            return Ok(mandril);
        }

        [HttpPut("{targetMandrilId}")]
       
        public async Task<IActionResult> UpdateMandril(int targetMandrilId, [FromBody] MandrilDto mandrilDto)
        {
            var qryMandril = await _repositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);

            
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
                    
                    _repositoryWriteMandrilSkills.UpdateOneMandrilToDb(targetMandrilId, mandrilDto);
                    return Ok(MessageDefaultsUsers.MandrilUpdateSucceeded);

                }
            }
        }


        [HttpDelete("{targetMandrilId}")]
        public async Task<IActionResult> DeleteMandril(int targetMandrilId)
        {
            var checkDelete = await _repositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);
            if (checkDelete.Count is 0)
            {
                return NotFound(MessageDefaultsUsers.MandrilNotFound + "\n" + MessageDefaultsUsers.MandrilNotFound);
            }
            else
            {
                
                _repositoryWriteMandrilSkills.DeleteOneMandrilFromDb(targetMandrilId);
                return Ok(MessageDefaultsUsers.DeleteMandrilSucceeded);
                
            }
            
        }


        [HttpPost]
        public ActionResult<Mandril> AddMandril([FromBody] MandrilDto mandrilDto)
        {
            mandrilDto.name = mandrilDto.name.Replace(" ", "");
            mandrilDto.lastName = mandrilDto.lastName.Replace(" ", "");
            
            if (mandrilDto.name.Length < 3 || mandrilDto.lastName.Length < 3)
            {
                return BadRequest(MessageDefaultsUsers.EntryInvalid);
            }
            else
            {
                
                _repositoryWriteMandrilSkills.AddNewMandrilToDb(mandrilDto);
                return Ok(MessageDefaultsUsers.MandrilCreatedSuccess);
                
            }
        }
    }
}
    


