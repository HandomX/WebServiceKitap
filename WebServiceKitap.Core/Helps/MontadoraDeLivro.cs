using WebServiceKitap.Core.ViewModels;
using WebServiceKitap.DB.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceKitap.Core.Helps
{
    public class MontadoraDeLivro
    {
        public LivroModel MontarModeloLivroModel(Livro livro)
        {
            var livroModel = new LivroModel();

            livroModel.Titulo = livro.Titulo;
            livroModel.Autores = livro.Autores.Split(',');
            livroModel.Isbn = livro.Isbn.Split(',');
            livroModel.NumeroDePaginas = livro.NumeroDePaginas;
            livroModel.Status = livro.Status;
            livroModel.Editora = livro.Editora;
            livroModel.Descricao = livro.Descricao;

            var categoriaModel = new CategoriaModel();
            categoriaModel.Id = livro.Categoria.Id;
            categoriaModel.Nome = livro.Categoria.Nome;
            
            livroModel.Categoria = categoriaModel;

            return livroModel;
        }

        public Livro MontarEntidadeLivro(LivroModel livroModel)
        {
            var livro = new Livro();
            livro.Titulo = livroModel.Titulo;
            livro.Autores = String.Join(",", livroModel.Autores);
            livro.Isbn = String.Join(",", livroModel.Isbn);
            livro.NumeroDePaginas = livroModel.NumeroDePaginas;
            livro.Status = livroModel.Status;
            livro.Editora = livroModel.Editora;
            livro.Descricao = livroModel.Descricao;
            livro.CategoriaID = livroModel.Categoria.Id;

            return livro;
        }
    }
}
