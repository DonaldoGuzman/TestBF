using Api.DetVentas.Persistens;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.DetVentas.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Descripcion { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }
            public DateTime Fecha { get; set; }
            public int idProducto { get; set; }
            public int idVenta { get; set; }
        }

        public class EjecutarValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutarValidacion()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Cantidad).NotEmpty();
                RuleFor(x => x.Precio).NotEmpty();
                RuleFor(x => x.Fecha).NotEmpty();
                RuleFor(x => x.idProducto).NotEmpty();
                RuleFor(x => x.idVenta).NotEmpty();
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
                var data = new Model.DetalleVenta
                {
                    Descripcion = request.Descripcion,
                    Cantidad = request.Cantidad,
                    Precio = request.Precio,
                    Fecha = request.Fecha,
                    idProducto = request.idProducto,
                    idVenta = request.idVenta,
                };
                _context.DetalleVenta.Add(data);
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
