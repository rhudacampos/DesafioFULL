using DesafioFULL.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DesafioFULL.Repositorio.Config
{
    public class TituloVerificacaoConfiguration : IEntityTypeConfiguration<TituloVerificacao>
    {
        public void Configure(EntityTypeBuilder<TituloVerificacao> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.DataVerificacao)
                .IsRequired();
        }
    }
}
