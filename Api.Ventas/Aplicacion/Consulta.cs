using Api.Ventas.DTO;
using Api.Ventas.Persistens;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Ventas.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<VentasDto>>
        {
            //public Boolean Estado { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, List<VentasDto>>
        {
            private readonly ContextApp _context;
            private readonly IMapper _mapper;
            public Manejador(ContextApp context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<VentasDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var res = await _context.Venta.ToListAsync();
                if (res == null)
                {
                    throw new Exception("No existen ventas");
                }
                var resDTO = _mapper.Map<List<Model.Venta>, List<VentasDto>>(res);
                return resDTO;
            }            
        }
    }
}
