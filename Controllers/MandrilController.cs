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
    
        //Controlador ya consume las funciones del repositorio.
        private readonly IMandrilAndSkillsReadRepository _RepositoryReadMandrilSkills = RepositoryRead;
        private readonly IMandrilAndSkillsWriteRepository _RepositoryWriteMandrilSkills = RepositoryWrite;
    

        //GET PARA VER TODOS LOS MANDRILES

        [HttpGet]
    public ActionResult<Mandril> GetAllMandriles()
    {
            //Ya que EF no carga las relaciones automaticamente se usa Include para cargarlas

            // return Ok(_context.MandrilHabilidades.Include(m=>m.Mandril)
            //   .Include(h =>h.Habilidad ));

     
            var mandriles = _RepositoryReadMandrilSkills.GetAllMandrilsFromDb(); ;
            if (mandriles.Count is 0) { 
                return NotFound(DefaultsMessageUsers.MandrilNotFound);
            }
            else {
                return Ok(mandriles);}
            
            
           
    }
    //GET para obtener un mandril por su ID
    [HttpGet("{targetMandrilId}")]
    public ActionResult<Mandril> GetMandrilById(int targetMandrilId)
    {
            var mandril = _RepositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);

        if (mandril.Count is  0)
        {
            return BadRequest("No se ha encontrado el mandril seleccionado");  
        }
            return Ok(mandril);
              
    }

   
    
    [HttpPut("{targetMandrilId}")]
    public ActionResult<Mandril> UpdateMandril(int targetMandrilId, [FromBody] MandrilDTO mandrilDto)
    {

            
            var qryMandril = _RepositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);

            if (qryMandril.Count is 0)
            {
                return NotFound(DefaultsMessageUsers.MandrilNotFound);
            }
            else
            {
                mandrilDto.name = mandrilDto.name.Replace(" ", "");
                mandrilDto.lastName = mandrilDto.lastName.Replace(" ", "");

                if (mandrilDto.name.Length < 3 || mandrilDto.lastName.Length < 3)
                {
                    return BadRequest(DefaultsMessageUsers.EntryInvalid);

                }
                else
                {
                    _RepositoryWriteMandrilSkills.UpdateOneMandrilToDb(targetMandrilId, mandrilDto);

                    return Ok(DefaultsMessageUsers.MandrilUpdateSucceeded);

                }
            }
    }
    //DELETE para eliminar un mandril existente
    
    [HttpDelete("{targetMandrilId}")]
        public ActionResult<Mandril> DeleteMandril(int targetMandrilId)
    {
            var checkDelete = _RepositoryReadMandrilSkills.GetOneMandrilsFromDb(targetMandrilId);
            if (checkDelete.Count is 0)
            { 
            return NotFound(DefaultsMessageUsers.MandrilNotFound);
            }
            else
            {
            _RepositoryWriteMandrilSkills.DeleteOneMandrilFromDb(targetMandrilId);
           
            return Ok(DefaultsMessageUsers.DeleteMandrilSucceeded);
        }
    }
        [HttpPost]

        //Post para crear un mandril en la DB
        public ActionResult<Mandril> AddMandril([FromBody]MandrilDTO mandrilDto)
        {
            mandrilDto.name = mandrilDto.name.Replace(" ", "");
            mandrilDto.lastName = mandrilDto.lastName.Replace(" ", "");
            if (mandrilDto.name.Length < 3 || mandrilDto.lastName.Length < 3)
            {
                return BadRequest(DefaultsMessageUsers.EntryInvalid);
            }
            else
            {
            _RepositoryWriteMandrilSkills.AddNewMandrilToDb(mandrilDto);

                 return Ok(DefaultsMessageUsers.MandrilCreatedSuccessfully);
            }
        }
        
        //El primer parametro le indica que metodo usara para generar la url

        //-------------------
        // //El segundo parámetro de CreatedAtAction, ese new {newmandrilID = algo}, se usa exclusivamente para crear la URL del metodo, teoricamente
        //usa los parametros creados dentro del objeto anonimo para saber donde va cada parametro y dato requerido en la solicitud GET
        //por eso es que se requiere que los nombres dentro del objeto anonimo coicidan con los parametros de cada ruta
        //.(El segundo parámetro de CreatedAtAction, ese new { mandrilID = algo }, se usa exclusivamente para construir la URL del método destino.
        //Internamente, utiliza los parámetros definidos dentro del objeto anónimo para saber qué valor corresponde a cada parámetro de la ruta (como en una solicitud GET), y así puede generar correctamente la URL del recurso recién creado.)

        //No afecta ni el cuerpo de la respuesta ni ningún otro aspecto del resultado.
        //-------


        //las nomenclaturas en el objeto anonimo tiene que ser exactamente igual al paramaetro del metodo y se le debe de pasar el mismo tipo de valor
        //Para evitar problemas de url(El nombre de la propiedad en el objeto anónimo debe coincidir con el nombre del parámetro en la ruta del método destino. No importa que se llame distinto en tu clase o en la base de datos. Lo importante es que coincida con la ruta del controlador y sus parámetros)

        //El ultimo parametro devuelve el objeto de la clase creada MandrilInsert para mostrar solo los datos especificados

        //Caso contrario mostraria todos los datos no deseados de mandril
      

    }
    }


