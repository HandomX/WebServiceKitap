using WebServiceKitap.Core.Helps;
using WebServiceKitap.Core.Services;
using WebServiceKitap.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebServiceKitap.WebApi.Controllers
{
    [RoutePrefix("api/")]
    public class LivrosController : ApiController
    {
        
        public async Task<HttpResponseMessage> GetTodosLivros()
        {
            var serviceBuscaDeLivros = new BuscarLivrosService();
            var livros = await serviceBuscaDeLivros.PesquisarTodos();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, livros);
            return response;
        }

        
        public async Task<HttpResponseMessage> GetLivroPorISBN(string isbn)
        {
            var serviceBuscaDeLivros = new BuscarLivrosService();
            
            LivroModel livro = await serviceBuscaDeLivros.PesquisarPorISBN(isbn);
            if(livro.Titulo == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, new MensagemResposta("error", "Este livro nao existe."));
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, livro);
            return response;
                
        }

        
        public async Task<HttpResponseMessage> GetLivrosPorBuscaGenerica(string query)
        {
            var serviceBuscaDeLivros = new BuscarLivrosService();
            var livros = new List<LivroModel>();

            var livrosPorEditora = await serviceBuscaDeLivros.PesquisarPorEditora(query);
            var livrosPorAutor = await serviceBuscaDeLivros.PesquisarPorAutor(query);
            var livrosPorTitulo = await serviceBuscaDeLivros.PesquisarPorTitulo(query);

            var livroPorISBN = await serviceBuscaDeLivros.PesquisarPorISBN(query);
            livros.AddRange(livrosPorEditora);
            livros.AddRange(livrosPorAutor);
            livros.AddRange(livrosPorTitulo);
            if(livroPorISBN.Titulo != null)
                livros.Add(livroPorISBN);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, livros);
            return response;
        }

        public async Task<HttpResponseMessage> PostLivroCadastro(LivroModel livro)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    var mensagemError = new MensagemResposta("error", "Dados Incompletos. Porfavor preencha os campos requeridos.");
                    throw new DadosIvalidoException(mensagemError);
                }
                    
                
                var serviceCadastroDeLivros = new CadastrarLivrosService();
                await serviceCadastroDeLivros.Cadastrar(livro);
            } 
            catch(DadosIvalidoException e)
            {

                var resp = Request.CreateResponse(HttpStatusCode.BadRequest, e.ExceptionMessage);

                throw new HttpResponseException(resp);
            }
                
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, livro);
            return response;
                       
        }
    }

    
}
