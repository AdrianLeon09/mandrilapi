 
using MandrilAPI.Models;
using MandrilAPI.Models.Service;
 
using Microsoft.AspNetCore.Mvc;
 

namespace MandrilAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MandrilController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Mandril> GetMandriles()
        {
            return Ok(MandrilDataStore.Current.UsarListaMandriles());
        }

        [HttpGet("{mandrilID}")]
        public ActionResult<Mandril> GetMandriles(int mandrilID)
        {
            var mandrilSelect = MandrilDataStore.Current.UsarListaMandriles().FirstOrDefault(x => x.id == mandrilID);

            if (mandrilSelect != null)
            {
                return Ok(mandrilSelect);
            }
            else
            {
                return BadRequest("No se ha encontrado el mandril seleccionado");
            }
        }

        [HttpPut("{mandrilID}")]
        public ActionResult<Mandril> PutMandril(int mandrilID, [FromBody] MandrilDTO mandrilDto)
        {
            var mandril = MandrilDataStore.Current.UsarListaMandriles().FirstOrDefault(x => x.id == mandrilID);
            if (mandril == null)
            {
                return NotFound("No se encontrado el mandril seleccionado");
            }
            else
            {
                mandril.Nombre = mandrilDto.Nombre;
                mandril.Apellido = mandrilDto.Apellido;
                return Ok("Los datos se han editado correctamente");
            }
        }

        [HttpDelete("{mandrilID}")]
        public ActionResult<Mandril> DeleteMandril(int mandrilID)
        {
            
            
           var mandrilDelete = MandrilDataStore.Current.UsarListaMandriles().FirstOrDefault(x => x.id == mandrilID);
           if (mandrilDelete == null)
           {
               return NotFound("No se encontrado el mandril seleccionado");
           }
           else
           {
               MandrilDataStore.Current.UsarListaMandriles().Remove(mandrilDelete);
               return Ok("El mandril se ha eliminado correctamente");
           }  // documentar codigo 
           
             
        }
            
            
      
        
        
        
        
        
        
        
        [HttpPost]

        //Se piden dos atributos especificos de la clase creada mandrilInsert
    public ActionResult<Mandril> PostMandril(MandrilDTO mandrilDto)
    {
        //Se crea una instancia mandril con esos atributos
            var newMandril = new Mandril(mandrilDto.Nombre, mandrilDto.Apellido);
            //Se agrega el mandril a  la lista
            MandrilDataStore.Current.UsarListaMandriles().Add(newMandril);
            
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
           return CreatedAtAction(nameof(GetMandriles), new {mandrilID = newMandril.id}, mandrilDto);

        }
    }
}

