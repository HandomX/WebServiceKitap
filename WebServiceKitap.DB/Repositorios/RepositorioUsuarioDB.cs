using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceKitap.DB.Entidades;

namespace WebServiceKitap.DB.Repositorios
{
    public class RepositorioUsuarioDB : IDisposable
    {
        private KitapContextDB _KitapDB;
        private UserManager<Usuario> _UserManager;
        public RepositorioUsuarioDB()
        {
            _KitapDB = new KitapContextDB();
            _UserManager = new UserManager<Usuario>(new UserStore<Usuario>(_KitapDB));
        }

        public async Task<IdentityResult> CadastrarUsuario(Usuario usuario, string password)
        {
            var result = await _UserManager.CreateAsync(usuario, password);

            return result;
        }

        public async Task<Usuario> BuscarUsuario(string userName, string password)
        {
            Usuario user = await _UserManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _KitapDB.Dispose();
            _UserManager.Dispose();
        }
    }
}
