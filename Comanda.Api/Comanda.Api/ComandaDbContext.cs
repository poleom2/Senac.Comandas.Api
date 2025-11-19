using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Comanda.Api
{
    public class ComandaDbContext : DbContext
    {
        public ComandaDbContext(DbContextOptions<ComandaDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Usuario>().HasData(
                new Models.Usuario
                {
                    Id = 1,
                    Nome = "adm",
                    Email = "adm",
                    Senha = "adm1234"
                }
                );
            modelBuilder.Entity<Models.Mesa>().HasData(
                 new Models.Mesa
                 {
                     Id = 1,
                     NumeroMesa = 1,
                     SituacaoMesa = 1,
                 },
                 new Models.Mesa
                 {
                     Id = 2,
                     NumeroMesa = 2,
                     SituacaoMesa = 1,
                 },
                 new Models.Mesa
                 {
                     Id = 3,
                     NumeroMesa = 3,
                     SituacaoMesa = 1,
                 }
                );
            modelBuilder.Entity<Models.CardapioItem>().HasData(
                    new Models.CardapioItem{
                        Id = 1,
                       Titulo = " X Carne",
                       Descricao = " 2 Carne, Queijo, Tomate, Cebola dulce, Molho da casa",
                       PossuiPreparo = true,
                       Preco = 30,
                       Tipo = "Lanche",
                       Imagem= "https://img77.uenicdn.com/image/upload/v1543484687/service_images/shutterstock_1040760661.jpg"

                    },                    
                    new Models.CardapioItem
                    {
                        Id = 2,
                        Titulo = " X Carne",
                        Descricao = " 2 Carne, Queijo, Tomate, Cebola dulce, Molho da casa",
                        PossuiPreparo = true,
                        Preco = 30,
                        Tipo = "Lanche",
                        Imagem = "https://img77.uenicdn.com/image/upload/v1543484687/service_images/shutterstock_1040760661.jpg"

                    }
                  
                );
            modelBuilder.Entity<Models.CategoriaCardapio>().HasData(
                new Models.CategoriaCardapio { Id = 1, Nome = "lanche" },
                new Models.CategoriaCardapio { Id = 2, Nome = "Bebidas" },
                new Models.CategoriaCardapio { Id = 3, Nome = "Acompanhamentos" }
                );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Models.Usuario> Usuarios{ get; set; } = default!;
        public DbSet<Models.Comanda> Comandas { get; set; } = default!;
        public DbSet<Models.ComandaItem> ComandaItens { get; set; } = default!;
        public DbSet<Models.Mesa> Mesas { get; set; } = default!;
        public DbSet<Models.PedidoCozinha> PedidosCozinhas{ get; set; } = default!;
        public DbSet<Models.PedidoCozinhaItem> PedidosCozinhaItens { get; set; } = default!;
        public DbSet<Models.Reserva> Reservas { get; set; } = default!;
        public DbSet<Models.CardapioItem> CardapioItens { get; set; } = default!;
        public DbSet<Models.CategoriaCardapio> categoriaCardapios { get; set; } = default!;
    }
}
