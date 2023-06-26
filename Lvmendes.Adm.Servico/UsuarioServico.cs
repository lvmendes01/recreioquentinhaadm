
using Lvmendes.Adms.Entidade;
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
    //public class AdmsServico : ComumServico<AdmEntidade>, IAdmsServico
    //{
    //    protected AdmsServico(IComumRepositorio<AdmEntidade> repositorio) : base(repositorio)
    //    {
    //    }
    //}
    public class UsuarioServico : IUsuarioServico
    {

        private IUsuarioRepositorio AdmRepositorio;
        private IPerfilRepositorio PerfilRepositorio;
        private IEmpresaRepositorio EmpresaRepositorio;
        public UsuarioServico(IPerfilRepositorio perfilRepositorio, IEmpresaRepositorio empresaRepositorio, IUsuarioRepositorio _AdmRepositorio)
        {
            AdmRepositorio = _AdmRepositorio;
            PerfilRepositorio = perfilRepositorio;
            EmpresaRepositorio = empresaRepositorio;
        }
        public string Adicionar(UsuarioEntidade entity)
        {

            var perfil = PerfilRepositorio.Primeiro(s => s.Id == entity.Perfil.Id);
            if (perfil == null)
            {
                return "Perfil errado";
            }
            entity.Perfil = perfil;

            var empresa = EmpresaRepositorio.Primeiro(s => s.Id == entity.Empresa.Id);
            if (empresa == null)
            {
                return "Empresa errado";
            }
            entity.Empresa = empresa;

            return AdmRepositorio.Adicionar(entity);
        }

        public string Atualizar(UsuarioEntidade entity)
        {
            return AdmRepositorio.Atualizar(entity);
        }

       
        public string Deletar(Func<UsuarioEntidade, bool> predicate)
        {
            return AdmRepositorio.Deletar(predicate);
        }

        public UsuarioEntidade Login(string login, string senha)
        {
            return AdmRepositorio.Login(login, senha);
        }

        public List<UsuarioEntidade> ObterFiltros(Expression<Func<UsuarioEntidade, bool>> predicate)
        {
            return AdmRepositorio.ObterFiltros(predicate);
        }

      
        public List<UsuarioEntidade> ObterTodos(bool includes)
        {
            return AdmRepositorio.ObterTodos(includes);
        }

        public UsuarioEntidade Primeiro(Expression<Func<UsuarioEntidade, bool>> predicate)
        {
            return AdmRepositorio.Primeiro(predicate);
        }

        public UsuarioEntidade Procurar(params object[] key)
        {
            return AdmRepositorio.Procurar(key);
        }
    }
}
