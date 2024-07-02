using FluentValidation;

namespace Grupo5.Input
{
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(c => c.fecInicial)
                .NotEmpty().WithMessage("El parametro Fecha Inicial no puede ser vacio")
                .NotNull().WithMessage("El parametro Fecha Inicial no puede ser nulo");

            RuleFor(c => c.fecFin)
                .NotEmpty().WithMessage("El parametro Fecha fin no puede ser vacio")
                .NotNull().WithMessage("El parametro Fecha fin no puede ser nulo");

            RuleFor(c => c.tipoTrama)
                .NotEmpty().WithMessage("El parametro Tipo Trama no puede ser vacio")
                .NotNull().WithMessage("El parametro Tipo Trama no puede ser nulo");
        }
    }
}
