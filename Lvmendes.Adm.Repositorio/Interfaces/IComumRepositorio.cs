using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lvmendes.Adms.Repositorio.Interfaces
{
    public interface IComumRepositorio<T> where T : class
    {
        List<T> ObterTodos(bool includes = false);
        List<T> ObterFiltros(Expression<Func<T, bool>> predicate);
        T Procurar(params object[] key);
        T Primeiro(Expression<Func<T, bool>> predicate);
        string Adicionar(T entity);
        string Atualizar(T entity);
        string Deletar(Func<T, bool> predicate);
    }
}
