using WebServiceKitap.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebServiceKitap.WebApi.Controllers
{
    public class CategoriasController : ApiController
    {
        public async Task<HttpResponseMessage> GetCategorias()
        {
            var serviceBuscaDeCategorias = new BuscarCategoriasService();
            var categorias = await serviceBuscaDeCategorias.PesquisarCategorias();
            
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, categorias);
            return response;
        }
    }
}
