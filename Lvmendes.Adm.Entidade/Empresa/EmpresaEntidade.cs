using System.ComponentModel.DataAnnotations.Schema;

namespace Lvmendes.Adms.Entidade
{

    [Table("Tb_Empresa")]
    public class EmpresaEntidade : IdentificadorEntidade
    {
        public string Nome { get; set; }
        public string? ImagemEmpresa { get; set; }
        public string? Localizacao { get; set; }
        public string? Pix { get; set; }
        public Boolean Ativo { get; set; }
        public DateTime DataDesativacao { get; set; }
    }
}