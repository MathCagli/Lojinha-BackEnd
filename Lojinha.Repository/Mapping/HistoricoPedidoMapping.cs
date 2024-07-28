using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Repository.Mapping
{
    public class HistoricoPedidoMapping : IEntityTypeConfiguration<HistoricoPedido>
    {
        public void Configure(EntityTypeBuilder<HistoricoPedido> builder)
        {
            builder.ToTable(nameof(HistoricoPedido));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(hp => hp.DataEvento).IsRequired();
            builder.Property(hp => hp.DescricaoEvento).HasMaxLength(255);
            builder.Property(hp => hp.DetalhesEvento).HasMaxLength(500);

            builder.HasOne(hp => hp.Pedido).WithMany(p => p.ListaHistoricoPedido).HasForeignKey(hp => hp.PedidoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}