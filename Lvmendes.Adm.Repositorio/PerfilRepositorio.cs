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

    public class PerfilRepositorio : IPerfilRepositorio
    {
        internal AdmContext Context;
        public PerfilRepositorio(AdmContext context)
        {
            Context = context;
        }
        public string Adicionar(PerfilEntidade entity)
        {

            try
            {
                Context.Set<PerfilEntidade>().Add(entity);
                Context.SaveChanges();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Atualizar(PerfilEntidade entity)
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


        public string Deletar(Func<PerfilEntidade, bool> predicate)
        {
            try
            {
                Context.Set<PerfilEntidade>()
          .Where(predicate).ToList()
          .ForEach(del => Context.Set<PerfilEntidade>().Remove(del));
                Context.SaveChanges();
                return "Deletado com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

 

        public List<PerfilEntidade> ObterFiltros(Expression<Func<PerfilEntidade, bool>> predicate)
        {
            return Context.Set<PerfilEntidade>().Where(predicate).ToList();
        }

  
        public List<PerfilEntidade> ObterTodos(bool includes = false)
        {
            var query = Context.Set<PerfilEntidade>().AsQueryable();
            
            return query.ToList();
        }

        public PerfilEntidade Primeiro(Expression<Func<PerfilEntidade, bool>> predicate)
        {
            return Context.Set<PerfilEntidade>().Where(predicate).FirstOrDefault();
        }

        public PerfilEntidade Procurar(params object[] key)
        {
            return Context.Set<PerfilEntidade>().Find(key);
        }
    }
}
