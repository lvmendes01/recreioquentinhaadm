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

    public class PedidoRepositorio : IPedidoRepositorio
    {
        internal AdmContext Context;
        public PedidoRepositorio(AdmContext context)
        {
            Context = context;
        }
        public string Adicionar(PedidoEntidade entity)
        {

            try
            {
                Context.Set<PedidoEntidade>().Add(entity);
                Context.SaveChanges();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Atualizar(PedidoEntidade entity)
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


        public string Deletar(Func<PedidoEntidade, bool> predicate)
        {
            try
            {
                Context.Set<PedidoEntidade>()
          .Where(predicate).ToList()
          .ForEach(del => Context.Set<PedidoEntidade>().Remove(del));
                Context.SaveChanges();
                return "Deletado com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

 

        public List<PedidoEntidade> ObterFiltros(Expression<Func<PedidoEntidade, bool>> predicate)
        {
            return Context.Set<PedidoEntidade>()
                .Include("Items.Produto.Empresa")
                .Include("Cliente")
                .Where(predicate).ToList();
        }

  
        public List<PedidoEntidade> ObterTodos(bool includes = false)
        {
            var query = Context.Set<PedidoEntidade>().AsQueryable();
            if (includes)
                query = query.Include("Items.Produto");


            return query.ToList();
        }

        public PedidoEntidade Primeiro(Expression<Func<PedidoEntidade, bool>> predicate)
        {
            return Context.Set<PedidoEntidade>()
                .Include("Items.Produto")
                .Include(s => s.Cliente)
                .Where(predicate).FirstOrDefault();
        }

        public PedidoEntidade Procurar(params object[] key)
        {
            return Context.Set<PedidoEntidade>().Find(key);
        }
    }
}
