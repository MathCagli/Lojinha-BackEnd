using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Repository.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Nome).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Login).IsRequired().HasMaxLength(50);
            builder.Property(u => u.SenhaHash).IsRequired();
            builder.Property(u => u.SenhaSalt).IsRequired();
            builder.Property(u => u.Token).HasMaxLength(500);
            builder.Property(u => u.DataToken);
            builder.Property(u => u.Cpf).HasMaxLength(11);
            builder.Property(u => u.Cnpj).HasMaxLength(14);
            builder.Property(u => u.Telefone).HasMaxLength(15);
            builder.Property(u => u.DataNascimento);
            builder.Property(u => u.NomeFantasia).HasMaxLength(100);
            builder.Property(u => u.RazaoSocial).HasMaxLength(100);
            builder.Property(u => u.Status).HasMaxLength(50);
            builder.Property(u => u.TipoUsuario).HasMaxLength(50);

            builder.HasMany(u => u.ListaEndereco).WithOne(e => e.Usuario).HasForeignKey(e => e.UsuarioId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(u => u.ListaCartao).WithOne(c => c.Usuario).HasForeignKey(c => c.UsuarioId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(u => u.ListaDadoBancario).WithOne(db => db.Usuario).HasForeignKey(db => db.UsuarioId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(u => u.ListaProduto).WithOne(p => p.Usuario).HasForeignKey(p => p.UsuarioId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}