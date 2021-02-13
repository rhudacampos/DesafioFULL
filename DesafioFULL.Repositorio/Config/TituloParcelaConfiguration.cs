﻿using DesafioFULL.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioFULL.Repositorio.Config
{
    public class TituloParcelaConfiguration : IEntityTypeConfiguration<TituloParcela>
    {
        public void Configure(EntityTypeBuilder<TituloParcela> builder)
        {
            builder.HasKey(tp => tp.Id);
            
            builder.Property(tp => tp.Vencimento)
                .IsRequired();

            builder.Property(tp => tp.VlrOriginal)
                .IsRequired();
        }
    }
}
