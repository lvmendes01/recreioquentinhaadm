
using Lvmendes.Adms.Entidade;
using Lvmendes.Adms.Servico;
using Lvmendes.Adms.Servico.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lvmendes.Adms.ApiAdms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioController : ControllerBase
    {
        private readonly ICardapioServico servico;
        private readonly IConfiguration _configuration;
        private string _filePath;
        public CardapioController(IConfiguration configuration, ICardapioServico _servico, IWebHostEnvironment env)
        {
            _configuration = configuration;
            servico = _servico; 
            _filePath = env.WebRootPath;

        }
        [HttpPost("Salvar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RetornoApi> Salvar([FromForm] CardapioModel item)
        {           

            var cardapio = item.PassarParaEntidade();

            cardapio.Imagem = _configuration.GetSection("CaminhoImagems").Value;
            var retornoChamado = servico.Adicionar(cardapio);
            RetornoApi retorno = new RetornoApi
            {
                Resultado = retornoChamado,
                Status = retornoChamado != null,
                Mensagem = retornoChamado == null ? "CardapioEntidades não Encontrado" : string.Empty

            };
            return retorno;
        }


        /// <summary>
        /// Lista os itens da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Returna os itens da To-do list cadastrados</response>
        [HttpGet("ObterCardapio")]
        public ActionResult<RetornoApi> ObterCardapio(bool todos )
        {
            var retornoChamado = servico.ObterTodos(true);
            foreach (var item in retornoChamado)
            {
                item.Imagem = _configuration.GetSection("CaminhoImagems").Value+"\\Produto\\" + item.Empresa.Id +"\\"+ item.Imagem;

            }
            RetornoApi retorno = new RetornoApi
            {
                Resultado = retornoChamado,
                Status = retornoChamado != null,
                Mensagem = retornoChamado == null ? "CardapioEntidades não Encontrado" : string.Empty

            };
            return retorno;
        }
    }
}
