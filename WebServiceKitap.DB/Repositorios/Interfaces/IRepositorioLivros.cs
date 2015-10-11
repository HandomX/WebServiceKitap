using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceKitap.DB.Entidades;

namespace WebServiceKitap.DB.Repositorios.Interfaces
{
    public interface IRepositorioLivros
    {
        Task<List<Livro>> LivrosAll();
        bool LivroExiste(string isbn);
        Task LivroAdd(Livro livro);

    }
}
