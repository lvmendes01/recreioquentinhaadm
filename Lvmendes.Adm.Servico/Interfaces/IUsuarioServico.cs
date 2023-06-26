using Lvmendes.Adms.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.Adms.Servico.Interfaces
{
    public interface IUsuarioServico : IComumServico<UsuarioEntidade>
    {

        UsuarioEntidade Login(string login, string senha);
    }
}
