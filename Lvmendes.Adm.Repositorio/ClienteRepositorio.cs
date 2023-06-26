using Lvmendes.Adm.Entidade;
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

    public class ClienteRepositorio : IClienteRepositorio
    {
        internal AdmContext Context;
        public ClienteRepositorio(AdmContext context)
        {
            Context = context;
        }
        public string Adicionar(ClienteEntidade entity)
        {

            try
            {
                Context.Set<ClienteEntidade>().Add(entity);
                Context.SaveChanges();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Atualizar(ClienteEntidade entity)
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


        public string Deletar(Func<ClienteEntidade, bool> predicate)
        {
            try
            {
                Context.Set<ClienteEntidade>()
          .Where(predicate).ToList()
          .ForEach(del => Context.Set<ClienteEntidade>().Remove(del));
                Context.SaveChanges();
                return "Deletado com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

 

        public List<ClienteEntidade> ObterFiltros(Expression<Func<ClienteEntidade, bool>> predicate)
        {
            return Context.Set<ClienteEntidade>().Where(predicate).ToList();
        }

  
        public List<ClienteEntidade> ObterTodos(bool includes = false)
        {
            var query = Context.Set<ClienteEntidade>().AsQueryable();
            
            return query.ToList();
        }

        public ClienteEntidade Primeiro(Expression<Func<ClienteEntidade, bool>> predicate)
        {
            return Context.Set<ClienteEntidade>().Where(predicate).FirstOrDefault();
        }

        public ClienteEntidade Procurar(params object[] key)
        {
            return Context.Set<ClienteEntidade>().Find(key);
        }
    }
}
