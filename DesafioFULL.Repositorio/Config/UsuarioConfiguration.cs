using DesafioFULL.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DesafioFULL.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Senha)
                            .IsRequired()
                            .HasMaxLength(400);

            builder.Property(u => u.Nome)
                            .IsRequired()
                            .HasMaxLength(100);

            builder.Property(u => u.SobreNome)
                            .HasMaxLength(100);
        }
    }
}
