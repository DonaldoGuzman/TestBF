using Api.Ventas.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Ventas.Persistens
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options) : base(options) { }
        public DbSet<Venta> Venta { get; set; }
    }
}
