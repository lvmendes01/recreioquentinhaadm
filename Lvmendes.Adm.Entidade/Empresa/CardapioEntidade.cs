
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
namespace Lvmendes.Adms.Entidade
{

    [Table("Tb_Cardapio")]
    public class CardapioEntidade : IdentificadorEntidade
    {
        public string Cod_Produto { get; set; }
        public string Produto { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
        public string Imagem { get; set; }
        public decimal ValorFinal { get; set; }
        public decimal ValorCusto { get; set; }
        public decimal PorcentagemLucro { get; set; }
        public int Qtdade { get; set; }
        public SemanaEnum DiaSemana { get; set; }
        public EmpresaEntidade Empresa { get; set; }
    }
}
