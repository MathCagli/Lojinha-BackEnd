using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Repository.Mapping
{
    public class DadoBancarioMapping : IEntityTypeConfiguration<DadoBancario>
    {
        public void Configure(EntityTypeBuilder<DadoBancario> builder)
        {
            builder.ToTable(nameof(DadoBancario));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CodigoBanco).IsRequired().HasMaxLength(3);
            builder.Property(x => x.NumeroAgencia).IsRequired().HasMaxLength(4);
            builder.Property(x => x.DigitoAgencia).IsRequired().HasMaxLength(1);
            builder.Property(x => x.NumeroConta).IsRequired().HasMaxLength(12);
            builder.Property(x => x.DigitoConta).IsRequired().HasMaxLength(2);
            builder.Property(x => x.ChavePix).IsRequired().HasMaxLength(100);
            builder.Property(x => x.TipoConta).IsRequired().HasMaxLength(100);

            builder.HasOne(db => db.Usuario).WithMany(u => u.ListaDadoBancario).HasForeignKey(db => db.UsuarioId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}