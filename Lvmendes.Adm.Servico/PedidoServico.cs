
using Lvmendes.Adm.Entidade;
using Lvmendes.Adms.Entidade;
using Lvmendes.Adms.Repositorio.Interfaces;
using Lvmendes.Adms.Servico.Interfaces;
using System.Linq.Expressions;

namespace Lvmendes.Adms.Servico
{
    //public class AdmsServico : ComumServico<AdmEntidade>, IAdmsServico
    //{
    //    protected AdmsServico(IComumRepositorio<AdmEntidade> repositorio) : base(repositorio)
    //    {
    //    }
    //}
    public class PedidoServico : IPedidoServico
    {

        private IPedidoRepositorio AdmRepositorio;
        private IClienteRepositorio ClienteRepositorio;
        private ICardapioRepositorio CardapioRepositorio;
        public PedidoServico(ICardapioRepositorio _CardapioRepositorio, IClienteRepositorio _ClienteRepositorio, IPedidoRepositorio _AdmRepositorio)
        {
            ClienteRepositorio = _ClienteRepositorio;
            AdmRepositorio = _AdmRepositorio;
            CardapioRepositorio = _CardapioRepositorio;
        }
        public string Adicionar(PedidoEntidade entity)
        {
            return AdmRepositorio.Adicionar(entity);
        }

        public string Atualizar(PedidoEntidade entity)
        {
            return AdmRepositorio.Atualizar(entity);
        }

        public string AtualizarPedido(PedidoAtualizarModel pedidoAtualizar)
        {
            var pedido = AdmRepositorio.Primeiro(s => s.Id == pedidoAtualizar.Id);
            if (pedido == null)
                return "Pedido Não Encontrado";
            pedido.SituacaoPedido = pedidoAtualizar.Situacao;

            return Atualizar(pedido);

        }

        public PedidoModel ConsultaPedido(long IdPedido)
        {
            var pedido = AdmRepositorio.Primeiro(s => s.Id == IdPedido);


            var pedidoModel = new PedidoModel();

            pedidoModel.Situacao = pedido.SituacaoPedido;

            foreach (var item in pedido.Items)
            {

                pedidoModel.Itens.Add(new ItemPedido
                {
                    Nome = item.Produto.Produto,
                    Qtdade = item.Qtdade,
                    ProdutoId = item.Id



                });

            }

            return pedidoModel;

        }

        public string Deletar(Func<PedidoEntidade, bool> predicate)
        {
            return AdmRepositorio.Deletar(predicate);
        }

        public List<PedidoConsultaModel> ListaPedidosAbertoPorEmpresa(long EmpresaId)
        {
            var pedidos = AdmRepositorio.ObterFiltros(s =>
            s.SituacaoPedido != SituacaoEnum.Finalizado ||
            s.SituacaoPedido != SituacaoEnum.Cancelado ||
            s.SituacaoPedido != SituacaoEnum.Entregue
                        ).ToList();



            var pedidoModel = new List<PedidoConsultaModel>();


            foreach (var item in pedidos.Where(x => x.Items.Exists(s => s.Produto.Empresa.Id == EmpresaId)).ToList())
            {
                var pedidosLista = new List<ItemPedido>();


                item.Items.ForEach(s =>
                {

                    pedidosLista.Add(new ItemPedido { Nome = s.Produto.Produto, Qtdade = s.Qtdade, ProdutoId = s.Id });
                });




                pedidoModel.Add(new PedidoConsultaModel
                {
                    Cliente = item.Cliente.Nome,
                    CEP = item.CEP,
                    Endereco = item.Endereco,
                    Referencia = item.Referencia,
                    Telefone = item.Cliente.Telefone,
                    Id = item.Id,
                    Itens = pedidosLista,
                    Situacao = item.SituacaoPedido.ToString(),
                    DataSolicitacao = item.DataCadastro


                });

            }

            return pedidoModel;
        }

        public List<PedidoConsultaModel> ListaPedidosCliente(long ClienteId)
        {
            var pedidos = AdmRepositorio.ObterFiltros(s =>s.Cliente.Id == ClienteId).ToList();
            var pedidoModel = new List<PedidoConsultaModel>();
            foreach (var item in pedidos)
            {
                var pedidosLista = new List<ItemPedido>();
                item.Items.ForEach(s =>
                {
                    pedidosLista.Add(new ItemPedido { Nome = s.Produto.Produto, Qtdade = s.Qtdade, ProdutoId = s.Id });
                });

                pedidoModel.Add(new PedidoConsultaModel
                {
                    Cliente = item.Cliente.Nome,
                    CEP = item.CEP,
                    Endereco = item.Endereco,
                    Referencia = item.Referencia,
                    Telefone = item.Cliente.Telefone,
                    Id = item.Id,
                    Itens = pedidosLista,
                    Situacao = item.SituacaoPedido.ToString(),
                    DataSolicitacao = item.DataCadastro


                });
            }

            return pedidoModel;
        }

        public List<PedidoConsultaModel> ListaPedidosClienteAberto(long ClienteId)
        {
            return ListaPedidosCliente(ClienteId).Where(s =>
             s.Situacao != SituacaoEnum.Cancelado.ToString() ||
              s.Situacao != SituacaoEnum.Entregue.ToString() ||
               s.Situacao != SituacaoEnum.Finalizado.ToString()
            ).ToList();
        }

        public List<PedidoEntidade> ObterFiltros(Expression<Func<PedidoEntidade, bool>> predicate)
        {
            return AdmRepositorio.ObterFiltros(predicate);
        }


        public List<PedidoEntidade> ObterTodos(bool includes)
        {
            return AdmRepositorio.ObterTodos(includes);
        }

        public PedidoEntidade Primeiro(Expression<Func<PedidoEntidade, bool>> predicate)
        {
            return AdmRepositorio.Primeiro(predicate);
        }

        public PedidoEntidade Procurar(params object[] key)
        {
            return AdmRepositorio.Procurar(key);
        }

        public string RealizarPedido(PedidoModel pedido)
        {
            //pego o cliente 
            var cliente = ClienteRepositorio.Primeiro(s => s.Id == pedido.IdCliente);

            if (cliente == null)
                return "Cliente não cadastrado";


            pedido.CEP = String.IsNullOrEmpty(pedido.CEP) ? cliente.CEP : pedido.CEP;
            pedido.Endereco = String.IsNullOrEmpty(pedido.Endereco) ? cliente.Endereco : pedido.Endereco;
            pedido.Referencia = String.IsNullOrEmpty(pedido.Referencia) ? cliente.Referencia : pedido.Referencia;


            var pedidoentida = new PedidoEntidade
            {
                CEP = pedido.CEP,
                Cliente = cliente,
                Endereco = pedido.Endereco,
                Referencia = pedido.Referencia,
                Id = pedido.Id
            };

            foreach (var item in pedido.Itens)
            {
                var produto = CardapioRepositorio.Primeiro(s => s.Id == item.ProdutoId);

                if (produto != null)
                {

                    decimal valorTotalItem = produto.ValorFinal * item.Qtdade;
                    pedidoentida.Items.Add(new ItemPedidoEntidade
                    {
                        Produto = produto,
                        Qtdade = item.Qtdade,
                        ValorProduto = valorTotalItem
                    });
                    pedidoentida.ValorFinal += valorTotalItem;
                }

            }




            if (pedido.Id > 0)
            {
                return Atualizar(pedidoentida);
            }
            else
            {
                return Adicionar(pedidoentida);
            }




        }
    }
}
