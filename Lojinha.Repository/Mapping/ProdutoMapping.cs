using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Repository.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable(nameof(Produto));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Descricao).HasMaxLength(500);
            builder.Property(p => p.Imagem).HasMaxLength(255);
            builder.Property(p => p.CodigoBarras).HasMaxLength(50);
            builder.Property(p => p.QuantidadeEstoque).IsRequired();
            builder.Property(p => p.Valor).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Desconto).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Status).HasMaxLength(50);

            builder.HasOne(p => p.Usuario).WithMany(u => u.ListaProduto).HasForeignKey(p => p.UsuarioId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}