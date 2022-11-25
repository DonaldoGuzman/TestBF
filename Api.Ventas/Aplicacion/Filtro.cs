using Api.Ventas.DTO;
using Api.Ventas.Model;
using Api.Ventas.Persistens;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Ventas.Aplicacion
{
    public class Filtro
    {
        public class Unico : IRequest<VentasDto>
        {
            public int Id { get; set; }
        }
        public class Manejador : IRequestHandler<Unico, VentasDto>
        {
            private readonly ContextApp _context;
            private readonly IMapper _mapper;
            public Manejador(ContextApp context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<VentasDto> Handle(Unico request, CancellationToken cancellationToken)
            {
                var result = await _context.Venta.Where(x => x.idVenta == request.Id).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new Exception("No se encontró la venta");
                }
                var resultDto = _mapper.Map<Venta, VentasDto>(result);
                return resultDto;
            }
            //public async Task<List<VentaDetVentaDto>> Handle(Unico request, CancellationToken cancellationToken)
            //{
            //    //var resultado = await (from v in _context.Venta
            //    //                       join t in _context.DetalleVenta on v.idVenta equals t.idVenta
            //    //                       select new VentaDetVentaDto()
            //    //                       {
            //    //                           idVenta = v.idVenta,
            //    //                           idDetalleVenta = t.idDetalleVenta,
            //    //                           idProducto = t.idProducto,
            //    //                           FechaVenta = v.FechaVenta,
            //    //                           Cliente = v.Cliente,
            //    //                           Estado = v.Estado,
            //    //                           Descripcion = t.Descripcion,
            //    //                           Cantidad = t.Cantidad,
            //    //                           Precio = t.Precio
            //    //                       }).Where(x => x.idVenta == request.Id).ToListAsync();
            //    //return resultado;
            //}
        }
    }
}
