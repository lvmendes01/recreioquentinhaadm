using Lvmendes.Adm.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.Adms.Servico.Interfaces
{
    public interface IClienteServico : IComumServico<ClienteEntidade>
    {
        ClienteEntidade Login(string login, string senha);
    }
}
