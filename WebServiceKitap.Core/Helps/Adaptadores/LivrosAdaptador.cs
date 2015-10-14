using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceKitap.Core.ViewModels;
using WebServiceKitap.DB.Entidades;

namespace WebServiceKitap.Core.Helps.Adaptadores
{
    public class LivroEntidadeAdaptador
    {
        private Livro _Livro;

        public LivroEntidadeAdaptador(LivroModel livroModel)
        {

        }

        private bool Validar(LivroModel livro)
        {
            return false;
        }

        public Livro GetLivroEntatidade()
        {
            return _Livro;
        }
    }

    public class LivroModelViewAdaptador
    {
        private LivroModel _LivroModel;

        public LivroModelViewAdaptador(Livro livro)
        {

        }

        public LivroModel GetLivroModel()
        {
            return _LivroModel;
        }
    }
}
