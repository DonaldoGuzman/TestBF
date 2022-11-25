using Api.Ventas.Persistens;
using FluentValidation;
using MediatR;

namespace Api.Ventas.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public DateTime FechaVenta { get; set; }
            public string Cliente { get; set; }
            public int Estado { get; set; }
            public DateTime FechaAnulacion { get; set; }
        }

        public class EjecutarValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutarValidacion()
            {
                RuleFor(x => x.FechaVenta).NotEmpty();
                RuleFor(x => x.Cliente).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
                //RuleFor(x => x.FechaAnulacion).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextApp _context;

            public Manejador(ContextApp context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var data = new Model.Venta
                {
                    FechaVenta = request.FechaVenta,
                    Cliente = request.Cliente,
                    Estado = request.Estado,
                    FechaAnulacion = request.FechaAnulacion,
                };
                _context.Venta.Add(data);
                var value = await _context.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar");
            }
        }
    }
}
