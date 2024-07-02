using Grupo5.Input;
using System.Text;

namespace Grupo5.Business.Interfaces
{
    public interface IGeneratorTrama
    {
        string Validation(Request request);
        Task WriteTextToFileAsync();
        Task<byte[]> ReadFileAsync();
    }
}
