using DesafioFULL.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DesafioFULL.Repositorio.Contexto
{
    public class DesafioFULLContexto: DbContext
    {
        public DesafioFULLContexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<TituloParcela> TituloParcelas { get; set; }
        
    }
}
