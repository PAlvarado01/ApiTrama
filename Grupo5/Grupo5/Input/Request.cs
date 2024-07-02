using Grupo5.Validation;

namespace Grupo5.Input
{
    public class Request : Input<Request, RequestValidator> , IInput
    {
        public DateTime? fecInicial { get; private set; }
        public DateTime? fecFin { get; private set; }
        public string? tipoTrama { get; private set; }

        public Request(DateTime? fecInicial, DateTime? fecFin, string? tipoTrama)
        {
            this.fecInicial = fecInicial;
            this.fecFin = fecFin;
            this.tipoTrama = tipoTrama;
        }

    }
}
