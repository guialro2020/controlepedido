using Microsoft.EntityFrameworkCore;
using Tcs.ControlePedido.Persistencia.Modelos;

namespace Tcs.ControlePedido.Persistencia
{
    public class PersistenciaContexto : DbContext
    {
        public PersistenciaContexto(DbContextOptions<PersistenciaContexto> options)
             : base(options)
        { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }
}
