using System.ComponentModel.DataAnnotations;

namespace Lvmendes.Adms.Entidade
{
    public class IdentificadorEntidade
    {
        [Key]
        public Int64  Id { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}