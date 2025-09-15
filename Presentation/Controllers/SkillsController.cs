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

        public class SkillsController(IMandrilSkillsReadRepository RepositoryRead, IMandrilSkillsWriteRepository RepositoryWrite) : ControllerBase
        {

            private readonly IMandrilSkillsReadRepository _repositoryReadMandrilSkills = RepositoryRead;
            private readonly IMandrilSkillsWriteRepository _repositoryWriteMandrilSkills = RepositoryWrite;
            
            
            [HttpGet]
            public async Task<IActionResult> GetAllSkills()
            {
                var Skills = await _repositoryReadMandrilSkills.GetAllSkillsFromDb();
                if (Skills.Count is 0)
                {
                    return NotFound(MessageDefaultsUsers.DataBaseNotFound);
                }
                else
                {
                    return Ok(Skills);
                }

            }

            
            [HttpGet("{targetSkillId}")]
            public async Task<IActionResult> GetSkillById(int targetSkillId)
            {
                var Skill = await _repositoryReadMandrilSkills.GetOneSkillFromDb(targetSkillId);

                if (Skill.Count is 0)
                {
                    return NotFound(MessageDefaultsUsers.SkillNotFound);
                }
                
                return Ok(Skill);
            }

            
            [HttpPut("{targetSkillId}")]
            public async Task<IActionResult> UpdateSkill(int targetSkillId, [FromBody] SkillDto skillDto)
            {
                var qrySkill = await _repositoryReadMandrilSkills.GetOneSkillFromDb(targetSkillId);

                if (qrySkill.Count is 0)
                {
                    return NotFound(MessageDefaultsUsers.SkillNotFound);
                }
                else
                {
                    skillDto.Name = skillDto.Name.Replace(" ", "");
                    
                    if (skillDto.Name.Length < 3)
                    {
                        return BadRequest(MessageDefaultsUsers.EntryInvalid);

                    }
                    else
                    {
                        
                     await  _repositoryWriteMandrilSkills.UpdateOneSkillToDb(targetSkillId, skillDto);
                        return Ok(MessageDefaultsUsers.SkillUpdateSucceeded);

                    }
                }
            }
            
            
            [HttpDelete("{targetSkillId}")]
            public async Task<IActionResult> DeleteSkill(int targetSkillId)
            {
                var checkDelete = await _repositoryReadMandrilSkills.GetOneSkillFromDb(targetSkillId);
                if (checkDelete.Count is 0)
                {
                    return NotFound(MessageDefaultsUsers.SkillNotFound);
                }
                else
                {
                    await  _repositoryWriteMandrilSkills.DeleteOneSkillFromDb(targetSkillId);

                    return Ok(MessageDefaultsUsers.DeleteSkillSucceeded);
                }
            }
            
            
            [HttpPost]
            public async Task<ActionResult<Skill>> AddSkill([FromBody] SkillDto skillDto)
            {
               
               
               var skillInDb = await _repositoryReadMandrilSkills.GetAllSkillsFromDb();

               var validationName = skillInDb.Any(s =>
                   string.Equals(s.name, skillDto.Name, StringComparison.OrdinalIgnoreCase));
            

                if (validationName is true)
                {
                   return Conflict(MessageDefaultsUsers.SkillAlreadyExists);

                }
                else
                {

                    if (skillDto.Name.Length < 3)
                    {

                        return BadRequest(MessageDefaultsUsers.DeleteSkillError + "\n" +
                                          MessageDefaultsUsers.DeleteNotSucceeded);
                    }
                    else
                    {
                        await _repositoryWriteMandrilSkills.AddNewSkillToDb(skillDto);

                        return Ok(MessageDefaultsUsers.SkillCreatedSuccess);
                    }
                }
            }

        }
    }

