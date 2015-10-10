using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceKitap.Core.Helps
{
    public class MensagemResposta
    {
        public string Nome { get; set; }
        public string Mensagem { get; set; }

        public MensagemResposta() { }

        public MensagemResposta(string nome, string mensagem) {
            this.Nome = nome;
            this.Mensagem = mensagem; }
    }
}
