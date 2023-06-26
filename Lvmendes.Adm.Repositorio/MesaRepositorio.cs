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

    public class MesaRepositorio : IMesaRepositorio
    {
        internal AdmContext Context;
        public MesaRepositorio(AdmContext context)
        {
            Context = context;
        }
        public string Adicionar(MesaEntidade entity)
        {

            try
            {
                Context.Set<MesaEntidade>().Add(entity);
                Context.SaveChanges();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Atualizar(MesaEntidade entity)
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

     

        public string Deletar(Func<MesaEntidade, bool> predicate)
        {
            try
            {
                Context.Set<MesaEntidade>()
          .Where(predicate).ToList()
          .ForEach(del => Context.Set<MesaEntidade>().Remove(del));
                Context.SaveChanges();
                return "Deletado com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

      
        public List<MesaEntidade> ObterFiltros(Expression<Func<MesaEntidade, bool>> predicate)
        {
            return Context.Set<MesaEntidade>().Where(predicate).ToList();
        }

       

        public List<MesaEntidade> ObterTodos(bool includes = false)
        {
            var query = Context.Set<MesaEntidade>().AsQueryable();
            
            return query.ToList();
        }

        public MesaEntidade Primeiro(Expression<Func<MesaEntidade, bool>> predicate)
        {
            return Context.Set<MesaEntidade>().Where(predicate).FirstOrDefault();
        }

        public MesaEntidade Procurar(params object[] key)
        {
            return Context.Set<MesaEntidade>().Find(key);
        }
    }
}
