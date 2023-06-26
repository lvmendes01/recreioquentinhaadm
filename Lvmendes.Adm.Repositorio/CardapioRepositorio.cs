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

    public class CardapioRepositorio : ICardapioRepositorio
    {
        internal AdmContext Context;
        public CardapioRepositorio(AdmContext context)
        {
            Context = context;
        }
        public string Adicionar(CardapioEntidade entity)
        {

            try
            {
                Context.Set<CardapioEntidade>().Add(entity);
                Context.SaveChanges();
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Atualizar(CardapioEntidade entity)
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


        public string Deletar(Func<CardapioEntidade, bool> predicate)
        {
            try
            {
                Context.Set<CardapioEntidade>()
          .Where(predicate).ToList()
          .ForEach(del => Context.Set<CardapioEntidade>().Remove(del));
                Context.SaveChanges();
                return "Deletado com sucesso!!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

      

        public List<CardapioEntidade> ListaPorEmpresa(long EmpresaId)
        {
            return Context.Set<CardapioEntidade>()
      .Where(s => s.Empresa.Id == EmpresaId).ToList();
           
        }

        public List<CardapioEntidade> ListaPorEmpresaEDiaSemana(long EmpresaId, SemanaEnum diaSemana)
        {
            return Context.Set<CardapioEntidade>()
  .Where(s => s.Empresa.Id == EmpresaId && s.DiaSemana == diaSemana).ToList();
        }

        public List<CardapioEntidade> ObterFiltros(Expression<Func<CardapioEntidade, bool>> predicate)
        {
            return Context.Set<CardapioEntidade>().Where(predicate).ToList();
        }

     
        public List<CardapioEntidade> ObterTodos(bool includes = false)
        {
            var query = Context.Set<CardapioEntidade>().Include(s => s.Empresa);

            return query.ToList();
        }

        public CardapioEntidade Primeiro(Expression<Func<CardapioEntidade, bool>> predicate)
        {
            return Context.Set<CardapioEntidade>().Where(predicate).FirstOrDefault();
        }

        public CardapioEntidade Procurar(params object[] key)
        {
            return Context.Set<CardapioEntidade>().Find(key);
        }
    }
}
