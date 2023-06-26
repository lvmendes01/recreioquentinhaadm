using Lvmendes.Adms.Entidade;
using Lvmendes.Adms.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lvmendes.Adms.ApiAdms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServico servico;

        public UsuarioController(IUsuarioServico _servico)
        {
            servico = _servico;
        }
        [HttpPost("Salvar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RetornoApi> Salvar(UsuarioModel item)
        {



           var resultado = servico.Adicionar(new UsuarioEntidade {
            Empresa = new EmpresaEntidade {Id = item.IdEmpresa },
            Login= item.Login,
            Senha = item.Senha,
            Perfil = new PerfilEntidade {Id = item.IdPerfil },
            Ativo = item.Ativo,
            Id = item.Id
            

            });
            return new RetornoApi
            {
                Resultado = resultado,
                Status = resultado == "Ok"
            };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RetornoApi> Login(string login, string senha)
        {



            var resultado = servico.Login(login, senha);
            return new RetornoApi
            {
                Resultado = resultado,
                Status = resultado != null
            };
        }





        /// <summary>
        /// Lista os itens da To-do list.
        /// </summary>
        /// <returns>Os itens da To-do list</returns>
        /// <response code="200">Returna os itens da To-do list cadastrados</response>
        [HttpGet("ObterUsuario")]
        public ActionResult<RetornoApi> ObterUsuario(bool todos )
        {
            var retornoChamado = servico.ObterTodos(todos);
            RetornoApi retorno = new RetornoApi
            {
                Resultado = retornoChamado,
                Status = retornoChamado != null,
                Mensagem = retornoChamado == null ? "UsuarioEntidades não Encontrado" : string.Empty

            };
            return retorno;
        }
    }
}
