using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Repository.Mapping
{
    public class CarrinhoMapping : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.ToTable(nameof(Carrinho));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.DataCriacao).IsRequired();

            builder.HasMany(c => c.ListaItem).WithOne().HasForeignKey(c => c.CarrinhoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}