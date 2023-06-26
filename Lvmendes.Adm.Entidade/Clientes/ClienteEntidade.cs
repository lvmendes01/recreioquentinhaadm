using Lvmendes.Adms.Entidade;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lvmendes.Adm.Entidade
{
    [Table("Tb_Cliente")]
    public class ClienteEntidade : IdentificadorEntidade
    {
        public string Telefone { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Referencia { get; set; }
    }
}