using WebServiceKitap.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using WebServiceKitap.DB.Entidades;
using WebServiceKitap.Core.ViewModels;
using WebServiceKitap.Core.Helps;
using WebServiceKitap.DB.Repositorios.Interfaces;
using WebServiceKitap.DB.Repositorios;
using WebServiceKitap.Core.Helps.Adaptadores;
using WebServiceKitap.Core.Helps.Exceptions;

namespace WebServiceKitap.Core.Services
{
    public class BuscarLivrosService
    {
        private IRepositorioLivros _RepositorioLivros;
        private KitapContextDB _KitapDB;
        private MontadoraDeLivro _MontadorDeLivrosModels;
        public BuscarLivrosService()
        {
            _RepositorioLivros = new RepositorioLivrosDB();
            _KitapDB = new KitapContextDB();
            _MontadorDeLivrosModels = new MontadoraDeLivro();
        }

        public async Task<List<LivroModel>> PesquisarTodos()
        {
            var livros = await _RepositorioLivros.LivrosAll();
            var livroModels = new List<LivroModel>();

            foreach(var livro in livros)
            {
               var livroModelAux = _MontadorDeLivrosModels.MontarModeloLivroModel(livro);
               livroModels.Add(livroModelAux);
            }

            return livroModels;
        }

        public async Task<LivroModel> PesquisarPorISBN(string isbn)
        {
            if (_RepositorioLivros.LivroExiste(isbn))
            {
                var livro = (await _RepositorioLivros.LivrosAll()).Where(l => l.Isbn == isbn).First<Livro>();
                var livroModel = new LivroModelViewAdaptador(livro).GetLivroModel();

                return livroModel;
            }
            else
            {
                var msg = new MensagemResposta("error", "Livro não encontrado.");
                
                throw new LivroNaoExisteException(msg);
            }

        }

        public async Task<List<LivroModel>> PesquisarPorAutor(string autor)
        {
            var livros = (await _RepositorioLivros.LivrosAll()).Where(l => l.Autores.Contains(autor));
            var livroModels = new List<LivroModel>();

            foreach (var livro in livros)
            {
                var livroModelAux = _MontadorDeLivrosModels.MontarModeloLivroModel(livro);
                livroModels.Add(livroModelAux);
            }

            return livroModels;
        }

        public async Task<List<LivroModel>> PesquisarPorTitulo(string titulo)
        {
            var livros = (await _RepositorioLivros.LivrosAll()).Where(l => l.Titulo.Contains(titulo));
            var livroModels = new List<LivroModel>();

            foreach (var livro in livros)
            {
                var livroModelAux = _MontadorDeLivrosModels.MontarModeloLivroModel(livro);
                livroModels.Add(livroModelAux);
            }

            return livroModels;
        }

        public async Task<List<LivroModel>> PesquisarPorEditora(string editora)
        {
            var livros = (await _RepositorioLivros.LivrosAll()).Where(l => l.Editora.Contains(editora));
            var livroModels = new List<LivroModel>();

            foreach (var livro in livros)
            {
                var livroModelAux = _MontadorDeLivrosModels.MontarModeloLivroModel(livro);
                livroModels.Add(livroModelAux);
            }

            return livroModels;
        }

        
    }
}
