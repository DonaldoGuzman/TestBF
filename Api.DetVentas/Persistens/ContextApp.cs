using Api.DetVentas.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.DetVentas.Persistens
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options) : base(options) { }
        public DbSet<DetalleVenta> DetalleVenta {get; set;}
    }
}
