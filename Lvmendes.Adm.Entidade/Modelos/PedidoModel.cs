
using Lvmendes.Adm.Entidade;

namespace Lvmendes.Adms.Entidade
{
    public class PedidoModel
    {
        public Int64 Id { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Referencia { get; set; }
        public Int64 IdCliente { get; set; }
        public SituacaoEnum Situacao { get; set; }

        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();

    }

    public class ItemPedido
    {
        public Int64 ProdutoId { get; set; }
        public string Nome { get; set; }
        public int Qtdade { get; set; }
    }

    public class PedidoAtualizarModel
    {
        public Int64 Id { get; set; }
        public SituacaoEnum Situacao { get; set; }


    }
    public class PedidoConsultaModel
    {
        public Int64 Id { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Referencia { get; set; }
        public string Cliente { get; set; }
        public string Telefone { get; set; }
        public string Situacao { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public List<ItemPedido> Itens { get; set; }
    }

}
