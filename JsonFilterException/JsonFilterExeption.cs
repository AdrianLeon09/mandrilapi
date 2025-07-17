using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MandrilAPI.JsonFiltroExepcion;

public class JsonFilterExeption : IExceptionFilter
{
    private readonly ILogger<JsonFilterExeption> _logger;
   
    public JsonFilterExeption(ILogger<JsonFilterExeption> logger)
    {
        _logger = logger;
    }
     //future updates
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is JsonException)
        {
            var controllerName = context.ActionDescriptor.RouteValues["controller"];
            var actionName = context.ActionDescriptor.RouteValues["action"];
            _logger.LogWarning(context.Exception.Message, "Error JsonExcepcion" + controllerName);

            var errorResponse = new
            {
                Titulo = "Error",
                Status = (int)HttpStatusCode.BadRequest,
                Mensaje = "error.",
              
            };
            var result = new BadRequestObjectResult(errorResponse);
            context.Result = result;
         
            context.ExceptionHandled = true;
        }
    }
}