
using Lvmendes.Adms.Entidade;
using Lvmendes.Adms.Repositorio.Interfaces;
using Lvmendes.Adms.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.Adms.Servico
{
    //public class AdmsServico : ComumServico<AdmEntidade>, IAdmsServico
    //{
    //    protected AdmsServico(IComumRepositorio<AdmEntidade> repositorio) : base(repositorio)
    //    {
    //    }
    //}
    public class PerfilServico : IPerfilServico
    {

        private IPerfilRepositorio AdmRepositorio;
        public PerfilServico(IPerfilRepositorio _AdmRepositorio)
        {
            AdmRepositorio = _AdmRepositorio;
        }
        public string Adicionar(PerfilEntidade entity)
        {
            return AdmRepositorio.Adicionar(entity);
        }

        public string Atualizar(PerfilEntidade entity)
        {
            return AdmRepositorio.Atualizar(entity);
        }

       
        public string Deletar(Func<PerfilEntidade, bool> predicate)
        {
            return AdmRepositorio.Deletar(predicate);
        }

       

        public List<PerfilEntidade> ObterFiltros(Expression<Func<PerfilEntidade, bool>> predicate)
        {
            return AdmRepositorio.ObterFiltros(predicate);
        }

      
        public List<PerfilEntidade> ObterTodos(bool includes)
        {
            return AdmRepositorio.ObterTodos(includes);
        }

        public PerfilEntidade Primeiro(Expression<Func<PerfilEntidade, bool>> predicate)
        {
            return AdmRepositorio.Primeiro(predicate);
        }

        public PerfilEntidade Procurar(params object[] key)
        {
            return AdmRepositorio.Procurar(key);
        }
    }
}
