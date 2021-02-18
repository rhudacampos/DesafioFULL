using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Repositorio.Config;
using Microsoft.EntityFrameworkCore;
using System;

namespace DesafioFULL.Repositorio.Contexto
{
    public class DesafioFULLContexto: DbContext
    {
        public DesafioFULLContexto(DbContextOptions options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new TituloConfiguration());
            modelBuilder.ApplyConfiguration(new TituloParcelaConfiguration());
            modelBuilder.ApplyConfiguration(new TituloVerificacaoConfiguration());

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Email = "admin@admin.com",
                    Senha = "admin",
                    Nome = "Administrador",
                    SobreNome = "Admin"
                });

            modelBuilder.Entity<Cliente>().HasData(
                                       new Cliente
                                       {
                                           Id = 1,
                                           Nome = "Fulano",
                                           SobreNome = "Beltrano",
                                           CPF = "06734084000",
                                           Fone = "14999999999"
                                       });

            modelBuilder.Entity<Titulo>().HasData(
                            new Titulo
                            {
                                Id = 1,
                                ClienteId = 1,
                                PerJuros = 1,
                                PerMulta = 2,
                                VlrOriginal = 300
                            });

            modelBuilder.Entity<TituloParcela>().HasData(
                                        new TituloParcela
                                        {
                                            Id = 1,
                                            TituloId = 1,
                                            NumParcela = 1,
                                            Vencimento = new DateTime(2020, 07, 10),
                                            VlrOriginal = 100
                                        },
                                        new TituloParcela
                                        {
                                            Id = 2,
                                            TituloId = 1,
                                            NumParcela = 2,
                                            Vencimento = new DateTime(2020, 08, 10),
                                            VlrOriginal = 100
                                        },
                                        new TituloParcela
                                        {
                                            Id = 3,
                                            TituloId = 1,
                                            NumParcela = 3,
                                            Vencimento = new DateTime(2020, 09, 10),
                                            VlrOriginal = 100
                                        } );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<TituloParcela> TituloParcelas { get; set; }
        public DbSet<TituloVerificacao> TituloVerificacoes { get; set; }

    }
}
