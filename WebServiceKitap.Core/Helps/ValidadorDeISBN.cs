using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebServiceKitap.Core.Helps
{
    public class ValidadorDeISBN
    {
        private List<string> ArrayDeISBN;
        
        public ValidadorDeISBN()
        {
            // TODO: Complete member initialization
            this.ArrayDeISBN = new List<string>();
            
        }

        public void AddISBN(string isbn)
        {
            if(!isbn.Equals("") && !isbn.Equals(null))
                this.ArrayDeISBN.Add(isbn);
        }

        public void AddISBN(List<string> listaDeIsbn)
        {
            this.ArrayDeISBN.AddRange(listaDeIsbn);
        }

        public List<String> GetListaISBN()
        {
            return this.ArrayDeISBN;
        }

        public bool Validar()
        {
            bool valido = true;

            if (ArrayDeISBN.Count == 0)
                return false;
            
            foreach(var isbn in ArrayDeISBN)
            {
                valido = (valido & VerificarContemSomenteNumero(isbn) & VerificarTipoEhCalculaDigitoVerificadorDoISBN(isbn));
            }
            return valido;
        }

        private bool VerificarContemSomenteNumero(string isbn)
        {
            string regex = @"^\d{10}$|^\d{13}$";

            return Regex.IsMatch(isbn, regex);
        }

        private bool VerificarTipoEhCalculaDigitoVerificadorDoISBN(string isbn)
        {
            if (isbn.Count() == 10)
                return this.CalcularDigitoVerificadorISBN10(isbn);

            else if (isbn.Count() == 13)
                return this.CalcularDigitoVerificadorISBN13(isbn);

            return false;
            
        }

        private bool CalcularDigitoVerificadorISBN10(string isbn)
        {

            int[] isbnNumerico = ConverteIsbnDeStringParaArrayDeInteiros(isbn);
            int totalDaSoma=0, digitoVerificador;

            for (int peso = 1; peso <= 9; peso++ )
            {
                totalDaSoma += (isbnNumerico[peso - 1] * peso);
            }

            digitoVerificador = totalDaSoma % 11;

            if (digitoVerificador == isbnNumerico[9])
                return true;
            
            return false;
        }

        private bool CalcularDigitoVerificadorISBN13(string isbn)
        {
            int[] isbnNumerico = ConverteIsbnDeStringParaArrayDeInteiros(isbn);
            int totalDaSoma = 0, digitoVerificador;

            for (int posicao = 1; posicao <= 12; posicao++ )
            {
                totalDaSoma += (posicao % 2 == 0) ? isbnNumerico[posicao - 1] * 3: isbnNumerico[posicao - 1];
            }

            digitoVerificador = 10 - (totalDaSoma % 10);

            if (digitoVerificador == isbnNumerico[12])
                return true;

            return false;
        }

        private int[] ConverteIsbnDeStringParaArrayDeInteiros(string isbn)
        {
            List<int> isbnNumerico = new List<int>();
            
            foreach(var valor in isbn)
            {
                int numero = Convert.ToInt32(Char.GetNumericValue(valor));
                isbnNumerico.Add(numero);
            }
            return isbnNumerico.ToArray();
        }





        
    }
}
