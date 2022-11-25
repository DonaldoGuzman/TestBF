using Api.DetVentas.DTO;
using Api.DetVentas.Model;
using AutoMapper;

namespace Api.DetVentas.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<DetalleVenta, DetalleVentaDto>();
        }
        
    }
}
