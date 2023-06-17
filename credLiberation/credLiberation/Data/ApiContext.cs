using credLiberation.Models;
using Microsoft.EntityFrameworkCore;

namespace credLiberation.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<PedidoDeCredito> Pedidos { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            :base(options)
        {
            
        }
    }
}
