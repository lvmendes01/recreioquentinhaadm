using Lvmendes.Adms.Entidade;
using Lvmendes.Adms.Servico.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lvmendes.Adm.ApiAdm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoServico servico;

        public PedidosController(IPedidoServico _servico)
        {
            servico = _servico;
        }
        [HttpPost("Atualizar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RetornoApi> Atualizar(PedidoAtualizarModel item)
        {
            var resultado = servico.AtualizarPedido(item);
            return new RetornoApi
            {
                Resultado = resultado,
                Status = resultado == "Atualizar com sucesso!!"
            };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RetornoApi> ListaPedidosAbertoPorEmpresa(Int64 EmpresaID)
        {
            var resultado = servico.ListaPedidosAbertoPorEmpresa(EmpresaID);
            return new RetornoApi
            {
                Resultado = resultado,
                Status = resultado != null
            };

        }

    }
}
