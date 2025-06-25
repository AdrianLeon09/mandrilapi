using System.Net;
using System.Text.Json;

namespace MandrilAPI.Middleware
{
    //aunque funciona no era lo que necesita necesitaba era un IExeptionFilter
    public class ExceptionJsonMiddleware
    {
        // "_next" es un delegado que representa al siguiente middleware en el pipeline (la cadena de procesamiento).
     // Guardamos una referencia a él para poder invocarlo y continuar con el flujo de la petición.
       private readonly RequestDelegate _next;

        // "_logger" es una herramienta para registrar información, advertencias o errores que ocurren en la aplicación.
        // Es una buena práctica registrar las excepciones para poder depurarlas más tarde.
        private readonly ILogger<ExceptionJsonMiddleware> _logger;

        public ExceptionJsonMiddleware(RequestDelegate next, ILogger<ExceptionJsonMiddleware> logger)
        {
             _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (JsonException  ex)
            {
                _logger.LogError(ex, "Ocurrio una exepcion de formato JSON: {Message}", ex.Message);
                await HandleJsonExeptionAsync(context, ex);
            }
        }
   
    private static async Task HandleJsonExeptionAsync(HttpContext context, JsonException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
           
            var response = new
            {
                Titulo = "Error en la peticion",
                Status = context.Response.StatusCode,
                Message = "El formato de los datos enviados es invalido. Verifique que el tipo de dato sea el solicitado."
            };
            var jsonResponse = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}

