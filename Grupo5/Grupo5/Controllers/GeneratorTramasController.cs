using Grupo5.Input;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Grupo5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneratorTramasController : ControllerBase
    {
        [HttpPost]
        public IActionResult GeneratorTramas([FromBody] Request RequestA)
        {
           var input = new Request(RequestA.fecInicial,RequestA.fecFin,RequestA.tipoTrama);

            if (!input.Validate(input).IsValid)
                return Ok(input.SerializeErrors(input));

            string filePath = "output.txt";
            string fileContent = "This is a sample text file.";

            // Create the file and write content to it
            WriteTextToFileAsync(Path.Combine(Directory.GetCurrentDirectory(),filePath), fileContent);

            // Read the file content
            var bytes = ReadFileAsync(filePath).Result;

            // Return the file content as a response
            return File(bytes, "text/plain", RequestA.tipoTrama);
        }

        private async Task WriteTextToFileAsync(string filePath, string content)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
            {
                await writer.WriteAsync(content);
            }
        }

        private async Task<byte[]> ReadFileAsync(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (MemoryStream ms = new MemoryStream())
            {
                await fs.CopyToAsync(ms);
                return ms.ToArray();
            }
        }
    }
}
