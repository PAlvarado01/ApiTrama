using FluentValidation.Results;

namespace Grupo5.Business.Interfaces
{
    public interface IInput
    {
        ValidationResult Validate(IInput input);
        string SerializeErrors(IInput input);
    }
}
