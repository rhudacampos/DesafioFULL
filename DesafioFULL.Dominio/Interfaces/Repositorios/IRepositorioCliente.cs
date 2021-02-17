using DesafioFULL.Dominio.Entidades;

namespace DesafioFULL.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioCliente : IRepositorioBase<Cliente>
    {
        Cliente ObterPorCPF(Cliente cliente);
    }
}
