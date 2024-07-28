using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Repository.Mapping
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable(nameof(Item));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(i => i.Valor).IsRequired();
            builder.Property(i => i.Quantidade).IsRequired();

            builder.HasOne(i => i.Pedido).WithMany(p => p.ListaItem).HasForeignKey(i => i.PedidoId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(i => i.Produto).WithMany(p => p.ListaItem).HasForeignKey(i => i.ProdutoId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(i => i.Carrinho).WithMany(c => c.ListaItem).HasForeignKey(c => c.CarrinhoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}