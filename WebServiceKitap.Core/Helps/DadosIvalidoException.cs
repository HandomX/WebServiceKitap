using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceKitap.Core.Helps
{
    public class DadosIvalidoException : Exception
    {
        private Object _ExceptionMessage;

        public Object ExceptionMessage { get { return _ExceptionMessage; } set { _ExceptionMessage = value; } }

        public DadosIvalidoException(Object mensagem)
        {
            ExceptionMessage = mensagem;
        }
    }
}
