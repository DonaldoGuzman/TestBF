using Api.Ventas.DTO;
using Api.Ventas.Model;
using AutoMapper;

namespace Api.Ventas.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Venta, VentasDto>();
        }
        
    }
}
