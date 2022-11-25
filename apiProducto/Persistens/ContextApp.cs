using Api.Producto.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Producto.Persistens
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options) : base(options) { }
        public DbSet<Productos> Productos { get; set; }
    }
}
