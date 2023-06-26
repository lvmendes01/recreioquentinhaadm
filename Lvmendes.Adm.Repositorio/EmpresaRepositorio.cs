using Lvmendes.Adms.Entidade;
using Lvmendes.Adms.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.Adms.Repositorio
{
    //public class AdmRepositorio : ComumRepositorio<AdmEntidade>, IAdmRepositorio
    //{       
    //    protected AdmRepositorio(AdmContext context) : base(context)
    //    {
    //    }
    //}

    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        internal AdmContext Context;
        public EmpresaRepositorio(AdmContext context)
        {
            Context = context;
        }
        public string Adicionar(EmpresaEntidade entity)
        {

            try
            {
                Context.Set<EmpresaEntidade>().Add(entity);
                Context.SaveChanges();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Atualizar(EmpresaEntidade entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                return "Atualizar com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

       
        public string Deletar(Func<EmpresaEntidade, bool> predicate)
        {
            try
            {
                Context.Set<EmpresaEntidade>()
          .Where(predicate).ToList()
          .ForEach(del => Context.Set<EmpresaEntidade>().Remove(del));
                Context.SaveChanges();
                return "Deletado com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

 
        public List<EmpresaEntidade> ObterFiltros(Expression<Func<EmpresaEntidade, bool>> predicate)
        {
            return Context.Set<EmpresaEntidade>().Where(predicate).ToList();
        }

 

        public List<EmpresaEntidade> ObterTodos(bool includes = false)
        {
            var query = Context.Set<EmpresaEntidade>().AsQueryable();
            
            return query.ToList();
        }

        public EmpresaEntidade Primeiro(Expression<Func<EmpresaEntidade, bool>> predicate)
        {
            return Context.Set<EmpresaEntidade>().Where(predicate).FirstOrDefault();
        }

        public EmpresaEntidade Procurar(params object[] key)
        {
            return Context.Set<EmpresaEntidade>().Find(key);
        }
    }
}
