using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using MandrilAPI.Interfaces;
using MandrilAPI.Middleware;
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

public class MandrilHabilidadController(MandrilContext contextHabilidad, IMandrilHabilidadReadRepository repositoryQueryMandrilHabilidades) : ControllerBase
{
   private readonly MandrilContext _context = contextHabilidad;
    //Implementacion context DB

    //Comenzar la migracion de logica a base de datos..
    private readonly IMandrilHabilidadReadRepository _RepositoryMandrilHabilidades = repositoryQueryMandrilHabilidades;

    //GET obtiene la lista de habilidades de un mandril especifico
    [HttpGet]
    public IActionResult GetHabilidad(int mandrilID)
    {
        
         
        var mandril = _context.MandrilHabilidades.Include(m => m.Mandril).Include(h => h.Habilidad)
            .Where(m => m.Mandril.id == mandrilID).ToList();

        //Verificacion si el mandril existe en la tabla intermedia y tiene una habilidad
        if (mandril.Count == 0)
        {
            return BadRequest(DefaultsMessageUsers.mandrilNotFound);
        }
        else
        {
            //Verificacion si la habilidad es null
            //esta verificacion es inutil ya que la tabla intermedia no permite que un mandril en esa tabla no tenga habilidades
            //Ademas que cuando es eliminada una habilidad o un mandril de la tabla principal este automaticamente es borrado de la tabla intermedia.
            //Se deja por que aun asi funciona Jaja
            if (mandril.Exists(h => h.Habilidadid == null))
            {
                return BadRequest(DefaultsMessageUsers.habilidadNotFound);
            }
            else
            {

                return Ok(mandril);
            }


        }
    }
    
    //GET obtiene la habilidad especificada de un mandril
    [HttpGet("{HabilidadID}")]
    public IActionResult GetHabilidad(int mandrilID, int HabilidadID)
    {
        var seleccionMandril = _context.MandrilHabilidades.Include(m => m.Mandril).Include(h => h.Habilidad)
            .FirstOrDefault(m => m.Mandrilid == mandrilID && m.Habilidadid == HabilidadID);

        //Solo se requiere una verificacion ya que en la lista intermedia uno sin el otro no puede exisitir en la tabla por lo tanto al filtrar con where
        //todo se reduce a que no hay nullos para verificar habilidades inexistentes pero si resultados inexistentes.

        if (seleccionMandril == null)
        {
            
            return BadRequest(DefaultsMessageUsers.mandrilNotFound + " \n " + DefaultsMessageUsers.habilidadNotFound);
        }
        else
        {
            return Ok(seleccionMandril);

        }

    }

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

    /*[Route("api/habilidad")]

     //ES NECESARIO CREAR UN CONTROLLER APARTE YA QUE ESTA ES EXCLUSIVA PARA MANEJAR LAS HABILIDADES DE UN MANDRIL

    [HttpPost]
    public IActionResult NuevaHabilidad([FromBody] HabilidadDTO habilidadNew)
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
            //me quede por aca
            _context.Habilidades.Add(new Habilidad(habilidadNew.Nombre, habilidadNew.Intesidad));
            _context.SaveChanges();
            return Ok("Habilidad creada correctamente");
        }
    }*/



    //  var mandril = MandrilDataStore.Current.UsarListaMandriles().FirstOrDefault(m => m.id == mandrilID);
    //          

    //creo que el bug al body dejarme colocar el id por padron 0 este se coloca pero aca al hacer la verificacion
    //termina seleccionando al id que sea igual al objeto que cree es decir a otra habilidad de la lista no la actual
    //error de verificacion de id.

    //solucion : crear un dtoHabilidad que no permita colocar el id aunque podria solo eliminar la verificacion de id igual hay que hacerlo para evitar bugs
    //duda 1 : porque se necesita un constructor vacio para poder deserializar correctamente un objeto desde el body


    //Adicionar un put que agregue una habilidad ya exitente en la base de datos a un mandril

    [HttpPut]
    public IActionResult AgregarHabilidadMandril(int mandrilID, int HabilidadID)
    {
        var busquedaMandril = _context.Mandrils.FirstOrDefault(m => m.id == mandrilID);
        var busquedaHabilidad = _context.Habilidades.FirstOrDefault(h => h.id == HabilidadID);
        if (busquedaMandril == null)
        {
            return BadRequest(DefaultsMessageUsers.mandrilNotFound);
        }
        else
        {
            if (busquedaHabilidad == null)
            {
                return BadRequest(DefaultsMessageUsers.habilidadNotFound);
            }
            else
            {
                var relacion = new MandrilHabilidades();

                relacion.Mandrilid = busquedaMandril.id;
                relacion.Habilidadid = busquedaHabilidad.id;

                _context.MandrilHabilidades.Add(relacion);
                _context.SaveChanges();
                return Ok("El mandril" + " " + relacion.Mandril.Nombre + " " + "ha agregado la habilidad" + " " + relacion.Habilidad.Nombre + " " + "exitosamente");
            }
        }
    }
    //Aca es donde tengo que trabajar para el tratamientod de la excepcion
    //Adicionar un put para editar la potencia de un mandril ya creado siempre y cuando exista en la lista de MandrilHabilidades
    [HttpPut("{HabilidadID}")]

    public IActionResult EditarHabilidad(int mandrilID, int HabilidadID, HabilidadDTOPotencia habilidadDto)

    {
         
        var mandrilP = _context.MandrilHabilidades.Include(m => m.Mandril).Include(h => h.Habilidad)
            
            .FirstOrDefault(m => m.Mandril.id == mandrilID && m.Habilidad.id == HabilidadID);

       
        

        if (habilidadDto.potenciaIsValid())
        {
            if (MandrilHabilidades.MandrilIsValid(mandrilP))
            {
                mandrilP.PotenciaMH = habilidadDto.Potencia;
                _context.SaveChanges();
                return Ok(mandrilP);
            }
            else
            {
                return BadRequest(DefaultsMessageUsers.mandrilNotFound);
            }
        }
        else return BadRequest(DefaultsMessageUsers.PotenciaNotValid);
    }


        //teste
        [HttpGet("jsonexepcion")]
   public IActionResult teste() {
        
   throw new JsonException("error");

            }
      

 

    [HttpDelete("{HabilidadID}")]
//Delete. eliminar una habilidad de un mandril
    public IActionResult EliminarHabilidad(int mandrilID, int HabilidadID)
    {
        var mandril = _context.MandrilHabilidades.Include(m=>m.Mandril).Include(h=>h.Habilidad).FirstOrDefault(m => m.Mandril.id == mandrilID && m.Habilidad.id == HabilidadID );
        
        if (mandril == null)
        {
            return BadRequest(DefaultsMessageUsers.mandrilNotFound + DefaultsMessageUsers.habilidadNotFound);
        }
        else
        {
            _context.MandrilHabilidades.Remove(mandril);
            _context.SaveChanges();
            return Ok("Los datos han sido borrados correctamente");
            
        }
    }

}


