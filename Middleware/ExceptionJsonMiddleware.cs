using System.Net;
using System.Text.Json;

namespace MandrilAPI.Middleware
{
    //aunque funciona no era lo que necesita necesitaba era un IExeptionFilter
    public class ExceptionJsonMiddleware
    {
       private readonly RequestDelegate _next;
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
                _logger.LogError(ex, "A JSON format exception occurred:  {Message}", ex.Message);
                await HandleJsonExeptionAsync(context, ex);
            }
        }
   
    private static async Task HandleJsonExeptionAsync(HttpContext context, JsonException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = new
            {
                Titulo = "Error in the request",
                Status = context.Response.StatusCode,
                Message = "The format of the data sent is invalid. Please verify that the data type is the one requested."
            };
            
            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
            
        }
    }
}

