
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
    public class MesaServico : IMesaServico
    {

        private IMesaRepositorio AdmRepositorio;
        public MesaServico(IMesaRepositorio _AdmRepositorio)
        {
            AdmRepositorio = _AdmRepositorio;
        }
        public string Adicionar(MesaEntidade entity)
        {
            return AdmRepositorio.Adicionar(entity);
        }

        public string Atualizar(MesaEntidade entity)
        {
            return AdmRepositorio.Atualizar(entity);
        }

       
        public string Deletar(Func<MesaEntidade, bool> predicate)
        {
            return AdmRepositorio.Deletar(predicate);
        }

       

        public List<MesaEntidade> ObterFiltros(Expression<Func<MesaEntidade, bool>> predicate)
        {
            return AdmRepositorio.ObterFiltros(predicate);
        }

      
        public List<MesaEntidade> ObterTodos(bool includes)
        {
            return AdmRepositorio.ObterTodos(includes);
        }

        public MesaEntidade Primeiro(Expression<Func<MesaEntidade, bool>> predicate)
        {
            return AdmRepositorio.Primeiro(predicate);
        }

        public MesaEntidade Procurar(params object[] key)
        {
            return AdmRepositorio.Procurar(key);
        }
    }
}
