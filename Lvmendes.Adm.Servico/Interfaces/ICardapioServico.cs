using Lvmendes.Adms.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.Adms.Servico.Interfaces
{
    public interface ICardapioServico : IComumServico<CardapioEntidade>
    {
        List<CardapioEntidade> ListaPorEmpresa(Int64 EmpresaId);
        List<CardapioEntidade> ListaPorEmpresaEDiaSemana(Int64 EmpresaId, SemanaEnum diaSemana);
    }
}
