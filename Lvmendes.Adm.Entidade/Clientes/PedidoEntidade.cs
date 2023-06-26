using Lvmendes.Adms.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.Adm.Entidade
{
    [Table("Tb_Pedido")]
    public class PedidoEntidade : IdentificadorEntidade
    {
        public List<ItemPedidoEntidade> Items { get; set; } = new List<ItemPedidoEntidade>();
        public decimal ValorFinal { get; set; }
        public ClienteEntidade Cliente { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Referencia { get; set; }
        public SituacaoEnum SituacaoPedido { get; set; } = SituacaoEnum.Solicitado;
    }

   
}
