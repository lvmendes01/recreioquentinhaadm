using Lvmendes.Adms.Entidade;
using Lvmendes.Adms.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.Adm.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        internal AdmContext Context;
        public UsuarioRepositorio(AdmContext context)
        {
            Context = context;
        }
        public string Adicionar(UsuarioEntidade entity)
        {
            try
            {
                Context.Set<UsuarioEntidade>().Add(entity);
                Context.SaveChanges();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Atualizar(UsuarioEntidade entity)
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

        public string Deletar(Func<UsuarioEntidade, bool> predicate)
        {
            try
            {
                Context.Set<UsuarioEntidade>()
          .Where(predicate).ToList()
          .ForEach(del => Context.Set<UsuarioEntidade>().Remove(del));
                Context.SaveChanges();
                return "Deletado com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public UsuarioEntidade Login(string usuario, string senha)
        {
            return Context.Set<UsuarioEntidade>()
                .Include(s => s.Empresa).Include(s => s.Perfil)
                .Where(s=>s.Login == usuario && s.Senha == senha).FirstOrDefault();
        }

        public List<UsuarioEntidade> ObterFiltros(Expression<Func<UsuarioEntidade, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioEntidade> ObterTodos(bool includes = false)
        {
            throw new NotImplementedException();
        }

        public UsuarioEntidade Primeiro(Expression<Func<UsuarioEntidade, bool>> predicate)
        {
            return Context.Set<UsuarioEntidade>().Where(predicate).FirstOrDefault();
        }

        public UsuarioEntidade Procurar(params object[] key)
        {
            throw new NotImplementedException();
        }
    }
}
