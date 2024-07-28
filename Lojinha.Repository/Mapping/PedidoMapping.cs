using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Repository.Mapping
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable(nameof(Pedido));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.DataPedido).IsRequired();

            builder.HasMany(p => p.ListaItem).WithOne(i => i.Pedido).HasForeignKey(i => i.PedidoId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Pagamento).WithOne(pg => pg.Pedido).HasForeignKey<Pedido>(p => p.PagamentoId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.ListaHistoricoPedido).WithOne(hp => hp.Pedido).HasForeignKey(hp => hp.PedidoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}