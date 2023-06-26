
using System.ComponentModel.DataAnnotations.Schema;

namespace Lvmendes.Adms.Entidade
{

    [Table("Tb_Mesa")]
    public class MesaEntidade : IdentificadorEntidade
    {
        public string Cod_Mesa { get; set; }
        public string LocalMesa { get; set; }
        public string Numero { get; set; }
        public bool Disponivel { get; set; }
      
    }
}
