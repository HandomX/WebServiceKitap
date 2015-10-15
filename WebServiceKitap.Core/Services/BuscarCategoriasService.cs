using WebServiceKitap.Core.ViewModels;
using WebServiceKitap.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using WebServiceKitap.DB.Entidades;
using WebServiceKitap.DB.Repositorios.Interfaces;
using WebServiceKitap.DB.Repositorios;

namespace WebServiceKitap.Core.Services
{
    public class BuscarCategoriasService
    {
        private IRepositorioCategorias _RepositorioCategorias;

        public BuscarCategoriasService()
        {
            _RepositorioCategorias = new RepositorioCategoriasDB();
        }

        public async Task<List<CategoriaModel>> PesquisarCategorias()
        {
            var categorias = await _RepositorioCategorias.CategoriasAll();

            var categoriaModels = new List<CategoriaModel>();

            foreach(var categoria in categorias)
            {
                var categoriaAux = new CategoriaModel();
                categoriaAux.Id = categoria.Id;
                categoriaAux.Nome = categoria.Nome;
                categoriaModels.Add(categoriaAux);
            }

            return categoriaModels;
        }
    }
}
