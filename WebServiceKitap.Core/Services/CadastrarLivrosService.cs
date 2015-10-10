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
            /*var mensagemError = new MensagemResposta("error", "");
            if (livroModel.Isbn.Length < 2)
            {
                mensagemError.Mensagem = "Porfavor Forneça ao menos um isbn valido.";
                throw new DadosIvalidoException(mensagemError);
            }
                

            ValidadorDeISBN isbn1Validar = new ValidadorDeISBN(livroModel.Isbn[0]);
            ValidadorDeISBN isbn2Validar = new ValidadorDeISBN(livroModel.Isbn[1]);
            if (isbn1Validar.Equals("") && isbn2Validar.Equals(""))
            {
                mensagemError.Mensagem = "Porfavor Forneça ao menos um isbn valido.";
                throw new DadosIvalidoException(mensagemError);
            }
                
            else if (!isbn1Validar.Equals("") && !isbn2Validar.Equals(""))
            {
                if (!isbn1Validar.Validar() && !isbn2Validar.Validar())
                {
                    mensagemError.Mensagem = "Um ou os Dois ISBNs podem está invalidos.";
                    throw new DadosIvalidoException(mensagemError);
                }
                else
                    return true;
            }

            return isbn1Validar.Validar() || isbn2Validar.Validar();;
            */
            return true;
        }
    }
}
