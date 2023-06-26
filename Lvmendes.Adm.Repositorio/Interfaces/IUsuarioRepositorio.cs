


using Lvmendes.Adms.Entidade;

namespace Lvmendes.Adms.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio : IComumRepositorio<UsuarioEntidade>
    {
        UsuarioEntidade Login(String usuario, string senha);

    }
}
