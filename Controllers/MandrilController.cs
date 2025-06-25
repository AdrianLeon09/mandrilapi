
using MandrilAPI.Interfaces;
using MandrilAPI.Models;
using MandrilAPI.Models.Service;
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;


namespace MandrilAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MandrilController(MandrilDbContext  context, IMandrilAndSkillsReadRepository RepositoryMandrilHabilidades) : ControllerBase
    {
       //Implentacion exitosa de context 
       private readonly MandrilDbContext _context = context;
        //Controlador ya consume las funciones del repositorio.
        private readonly IMandrilAndSkillsReadRepository _RepositoryReadMandrilHabilidades = RepositoryMandrilHabilidades;
        
       //GET PARA VER TODOS LOS MANDRILES
       
        [HttpGet]
    public ActionResult<Mandril> GetAllMandriles()
    {
            //Ya que EF no carga las relaciones automaticamente se usa Include para cargarlas

            // return Ok(_context.MandrilHabilidades.Include(m=>m.Mandril)
            //   .Include(h =>h.Habilidad ));

     
            var mandriles = _RepositoryReadMandrilHabilidades.GetAllMandrilsFromDb(); ;
            if (mandriles.Count is 0) { 
                return NotFound(DefaultsMessageUsers.mandrilNotFound);
            }
            else {
                return Ok(mandriles);}
            
            
           
    }
    //GET para obtener un mandril por su ID
    [HttpGet("{mandrilID}")]
    public ActionResult<Mandril> GetMandrilById(int targetMandrilId)
    {
            var mandril = _RepositoryReadMandrilHabilidades.GetOneMandrilsFromDb(targetMandrilId);

        if (mandril.Count is  0)
        {
            return BadRequest("No se ha encontrado el mandril seleccionado");  
        }
            return Ok(mandril);
              
    }

    //PUT para editar un mandril existente
    [HttpPut("{mandrilID}")]
    public ActionResult<Mandril> UpdateMandril(int targetMandrilId, [FromBody] MandrilDTO mandrilDto)
    {
            var MandrilUpdate = _RepositoryReadMandrilHabilidades.GetOneMandrilsFromDb(targetMandrilId);
        if (MandrilUpdate.Count is 0)
        {
            return NotFound("No se encontrado el mandril seleccionado");
        }
        else{
        
        //    MandrilUpdate.Nombre = mandrilDto.Nombre; // seguir logica de escritura repositorio aca
         //   mandril.Apellido = mandrilDto.Apellido;
            _context.SaveChanges();
            return Ok("Los datos se han editado correctamente");
        }
    }
    //DELETE para eliminar un mandril existente
    [HttpDelete("{mandrilID}")]
    public ActionResult<Mandril> DeleteMandril(int mandrilID)
    {


        var mandrilDelete = _context.Mandrils.FirstOrDefault(m=> m.id == mandrilID);
        if (mandrilDelete == null)
        {
            return NotFound("No se encontrado el mandril seleccionado");
        }
        else
        {
            _context.Mandrils.Remove(mandrilDelete);
            _context.SaveChanges();
            return Ok("El mandril se ha eliminado correctamente");
        }
    }
    [HttpPost]

    //Se piden dos atributos especificos de la clase creada mandrilInsert
    public ActionResult<Mandril> PostMandril(MandrilDTO mandrilDto)
    {
        //Se crea una instancia mandril con esos atributos
        var newMandril = new Mandril(mandrilDto.Nombre, mandrilDto.Apellido);
        //Se agrega el mandril a  Base de datos
       _context.Mandrils.Add(newMandril);
       //Save changes 
       _context.SaveChanges();

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
        return CreatedAtAction(nameof(GetMandriles), new { mandrilID = newMandril.id }, mandrilDto);

    }
    }
}

