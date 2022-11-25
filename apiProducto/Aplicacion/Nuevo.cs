using Api.Producto.Persistens;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Producto.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public int Stock { get; set; }
            public int IdMedida { get; set; }
            public decimal PrecioIngreso { get; set; }
            public decimal PrecioVenta { get; set; }
            public DateTime FechaIngreso { get; set; }
            public DateTime FechaActualizacion { get; set; }
        }

        public class EjecutarValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutarValidacion()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Stock).NotEmpty();
                RuleFor(x => x.IdMedida).NotEmpty();
                RuleFor(x => x.PrecioIngreso).NotEmpty();
                RuleFor(x => x.PrecioVenta).NotEmpty();
                RuleFor(x => x.FechaIngreso).NotEmpty();
                RuleFor(x => x.FechaActualizacion).NotEmpty();
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
                var data = new Model.Productos
                {
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion,
                    Stock = request.Stock,
                    IdMedida = request.IdMedida,
                    PrecioIngreso = request.PrecioIngreso,
                    PrecioVenta = request.PrecioVenta,
                    FechaIngreso = request.FechaIngreso,
                    FechaActualizacion = request.FechaActualizacion,
                };
                _context.Productos.Add(data);
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
