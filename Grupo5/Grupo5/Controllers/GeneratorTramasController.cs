using Grupo5.Business.Interfaces;
using Grupo5.Input;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Grupo5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneratorTramasController : ControllerBase
    {
        private readonly IGeneratorTrama _GenerarTrama;

        public GeneratorTramasController(IGeneratorTrama generarTrama)
        {
            _GenerarTrama = generarTrama;
        }

        [HttpPost]
        public IActionResult GeneratorTramas([FromBody] Request RequestA)
        {
            var message = _GenerarTrama.Validation(RequestA);

            if (message != "")
            {
                return Ok(message);
            }
            else
            {
                // Create the file and write content to it
                _GenerarTrama.WriteTextToFileAsync();

                // Read the file content
                var bytes = _GenerarTrama.ReadFileAsync().Result;

                // Return the file content as a response
                return File(bytes, "text/plain", RequestA.tipoTrama);
            }
        }

    }
}
