
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
    public class EmpresaServico : IEmpresaServico
    {

        private IEmpresaRepositorio AdmRepositorio;
        public EmpresaServico(IEmpresaRepositorio _AdmRepositorio)
        {
            AdmRepositorio = _AdmRepositorio;
        }
        public string Adicionar(EmpresaEntidade entity)
        {
            return AdmRepositorio.Adicionar(entity);
        }

        public string Atualizar(EmpresaEntidade entity)
        {
            return AdmRepositorio.Atualizar(entity);
        }

       
        public string Deletar(Func<EmpresaEntidade, bool> predicate)
        {
            return AdmRepositorio.Deletar(predicate);
        }

       

        public List<EmpresaEntidade> ObterFiltros(Expression<Func<EmpresaEntidade, bool>> predicate)
        {
            return AdmRepositorio.ObterFiltros(predicate);
        }

      
        public List<EmpresaEntidade> ObterTodos(bool includes)
        {
            return AdmRepositorio.ObterTodos(includes);
        }

        public EmpresaEntidade Primeiro(Expression<Func<EmpresaEntidade, bool>> predicate)
        {
            return AdmRepositorio.Primeiro(predicate);
        }

        public EmpresaEntidade Procurar(params object[] key)
        {
            return AdmRepositorio.Procurar(key);
        }
    }
}
