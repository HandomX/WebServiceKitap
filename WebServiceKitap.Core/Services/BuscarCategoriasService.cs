using WebServiceKitap.Core.ViewModels;
using WebServiceKitap.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using WebServiceKitap.DB.Entidades;

namespace WebServiceKitap.Core.Services
{
    public class BuscarCategoriasService
    {
        private KitapContextDB _KitapDB;

        public BuscarCategoriasService()
        {
            this._KitapDB = new KitapContextDB();
        }

        public async Task<List<CategoriaModel>> PesquisarCategorias()
        {
            var categorias = await _KitapDB.Categorias.ToListAsync();

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
