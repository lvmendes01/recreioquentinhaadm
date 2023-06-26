using Lvmendes.Adms.Entidade;
using Microsoft.AspNetCore.Http;

namespace Lvmendes.Adms.Entidade
{
    public class CardapioModel
    {
        public string Codigo_Cardapio { get; set; }
        public string Produto { get; set; }
        public IFormFile FormFile { get; set; }
        public string Imagem { get; set; }
        public decimal ValorFinal { get; set; }
        public decimal ValorCusto { get; set; }
        public decimal PorcentagemLucro { get; set; }
        public int Qtdade { get; set; }
        public int DiaSemana { get; set; }
        public Int64 EmpresaId { get; set; }

        public CardapioEntidade PassarParaEntidade()
        {
            return new CardapioEntidade
            {
                Cod_Produto = Codigo_Cardapio,
                Produto = Produto,
                FormFile = FormFile,
                PorcentagemLucro = PorcentagemLucro,
                ValorCusto = ValorCusto,
                DiaSemana = (SemanaEnum) DiaSemana,
                Qtdade = Qtdade,
                ValorFinal = ValorFinal,
                Empresa = new EmpresaEntidade {Id= EmpresaId },
                

            };
        }
    }
}
