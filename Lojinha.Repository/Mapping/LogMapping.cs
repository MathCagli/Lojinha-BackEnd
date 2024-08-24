using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Repository.Mapping;

public class LogMapping : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.ToTable(nameof(Log));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(u => u.Evento).HasMaxLength(4000);
        builder.Property(u => u.Tipo).HasMaxLength(100);
        builder.Property(u => u.Usuario);
    }
}