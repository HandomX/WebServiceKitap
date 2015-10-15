
using WebServiceKitap.Core.ViewModels;
using WebServiceKitap.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebServiceKitap.DB.Repositorios.Interfaces;
using WebServiceKitap.DB.Repositorios;
using WebServiceKitap.Core.Helps.Adaptadores;

namespace WebServiceKitap.Core.Services
{
    public class CadastrarLivrosService
    {
        private IRepositorioLivros _RepositorioLivros;
        private KitapContextDB _KitapDB;

        public CadastrarLivrosService()
        {
            _KitapDB = new KitapContextDB();
            _RepositorioLivros = new RepositorioLivrosDB();
        }

        public async Task<LivroModel> Cadastrar(LivroModel livroModel)
        {
            var livro = new LivroEntidadeAdaptador(livroModel).GetLivroEntidade();
            await _RepositorioLivros.LivroAdd(livro);

            return livroModel;
        }

    }
}
