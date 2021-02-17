using DesafioFULL.Dominio.Entidades;

namespace DesafioFULL.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioTituloVerificacao: IRepositorioBase<TituloVerificacao>
    {
        TituloVerificacao ObterVerificacaoAtual();
    }
}
