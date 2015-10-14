using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using WebServiceKitap.DB.Entidades;
using WebServiceKitap.DB.Repositorios.Interfaces;

namespace WebServiceKitap.DB.Repositorios
{
    public class RepositorioCategoriasDB : IRepositorioCategorias, IDisposable
    {
        private KitapContextDB _KitapDB;

        public RepositorioCategoriasDB()
        {
            _KitapDB = new KitapContextDB();
        }

        public async Task<List<Categoria>> CategoriasAll()
        {
            List<Categoria> categorias = await _KitapDB.Categorias.ToListAsync();
            return categorias;
        }

        public void Dispose()
        {
            _KitapDB.Dispose();
        }
    }
}
