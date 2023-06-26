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
    public class ComumServico<T> : IComumServico<T>, IDisposable where T : class
    {
        private IComumRepositorio<T> _repositorio;
        protected ComumServico(IComumRepositorio<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public string Adicionar(T entity)
        {
            return _repositorio.Adicionar(entity);
        }

        public string Atualizar(T entity)
        {
            return _repositorio.Atualizar(entity);
        }

        public string Deletar(Func<T, bool> predicate)
        {
            return _repositorio.Deletar(predicate);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<T> ObterFiltros(Expression<Func<T, bool>> predicate)
        {
            return _repositorio.ObterFiltros(predicate);
        }

        public List<T> ObterTodos(bool includes)
        {
            return _repositorio.ObterTodos();        
        }

        public T Primeiro(Expression<Func<T, bool>> predicate)
        {
            return _repositorio.Primeiro(predicate);
        }

        public T Procurar(params object[] key)
        {
            return _repositorio.Procurar(key);
        }
    }
}