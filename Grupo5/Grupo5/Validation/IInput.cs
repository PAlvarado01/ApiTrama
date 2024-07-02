using FluentValidation.Results;

namespace Grupo5.Validation
{
    public interface IInput
    {
        ValidationResult Validate(IInput input);
        string SerializeErrors(IInput input);
    }
}
