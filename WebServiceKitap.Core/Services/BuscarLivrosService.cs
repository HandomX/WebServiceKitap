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

namespace WebServiceKitap.Core.Services
{
    public class BuscarLivrosService
    {
        private KitapContextDB _KitapDB;
        private MontadoraDeLivro _MontadorDeLivrosModels;
        public BuscarLivrosService()
        {
            _KitapDB = new KitapContextDB();
            _MontadorDeLivrosModels = new MontadoraDeLivro();
        }

        public async Task<List<LivroModel>> PesquisarTodos()
        {
            var livros = await _KitapDB.Livros.Include("Categoria").ToListAsync<Livro>();
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
            var livro = await _KitapDB.Livros.Include("Categoria").Where(l => l.Isbn == isbn).FirstOrDefaultAsync<Livro>();

            if (livro == null)
                return new LivroModel();

            var livroModel = new MontadoraDeLivro().MontarModeloLivroModel(livro);
            
            return livroModel;
        }

        public async Task<List<LivroModel>> PesquisarPorAutor(string autor)
        {
            var livros = await _KitapDB.Livros.Include("Categoria").Where(l => l.Autores.Contains(autor)).ToListAsync<Livro>();
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
            var livros = await _KitapDB.Livros.Include("Categoria").Where(l => l.Titulo.Contains(titulo)).ToListAsync<Livro>();
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
            var livros = await _KitapDB.Livros.Include("Categoria").Where(l => l.Editora.Contains(editora)).ToListAsync<Livro>();
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
