using MandrilAPI.DatabaseContext;
using MandrilAPI.Interfaces;
using MandrilAPI.Models;
using MandrilAPI.Service;
using Microsoft.AspNetCore.Mvc;



namespace MandrilAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MandrilController(
        IMandrilSkillsReadRepository RepositoryRead,
        IMandrilSkillsWriteRepository RepositoryWrite) : ControllerBase
    {

        private readonly IMandrilSkillsReadRepository _repositoryReadMandrilSkills = RepositoryRead;
        private readonly IMandrilSkillsWriteRepository _repositoryWriteMandrilSkills = RepositoryWrite;


        [HttpGet]
        public ActionResult<Mandril> GetAllMandriles()
        {
            var mandriles = _repositoryReadMandrilSkills.GetAllMandrilsFromDb();
            
            
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
        public ActionResult<Mandril> GetMandrilById(int targetMandrilId)
        {
            var mandril = _repositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);

            
            if (mandril.Count is 0)
            {
                return BadRequest(MessageDefaultsUsers.MandrilNotFound);
            }

            return Ok(mandril);
        }

        [HttpPut("{targetMandrilId}")]
        public ActionResult<Mandril> UpdateMandril(int targetMandrilId, [FromBody] MandrilDTO mandrilDto)
        {
            var qryMandril = _repositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);

            
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
        public ActionResult<Mandril> DeleteMandril(int targetMandrilId)
        {
            var checkDelete = _repositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);
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
        public ActionResult<Mandril> AddMandril([FromBody] MandrilDTO mandrilDto)
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
    


