using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Repository.Mapping
{
    public class PagamentoMapping : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable(nameof(Pagamento));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.DataPagamento).IsRequired();
            builder.Property(p => p.ValorTotal).HasColumnType("decimal(18,2)");
            builder.Property(p => p.QuantidadeParcelas).IsRequired();
            builder.Property(p => p.ValorParcelas).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Status).HasMaxLength(50);

            builder.HasOne(p => p.Cartao).WithMany().HasForeignKey(p => p.CartaoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}