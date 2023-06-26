
using Lvmendes.Adms.Entidade;
using Lvmendes.Adms.Repositorio.Interfaces;
using Lvmendes.Adms.Servico.Interfaces;
using Microsoft.AspNetCore.Http;
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
    public class CardapioServico : ICardapioServico
    {

        private ICardapioRepositorio AdmRepositorio;
        private IEmpresaRepositorio EmpresaRepositorio;
        public CardapioServico(IEmpresaRepositorio _empresaRepositorio, ICardapioRepositorio _AdmRepositorio)
        {
            EmpresaRepositorio = _empresaRepositorio;
               AdmRepositorio = _AdmRepositorio;
        }
        public string Adicionar(CardapioEntidade entity)
        {
            if (!ValidaImagem(entity.FormFile))
                return "Tipo Invalido";

            var nomeArquivo =  Guid.NewGuid() + "." + entity.FormFile.ContentType.Split("/")[1];
            entity.Imagem = entity.Imagem+ "\\Produto\\" + entity.Empresa.Id;

            if (!Directory.Exists(entity.Imagem))
            {
                Directory.CreateDirectory(entity.Imagem);
            }

            using (var stream = System.IO.File.Create(entity.Imagem + "\\" + nomeArquivo))
            {
                entity.FormFile.CopyToAsync(stream);
            }

            entity.Imagem = nomeArquivo;

            entity.Empresa = EmpresaRepositorio.Procurar(entity.Empresa.Id);

            return AdmRepositorio.Adicionar(entity);
        }
        public bool ValidaImagem(IFormFile anexo)
        {
            switch (anexo.ContentType)
            {
                case "image/jpeg":
                    return true;
                case "image/bmp":
                    return true;
                case "image/gif":
                    return true;
                case "image/png":
                    return true;
                default:
                    return false;
                    break;
            }
        }
        public string Atualizar(CardapioEntidade entity)
        {
            return AdmRepositorio.Atualizar(entity);
        }

       
        public string Deletar(Func<CardapioEntidade, bool> predicate)
        {
            return AdmRepositorio.Deletar(predicate);
        }

        public List<CardapioEntidade> ListaPorEmpresa(long EmpresaId)
        {
            return AdmRepositorio.ListaPorEmpresa(EmpresaId);
        }

        public List<CardapioEntidade> ListaPorEmpresaEDiaSemana(long EmpresaId, SemanaEnum diaSemana)
        {
            return AdmRepositorio.ListaPorEmpresaEDiaSemana(EmpresaId, diaSemana);
        }

        public List<CardapioEntidade> ObterFiltros(Expression<Func<CardapioEntidade, bool>> predicate)
        {
            return AdmRepositorio.ObterFiltros(predicate);
        }

      
        public List<CardapioEntidade> ObterTodos(bool includes)
        {
            return AdmRepositorio.ObterTodos(includes);
        }

        public CardapioEntidade Primeiro(Expression<Func<CardapioEntidade, bool>> predicate)
        {
            return AdmRepositorio.Primeiro(predicate);
        }

        public CardapioEntidade Procurar(params object[] key)
        {
            return AdmRepositorio.Procurar(key);
        }
    }
}
