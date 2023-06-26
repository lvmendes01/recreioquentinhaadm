using System.ComponentModel.DataAnnotations.Schema;

namespace Lvmendes.Adms.Entidade
{

    [Table("Tb_Perfil")]
    public class PerfilEntidade : IdentificadorEntidade
    {
        public string Nome { get; set; }
        public string Url { get; set; }
    }
}