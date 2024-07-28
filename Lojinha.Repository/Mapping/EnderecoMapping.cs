using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Repository.Mapping
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable(nameof(Endereco));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Rua).HasMaxLength(100);
            builder.Property(e => e.Numero).HasMaxLength(10);
            builder.Property(e => e.Cidade).HasMaxLength(100);
            builder.Property(e => e.Estado).HasMaxLength(50);
            builder.Property(e => e.Cep).HasMaxLength(8);

            builder.HasOne(e => e.Usuario).WithMany(u => u.ListaEndereco).HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}