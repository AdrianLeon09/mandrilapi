using MandrilAPI.Interfaces;
using MandrilAPI.Models;
using MandrilAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]

        public class SkillsController(IMandrilAndSkillsReadRepository RepositoryRead, IMandrilAndSkillsWriteRepository RepositoryWrite) : ControllerBase
        {

            private readonly IMandrilAndSkillsReadRepository _repositoryReadMandrilSkills = RepositoryRead;
            private readonly IMandrilAndSkillsWriteRepository _repositoryWriteMandrilSkills = RepositoryWrite;
            
            
            [HttpGet]
            public ActionResult<Skill> GetAllSkills()
            {
                var Skills = _repositoryReadMandrilSkills.GetAllSkillsFromDb(); ;
                if (Skills.Count is 0)
                {
                    return NotFound(MessageDefaultsUsers.SkillNotFound);
                }
                else
                {
                    return Ok(Skills);
                }

            }

            
            [HttpGet("{targetSkillId}")]
            public ActionResult<Skill> GetSkillById(int targetSkillId)
            {
                var Skill = _repositoryReadMandrilSkills.GetOneSkillFromDb(targetSkillId);

                if (Skill.Count is 0)
                {
                    return BadRequest(MessageDefaultsUsers.SkillNotFound);
                }
                
                return Ok(Skill);
            }

            
            [HttpPut("{targetSkillId}")]
            public ActionResult<Skill> UpdateSkill(int targetSkillId, [FromBody] SkillDTO SkillDto)
            {
                var qrySkill = _repositoryReadMandrilSkills.GetOneSkillFromDb(targetSkillId);

                if (qrySkill.Count is 0)
                {
                    return NotFound(MessageDefaultsUsers.SkillNotFound);
                }
                else
                {
                    SkillDto.name = SkillDto.name.Replace(" ", "");
                    
                    if (SkillDto.name.Length < 3)
                    {
                        return BadRequest(MessageDefaultsUsers.EntryInvalid);

                    }
                    else
                    {
                        
                        _repositoryWriteMandrilSkills.UpdateOneSkillToDb(targetSkillId, SkillDto);
                        return Ok(MessageDefaultsUsers.SkillUpdateSucceeded);

                    }
                }
            }
            
            
            [HttpDelete("{targetSkillId}")]
            public ActionResult<Skill> DeleteSkill(int targetSkillId)
            {
                var checkDelete = _repositoryReadMandrilSkills.GetOneSkillFromDb(targetSkillId);
                if (checkDelete.Count is 0)
                {
                    return NotFound(MessageDefaultsUsers.SkillNotFound);
                }
                else
                {
                    _repositoryWriteMandrilSkills.DeleteOneSkillFromDb(targetSkillId);

                    return Ok(MessageDefaultsUsers.DeleteSkillSucceeded);
                }
            }
            
            
            [HttpPost]
            public ActionResult<Skill> AddSkill([FromBody] SkillDTO SkillDto)
            {
                SkillDto.name = SkillDto.name.Replace(" ", "");
               
                if (SkillDto.name.Length < 3)
                {

                    return BadRequest(MessageDefaultsUsers.DeleteSkillError +  "\n" +  MessageDefaultsUsers.DeleteNotSucceeded);
                }
                else
                {
                    _repositoryWriteMandrilSkills.AddNewSkillToDb(SkillDto);

                    return Ok(MessageDefaultsUsers.SkillCreatedSuccess);
                }
            }

        }
    }

