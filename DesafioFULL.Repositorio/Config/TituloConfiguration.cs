using DesafioFULL.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DesafioFULL.Repositorio.Config
{
    public class TituloConfiguration : IEntityTypeConfiguration<Titulo>
    {
        public void Configure(EntityTypeBuilder<Titulo> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.ClienteId)
                .IsRequired();

            builder.Property(t => t.VlrOriginal)
                .HasColumnType("decimal(19,4)");

            builder.Property(t => t.VlrJuros)
                .HasColumnType("decimal(19,4)");

            builder.Property(t => t.VlrMulta)
                .HasColumnType("decimal(19,4)");

            builder.Property(t => t.VlrCorrigido)
                .HasColumnType("decimal(19,4)");

            builder.HasIndex(t => t.ClienteId);

            builder.HasMany(t => t.Parcelas)
                .WithOne(p => p.Titulo);

        }
    }
}
