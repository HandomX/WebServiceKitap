using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceKitap.Core.Helps.Exceptions;
using WebServiceKitap.Core.ViewModels;
using WebServiceKitap.DB.Entidades;

namespace WebServiceKitap.Core.Helps.Adaptadores
{
    public class LivroEntidadeAdaptador
    {
        private Livro _Livro;
        private LivroModel _LivroModel;

        public LivroEntidadeAdaptador(LivroModel livroModel)
        {
            _Livro = new Livro();
            if (livroModel == null)
                throw new ArgumentNullException();
            _LivroModel = livroModel;
        }
        
        public Livro GetLivroEntidade()
        {
            if (ValidarInformations())
                return MontarLivroEntidade();

            var msg = new MensagemResposta("error", "Dados Invalidos.");
            throw new DadosInvalidosException(msg);
        }

        private Livro MontarLivroEntidade()
        {
            _Livro.Titulo = _LivroModel.Titulo;
            _Livro.Autores = String.Join(",", _LivroModel.Autores);
            _Livro.Isbn = String.Join(",", _LivroModel.Isbn);
            _Livro.NumeroDePaginas = _LivroModel.NumeroDePaginas;
            _Livro.Status = _LivroModel.Status;
            _Livro.Editora = _LivroModel.Editora;
            _Livro.Descricao = _LivroModel.Descricao;
            _Livro.CategoriaID = _LivroModel.Categoria.Id;

            return _Livro;
        }

        private bool ValidarInformations()
        {
            var valido = true;
            if (_LivroModel.Titulo == null || _LivroModel.Titulo == "")
                valido = false;
            if (_LivroModel.Autores == null || _LivroModel.Autores.Count() == 0)
                valido = false;
            if (_LivroModel.Editora == null || _LivroModel.Editora == "")
                valido = false;
            if (_LivroModel.NumeroDePaginas <= 0)
                valido = false;
            if (_LivroModel.AnoDePublicacao > DateTime.Now.Year)
                valido = false;

            valido = ValidarISBN();

            return valido;
        }

        private bool ValidarISBN()
        {
            ValidadorDeISBN validadorIsbn = new ValidadorDeISBN();

            foreach (var isbn in _LivroModel.Isbn)
                validadorIsbn.AddISBN(isbn);

            return validadorIsbn.Validar();

        }
    }

    public class LivroModelViewAdaptador
    {
        private LivroModel _LivroModel;
        private Livro _Livro;

        public LivroModelViewAdaptador(Livro livro)
        {
            _LivroModel = new LivroModel();
            if (livro == null)
                throw new ArgumentNullException();
            _Livro = livro;
            
        }

        public LivroModel MontarLivroView()
        {
            

            _LivroModel.Titulo = _Livro.Titulo;
            _LivroModel.Autores = _Livro.Autores.Split(',');
            _LivroModel.Isbn = _Livro.Isbn.Split(',');
            _LivroModel.NumeroDePaginas = _Livro.NumeroDePaginas;
            _LivroModel.Status = _Livro.Status;
            _LivroModel.Editora = _Livro.Editora;
            _LivroModel.Descricao = _Livro.Descricao;

            var categoriaModel = new CategoriaModel();
            categoriaModel.Id = _Livro.Categoria.Id;
            categoriaModel.Nome = _Livro.Categoria.Nome;

            _LivroModel.Categoria = categoriaModel;

            return _LivroModel;
        }

        public LivroModel GetLivroModel()
        {
            return _LivroModel;
        }
    }
}
