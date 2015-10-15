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
        
        public BuscarLivrosService()
        {
            _RepositorioLivros = new RepositorioLivrosDB();            
        }

        public async Task<List<LivroModel>> PesquisarTodos()
        {
            var livros = await _RepositorioLivros.LivrosAll();
            var livroModels = new List<LivroModel>();

            foreach (var livro in livros)
                livroModels.Add(MontarLivroView(livro));

            return livroModels;
        }

        public async Task<LivroModel> PesquisarPorISBN(string isbn)
        {
            if (_RepositorioLivros.LivroExiste(isbn))
            {
                var livro = (await _RepositorioLivros.LivrosAll()).Where(l => l.Isbn == isbn).First<Livro>();
                var livroModel = MontarLivroView(livro);

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
                livroModels.Add(MontarLivroView(livro));

            return livroModels;
        }

        public async Task<List<LivroModel>> PesquisarPorTitulo(string titulo)
        {
            var livros = (await _RepositorioLivros.LivrosAll()).Where(l => l.Titulo.Contains(titulo));
            var livroModels = new List<LivroModel>();

            foreach (var livro in livros)
                livroModels.Add(MontarLivroView(livro));
            

            return livroModels;
        }

        public async Task<List<LivroModel>> PesquisarPorEditora(string editora)
        {
            var livros = (await _RepositorioLivros.LivrosAll()).Where(l => l.Editora.Contains(editora));
            var livroModels = new List<LivroModel>();

            foreach (var livro in livros)
                livroModels.Add(MontarLivroView(livro));

            return livroModels;
        }

        private LivroModel MontarLivroView(Livro livro)
        {
            return new LivroModelViewAdaptador(livro).GetLivroModel();
        }
    }
}
