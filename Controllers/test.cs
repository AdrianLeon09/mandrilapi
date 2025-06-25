using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MandrilAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class test : ControllerBase
    {
        [HttpGet("jsonexeption")]

        public IActionResult Middleware_teste()
        {

            throw new JsonException("error");
        }

    }
}
