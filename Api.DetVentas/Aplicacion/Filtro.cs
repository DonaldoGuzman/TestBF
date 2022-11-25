using Api.DetVentas.DTO;
using Api.DetVentas.Model;
using Api.DetVentas.Persistens;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.DetVentas.Aplicacion
{
    public class Filtro
    {
        public class Unico : MediatR.IRequest<DetalleVentaDto>
        {
            public int Id { get; set; }
        }
        public class Manejador : IRequestHandler<Unico, DetalleVentaDto>
        {
            private readonly ContextApp _context;
            private readonly IMapper _mapper;
            public Manejador(ContextApp context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<DetalleVentaDto> Handle(Unico request, CancellationToken cancellationToken)
            {
                var result = await _context.DetalleVenta.Where(x => x.idDetalleVenta == request.Id).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new Exception("No se encontró el tipo de clasificador");
                }
                var resultDto = _mapper.Map<DetalleVenta, DetalleVentaDto>(result);
                return resultDto;
            }
        }
    }
}
