using Microsoft.EntityFrameworkCore;

namespace Taskino_Ferramenta.Models
{
    public class ParadisoGiovanninoContex : DbContext
    {
        public ParadisoGiovanninoContex(DbContextOptions<ParadisoGiovanninoContex>options):base(options) { 
        }

        public DbSet<Reparto> Repartos { get; set; }
        public DbSet<Prodotto> Prodottos { get; set; }
    }
}
