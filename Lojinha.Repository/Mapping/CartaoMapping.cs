using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Repository.Mapping
{
    public class CartaoMapping : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable(nameof(Cartao));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Numero).IsRequired().HasMaxLength(16);
            builder.Property(x => x.Codigo).IsRequired().HasMaxLength(3);
            builder.Property(x => x.MesVencimento).IsRequired().HasMaxLength(2);
            builder.Property(x => x.AnoVencimento).IsRequired().HasMaxLength(4);

            builder.HasOne(c => c.Usuario).WithMany(u => u.ListaCartao).HasForeignKey(c => c.UsuarioId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}