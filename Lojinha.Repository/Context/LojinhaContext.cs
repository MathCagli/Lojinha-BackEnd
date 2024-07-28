using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Lojinha.Repository.Context
{
    public class LojinhaContext : DbContext
    {
        public LojinhaContext(DbContextOptions<LojinhaContext> options) : base(options) { }

        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<Cartao> Cartao { get; set; }
        public DbSet<DadoBancario> DadoBancario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LojinhaContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}