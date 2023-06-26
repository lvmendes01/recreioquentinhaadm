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
    public  class ComumRepositorio<T> where T : class
    {
        internal AdmContext Context;
        internal DbSet<T> dbSet;
        public ComumRepositorio(AdmContext _context)
        {
            Context = _context;
            this.dbSet = _context.Set<T>();
        }
     
        public List<T> ObterTodos()
        {
            return Context.Set<T>().ToList();
        }

        public List<T> ObterFiltros(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public T Procurar(params object[] key)
        {
            return Context.Set<T>().Find(key);
        }
        public T Primeiro(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).FirstOrDefault();
        }
        public string Adicionar(T entity)
        {
            try
            {
                Context.Set<T>().Add(entity);
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public string Atualizar(T entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                return "Atualizar com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public string Deletar(Func<T, bool> predicate)
        {
            try
            {
                Context.Set<T>()
          .Where(predicate).ToList()
          .ForEach(del => Context.Set<T>().Remove(del));
                return "Deletado com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
        public void Commit()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
            GC.SuppressFinalize(this);
        }

     
    }
}