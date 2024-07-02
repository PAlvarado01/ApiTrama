using FluentValidation;
using FluentValidation.Results;
using Grupo5.Business.Interfaces;
using System.Text;

namespace Grupo5.Business.Services
{
    public abstract class InputService<TInput, TValidator> where TInput : IInput where TValidator : AbstractValidator<TInput>
    {
        public AbstractValidator<TInput> GetValidator() => Activator.CreateInstance<TValidator>();

        public ValidationResult Validate(IInput input) => GetValidator().Validate((TInput)input);

        public string SerializeErrors(IInput input)
        {
            var builder = new StringBuilder();
            var errors = Validate(input).Errors.ToList();

            foreach (var error in errors)
            {
                error.PropertyName = error.PropertyName.Split('.').ToList().LastOrDefault();
                builder.AppendLine($"{error.ErrorMessage} <br/>");
            }

            return builder.ToString();
        }
    }
}
