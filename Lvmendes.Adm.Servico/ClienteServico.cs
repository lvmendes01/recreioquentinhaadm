
using Lvmendes.Adm.Entidade;
using Lvmendes.Adms.Repositorio.Interfaces;
using Lvmendes.Adms.Servico.Interfaces;
using System.Linq.Expressions;

namespace Lvmendes.Adms.Servico
{
    //public class AdmsServico : ComumServico<AdmEntidade>, IAdmsServico
    //{
    //    protected AdmsServico(IComumRepositorio<AdmEntidade> repositorio) : base(repositorio)
    //    {
    //    }
    //}
    public class ClienteServico : IClienteServico
    {

        private IClienteRepositorio AdmRepositorio;
        public ClienteServico(IClienteRepositorio _AdmRepositorio)
        {
            AdmRepositorio = _AdmRepositorio;
        }
        public string Adicionar(ClienteEntidade entity)
        {
            return AdmRepositorio.Adicionar(entity);
        }

        public string Atualizar(ClienteEntidade entity)
        {
            return AdmRepositorio.Atualizar(entity);
        }

       
        public string Deletar(Func<ClienteEntidade, bool> predicate)
        {
            return AdmRepositorio.Deletar(predicate);
        }

        public ClienteEntidade Login(string login, string senha)
        {
            return AdmRepositorio.Primeiro(s=>s.Telefone == login && s.Senha == senha);
        }

        public List<ClienteEntidade> ObterFiltros(Expression<Func<ClienteEntidade, bool>> predicate)
        {
            return AdmRepositorio.ObterFiltros(predicate);
        }

      
        public List<ClienteEntidade> ObterTodos(bool includes)
        {
            return AdmRepositorio.ObterTodos(includes);
        }

        public ClienteEntidade Primeiro(Expression<Func<ClienteEntidade, bool>> predicate)
        {
            return AdmRepositorio.Primeiro(predicate);
        }

        public ClienteEntidade Procurar(params object[] key)
        {
            return AdmRepositorio.Procurar(key);
        }
    }
}
