using Lvmendes.Adms.Entidade;
using Lvmendes.Adms.Servico;
using Lvmendes.Adms.Servico.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lvmendes.Adms.ApiAdms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaServico servico;

        public EmpresaController(IEmpresaServico _servico)
        {
            servico = _servico;
        }
        [HttpPost("Salvar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RetornoApi> Salvar(EmpresaEntidade item)
        {
            servico.Adicionar(item);
            return new RetornoApi
            {
                Resultado = true,
                Status = true
            };
        }


        /// <summary>
        /// Lista os itens da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Returna os itens da To-do list cadastrados</response>
        [HttpGet("ObterEmpresa")]
        public ActionResult<RetornoApi> ObterEmpresa(bool todos )
        {
            var retornoChamado = servico.ObterTodos(todos);
            RetornoApi retorno = new RetornoApi
            {
                Resultado = retornoChamado,
                Status = retornoChamado != null,
                Mensagem = retornoChamado == null ? "EmpresaEntidades não Encontrado" : string.Empty

            };
            return retorno;
        }
    }
}
