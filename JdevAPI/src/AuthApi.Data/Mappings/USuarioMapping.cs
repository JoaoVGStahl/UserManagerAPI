using AuthApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthApi.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario).ToLower());

            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasColumnType("varchar(64)").IsRequired();
            builder.Property(p => p.Senha).HasColumnType("varchar(32)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Apagado).HasColumnType("bit(1)").HasDefaultValue(false).IsRequired();

            builder.HasIndex(i => i.Email).IsUnique();
        }
    }
}
