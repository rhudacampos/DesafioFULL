using DesafioFULL.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFULL.Repositorio.Config
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(c => c.Nome)
                            .IsRequired()
                            .HasMaxLength(100);

            builder.Property(c => c.SobreNome)
                            .HasMaxLength(100);

            builder.HasIndex(c => c.CPF)
                                .IsUnique();

            builder.HasMany(c => c.Titulos)
                .WithOne(t => t.Cliente);
        }
    }
}
