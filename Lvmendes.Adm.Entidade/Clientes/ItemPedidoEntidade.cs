using Lvmendes.Adms.Entidade;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lvmendes.Adm.Entidade
{
    [Table("Tb_Pedido_Item")]
    public class ItemPedidoEntidade : IdentificadorEntidade
    {
        public CardapioEntidade Produto { get; set; }
        public decimal ValorProduto { get; set; }
        public int Qtdade { get; set; }
        public DateTime? HoraEntrega { get; set; }
    }
}