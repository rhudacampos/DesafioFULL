using DesafioFULL.Dominio.Entidades;
using DesafioFULL.Repositorio.Config;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Email = "admin@admin.com",
                    Senha = "admin",
                    Nome = "Administrador",
                    SobreNome = "Admin"
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<TituloParcela> TituloParcelas { get; set; }
        
    }
}
