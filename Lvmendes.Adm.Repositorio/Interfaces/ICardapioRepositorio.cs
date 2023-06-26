


using Lvmendes.Adms.Entidade;

namespace Lvmendes.Adms.Repositorio.Interfaces
{
    public interface ICardapioRepositorio : IComumRepositorio<CardapioEntidade>
    {
        List<CardapioEntidade> ListaPorEmpresa(Int64 EmpresaId);
        List<CardapioEntidade> ListaPorEmpresaEDiaSemana(Int64 EmpresaId, SemanaEnum diaSemana);

    }
}
