using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MandrilAPI.JsonFiltroExepcion;
//Implentar Para manejar la exepcion que ocurre desde el body
public class JsonExcepcionFiltro : IExceptionFilter
{
    private readonly ILogger<JsonExcepcionFiltro> _logger;

    public JsonExcepcionFiltro(ILogger<JsonExcepcionFiltro> logger)
    {
        _logger = logger;
        
    }
    
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is JsonException)
        {
            var controllerName = context.ActionDescriptor.RouteValues["controller"];
            var actionName = context.ActionDescriptor.RouteValues["action"];
            _logger.LogWarning(context.Exception.Message, "Error JsonExcepcion capturado");

            var errorResponse = new
            {
                Titulo = "Error en los datos ingresados",
                Status = (int)HttpStatusCode.BadRequest,
                Mensaje = "Ha ocurrido un error. Verifique los datos ingresados e intente nuevamente",

            };
            var result = new BadRequestObjectResult(errorResponse);
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}