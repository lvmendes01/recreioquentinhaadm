using Lvmendes.Adms.Entidade;
using Lvmendes.Adms.Servico;
using Lvmendes.Adms.Servico.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lvmendes.Adms.ApiAdms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly ICardapioServico servico;

        public MesaController(ICardapioServico _servico)
        {
            servico = _servico;
        }
       
    }
}
