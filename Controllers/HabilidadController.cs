using System.Collections;
using System.Runtime.InteropServices.JavaScript;
using MandrilAPI.Models;
using MandrilAPI.Models.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MandrilAPI.Controllers;
//  IMPORTANTE ES NECESARIO AGREGAR UNA TABLA INTERMEDIA MANDRIL HABILIDADES PARA EVITAR LA DUPLICACION DE HABILIDADES POR MANDRIL TERMINADO ESO IMPLEMENTAR LA LOGICA DE HABILIDAD MANDRIL ACA.

//Se configura la ruta para accesar a las habilidades de cada mandril por medio de Mandriles lo cual permitira desarollar la logica de
//habilidad controller.

//// Cada método requerirá que se le especifique un mandrilID en la URL, porque la ruta [Route("api/Mandril/{mandrilID}/[controller]")]
/// lo define como parte obligatoria. Esto permite saber con qué Mandril se está trabajando
[ApiController]
[Route("api/Mandril/{mandrilID}/[controller]")]

public class HabilidadController(MandrilContext contextHabilidad) : ControllerBase
{
    //Implementacion context DB
    private readonly MandrilContext _context = contextHabilidad;
    //Comenzar la migracion de logica a base de datos..
    
    //GET obtiene la lista de habilidades de un mandril especifico
    [HttpGet]
    public IActionResult GetHabilidad(int mandrilID)
    {
      //necesario adaptar desde la clase mandril el comportamient de mapeamento e datos a bd
        var mandril = _context.Mandrils.Include(m=>m.Habilidades).FirstOrDefault(m=>m.id==mandrilID);
        
        //Verificacion si el mandril es null
        if (mandril == null)
        {
            return BadRequest(DefaultsMessages.mandrilNotFound);
        }
        else
        {
            //Verificacion si la habilidad es null
            if (mandril.Habilidades == null)
            {
                return BadRequest(DefaultsMessages.habilidadNotFound);
            }
            else
            {
// ok
                return Ok(mandril);
            }

            
        }
    }
    
    //GET obtiene la habilidade especificada de un mandril
    [HttpGet("{HabilidadID}")]
    public IActionResult GetHabilidad(int mandrilID, int HabilidadID)
    {
        var seleccionMandril = _context.Mandrils.Include(m=> m.Habilidades).FirstOrDefault(m=> m.id == mandrilID);
        var seleccionHabilidad = seleccionMandril?.Habilidades?.FirstOrDefault(h=> h.Id==HabilidadID);

        if (seleccionMandril == null)
        {
            return BadRequest(DefaultsMessages.mandrilNotFound);
        }
        else
        {
            if (seleccionHabilidad == null)
            {
                return BadRequest(DefaultsMessages.habilidadNotFound);
            }
            else
            {
                //ok
                return Ok(seleccionHabilidad);
            }
        }
    }

    //crear un metodo para crear una habilidad en la base de datos
    //en pos y put se colocan los parametros a pedir en el cuerpo

    // [HttpPost]
    // public IActionResult NewHabilidad([FromBody] string nombreHabilidad, int potenciaHabilidad)
    // {
    //     var habilidadnew = new Habilidad(nombreHabilidad, potenciaHabilidad);
    //     Habilidad.AgregarHabilidadToList(habilidadnew);
    //     return Ok(habilidadnew);
    // }

    //otro para anadir una habilidad a un mandril
    
    //
   
    
    //PATCH Crea una habilidad desde el body y la asigna a la base de datos
    [HttpPatch]
    public IActionResult NuevaHabilidadMandril(int mandrilID, [FromBody] HabilidadDTO habilidadNew)
    {
        var habiliadadVerificacion = _context.Habilidades.FirstOrDefault(h =>
                h.Nombre.Equals(habilidadNew.Nombre, StringComparison.CurrentCultureIgnoreCase));
        
        //analizar un poco esta parte del codigo

        //Si, la habilidad Ya existe
        if (habiliadadVerificacion != null)
        {

            return BadRequest(
                DefaultsMessages.habilidadAlreadyExists);

        }
        else
        {
            var habilidad = new Habilidad(habilidadNew.Nombre, habilidadNew.Intesidad);
            var mandril = MandrilDataStore.Current.UsarListaMandriles().FirstOrDefault(m => m.id == mandrilID);

            if (mandril == null)
            {
                return BadRequest(DefaultsMessages.mandrilNotFound);
            }
            else
            {
                mandril.HabilidadMandril().Add(habilidad);
                return Ok(mandril);
            }
        }



        //  var mandril = MandrilDataStore.Current.UsarListaMandriles().FirstOrDefault(m => m.id == mandrilID);
        //          

        //creo que el bug al body dejarme colocar el id por padron 0 este se coloca pero aca al hacer la verificacion
        //termina seleccionando al id que sea igual al objeto que cree es decir a otra habilidad de la lista no la actual
        //error de verificacion de id.

        //solucion : crear un dtoHabilidad que no permita colocar el id aunque podria solo eliminar la verificacion de id igual hay que hacerlo para evitar bugs
        //duda 1 : porque se necesita un constructor vacio para poder deserializar correctamente un objeto desde el body



    }

   //Adicionar un put que agregue a un mandril una habilidad ya exitente en la base de datos

   [HttpPut]
   public IActionResult AgregarHabilidad(int mandrilID, int HabilidadID)
   {
       var mandril =  MandrilDataStore.Current.UsarListaMandriles().FirstOrDefault(m=>m.id == mandrilID);
       var habilidad = Habilidad.SeleccionarHabilidad().FirstOrDefault(h=>h.Id == HabilidadID);
       if (mandril == null)
       {
           return BadRequest(DefaultsMessages.mandrilNotFound);
       }
       else
       {
           if (habilidad == null)
           {
               return BadRequest(DefaultsMessages.habilidadNotFound);
           }
           else
           {
               mandril.HabilidadMandril().Add(habilidad);
               return Ok(mandril);
           }
       }
       
       
   }
    
    //Adicionar un put para editar la potencia de un mandril ya creado siempre y cuando exista en la lista de habilidades general

    [HttpPut("{HabilidadID}")]
    public IActionResult EditarHabilidad(int mandrilID, int HabilidadID, HabilidadDTOPotencia habilidadDto)
    {
        var mandril = MandrilDataStore.Current.UsarListaMandriles().FirstOrDefault(m => m.id == mandrilID);
        var habilidad = mandril?.HabilidadMandril().FirstOrDefault(h => h.Id == HabilidadID);

        if (mandril == null)
        {
            return BadRequest(DefaultsMessages.mandrilNotFound);
        }
        else
        {
            //confirmacion de que la habilidad existe en la lista(Base de datos)
            var confirmacion = Habilidad.SeleccionarHabilidad().FirstOrDefault(h => h.Id == HabilidadID);
            if (confirmacion == null)
            {
                return (BadRequest(DefaultsMessages.habilidadNotFound));
            }
            else
            {
                //confirmacion de que la habilidad en el mandril exista
                if (habilidad == null)
                {
                    return BadRequest(DefaultsMessages.habilidadNotFound);
                }
                else
                {
                    habilidad.Potencia = (Habilidad.EPotencia)habilidadDto.Potencia;
                    habilidad.PotenciaString = habilidad.Potencia.ToString();
                    return Ok(habilidad);
                }

            }
        }


    }

    //eliminar una habilidad ya creada
    [HttpDelete("{HabilidadID}")]

    public IActionResult EliminarHabilidad(int mandrilID, int HabilidadID)
    {
        var mandril = MandrilDataStore.Current.UsarListaMandriles().FirstOrDefault(m => m.id == mandrilID);
        var eliminar = mandril?.Habilidades?.RemoveAll(h => h.Id == HabilidadID);
        if (eliminar == null && mandril == null)
        {
            return BadRequest(DefaultsMessages.habilidadNotFound);
        }
        else
        {
            return Ok(eliminar);
        }
    }

}


