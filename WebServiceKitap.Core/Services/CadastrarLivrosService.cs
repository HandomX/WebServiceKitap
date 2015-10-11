using WebServiceKitap.Core.Helps;
using WebServiceKitap.Core.ViewModels;
using WebServiceKitap.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceKitap.Core.Services
{
    public class CadastrarLivrosService
    {
        private KitapContextDB _KitapDB;

        public CadastrarLivrosService()
        {
            _KitapDB = new KitapContextDB();
        }

        public async Task<LivroModel> Cadastrar(LivroModel livroModel)
        {
            if (!VerificarISBN(livroModel))
            {
                var mensagemError = new MensagemResposta("error", "ISBN enviado está invalido.");
                throw new DadosIvalidoException(mensagemError);
            }
                
            await VerificarExistenciaDoLivro(livroModel.Isbn);
            
            var livro = new MontadoraDeLivro().MontarEntidadeLivro(livroModel);
            _KitapDB.Livros.Add(livro);
            await _KitapDB.SaveChangesAsync();

            return livroModel;
        }

        private async Task VerificarExistenciaDoLivro(string[] isbn)
        {
            var serviceBuscarLivro = new BuscarLivrosService();
            var livro = await serviceBuscarLivro.PesquisarPorISBN(isbn[0]);
            livro = await serviceBuscarLivro.PesquisarPorISBN(isbn[1]);
            if (livro.Titulo == null)
            {
                var mensagemError = new MensagemResposta("error", "Este Livro já está cadastrado.");
                throw new DadosIvalidoException(mensagemError);
            }
        }

        private bool VerificarISBN(LivroModel livroModel)
        {
            ValidadorDeISBN validadorISBN = new ValidadorDeISBN();
            foreach(var isbn in livroModel.Isbn)
            {
                validadorISBN.AddISBN(isbn);
            }

            return validadorISBN.Validar();
        }
    }
}
