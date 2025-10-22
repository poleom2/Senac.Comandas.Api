using Microsoft.EntityFrameworkCore;

namespace Comanda.Api
{
    public class ComandaDbContext : DbContext
    {
        public ComandaDbContext(DbContextOptions<ComandaDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Usuario> Usuarios{ get; set; } = default!;
        public DbSet<Models.Comanda> Comandas { get; set; } = default!;
        public DbSet<Models.ComandaItem> ComandaItens { get; set; } = default!;
        public DbSet<Models.Mesa> Mesas { get; set; } = default!;
        public DbSet<Models.PedidoCozinha> PedidosCozinhas{ get; set; } = default!;
        public DbSet<Models.PedidoCozinhaItem> PedidosCozinhaItens { get; set; } = default!;
        public DbSet<Models.Reserva> Reservas { get; set; } = default!;
        public DbSet<Models.CardapioItem> CardapioItens { get; set; } = default!;
    }
}
