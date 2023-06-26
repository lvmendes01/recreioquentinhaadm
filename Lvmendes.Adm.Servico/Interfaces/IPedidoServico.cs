using Lvmendes.Adm.Entidade;
using Lvmendes.Adms.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.Adms.Servico.Interfaces
{
    public interface IPedidoServico : IComumServico<PedidoEntidade>
    {

      string  RealizarPedido(PedidoModel pedido);

        List<PedidoConsultaModel> ListaPedidosAbertoPorEmpresa(Int64 EmpresaId);
        string AtualizarPedido(PedidoAtualizarModel pedidoAtualizar);

        PedidoModel ConsultaPedido(Int64 IdPedido);
        List<PedidoConsultaModel> ListaPedidosCliente(Int64 ClienteId);
        List<PedidoConsultaModel> ListaPedidosClienteAberto(Int64 ClienteId);


        

    }
}
