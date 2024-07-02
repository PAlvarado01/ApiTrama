using Grupo5.Business.Interfaces;
using Grupo5.Input;
using System.Text;

namespace Grupo5.Business.Services
{
    public class GenerarTramaService : InputService, IGeneratorTrama
    {
        public string Validation(Request request)
        {
            var message = Validations(new RequestValidator(), request);

            return message;
        }
        public async Task WriteTextToFileAsync()
        {
            string fileName = "output.txt";
            string fileContent = "This is a sample text file.";

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
            {
                await writer.WriteAsync(fileContent);
            }
        }

        public async Task<byte[]> ReadFileAsync()
        {
            string fileName = "output.txt";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (MemoryStream ms = new MemoryStream())
            {
                await fs.CopyToAsync(ms);
                return ms.ToArray();
            }
        }
    }
}
