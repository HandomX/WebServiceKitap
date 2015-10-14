using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceKitap.DB.Entidades;
using WebServiceKitap.DB.Repositorios.Interfaces;

namespace WebServiceKitap.DB.Repositorios
{
    public class RepositorioLivrosDB : IRepositorioLivros, IDisposable
    {
        KitapContextDB _KitapDB;
        public RepositorioLivrosDB()
        {
            _KitapDB = new KitapContextDB();
        }
        public async Task LivroAdd(Livro livro)
        {
            _KitapDB.Livros.Add(livro);
            await _KitapDB.SaveChangesAsync();
        }

        public bool LivroExiste(string isbn)
        {
            var livro = _KitapDB.Livros.Where(l => l.Isbn == isbn);
            if (livro == null)
                return false;
            return true;
        }

        public async Task<List<Livro>> LivrosAll()
        {
            var livros = await _KitapDB.Livros.ToListAsync<Livro>();
            return livros;
        }

        public void Dispose()
        {
            _KitapDB.Dispose();
        }
    }
}
