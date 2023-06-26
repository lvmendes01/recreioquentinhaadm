
using System.ComponentModel.DataAnnotations.Schema;

namespace Lvmendes.Adms.Entidade
{

    [Table("Tb_Usuario_Adm")]
    public class UsuarioEntidade : IdentificadorEntidade
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public virtual PerfilEntidade Perfil { get; set; }
        public virtual EmpresaEntidade Empresa { get; set; }
        public Boolean Ativo { get; set; }
    }
}
