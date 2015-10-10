using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebServiceKitap.Core.Helps;

namespace WebServiceKitap.Core.Tests
{
    /*
        - Testar Se Ao Adicionar um isbn qualquer ele consta na lista
        - Testar Se 1 ISBN adicionado tem so digitos
        - Testar Se 1 ISBN adicionado e igual a 10 digitos
        - Testar Se 1 ISBN adicionado e igual a 13 digitos
        - Testar Se 1 ISBN de 10 digitos adicionado e valido
        - Testar Se 1 ISBN de 13 digitos adicionado e valido
        - Testar se 1 ISBN de 10 e 1 ISBN de 13 digitos adicionados sao validos
        - Testar se 1 ISBN de 10 valido e 1 ISBN 13 invalido adicionados sao invalidos
        */
    [TestClass]
    public class ISBNValidadorTeste
    {
        
        
        [TestMethod]
        public void Ao_Adicionar_Um_Isbn_Qualquer_Ele_Deve_Constar_Na_Lista_Do_Validador()
        {
            string isbn = "232546465546";

            ValidadorDeISBN validadorISBN = new ValidadorDeISBN();
            
            validadorISBN.AddISBN(isbn);

            Assert.IsTrue(validadorISBN.GetListaISBN().Contains(isbn));
        }

        [TestMethod]
        public void Ao_Adicionar_Um_Isbn_Verificar_Se_Ele_Contem_So_Numeros()
        {
            string isbn = "853630561a";

            ValidadorDeISBN validadorISBN = new ValidadorDeISBN();

            validadorISBN.AddISBN(isbn);

            Assert.IsFalse(validadorISBN.Validar());
        }

        [TestMethod]
        public void Ao_Adicionar_Um_Isbn_Menor_Que_10_Digitos_Eh_Invalido()
        {
            string isbn = "32563667";

            ValidadorDeISBN validadorISBN = new ValidadorDeISBN();

            validadorISBN.AddISBN(isbn);

            Assert.IsFalse(validadorISBN.Validar());
        }

        [TestMethod]
        public void Ao_Adicionar_Um_Isbn_Maior_Que_13_Digitos_Eh_Invalido()
        {
            string isbn = "86765678904325";

            ValidadorDeISBN validadorISBN = new ValidadorDeISBN();

            validadorISBN.AddISBN(isbn);

            Assert.IsFalse(validadorISBN.Validar());
        }

        [TestMethod]
        public void Ao_Adicionar_Um_Isbn_De_10_Digito_Calcular_Digito_Verificador()
        {
            string isbn = "1234443267";

            ValidadorDeISBN validadorISBN = new ValidadorDeISBN();

            validadorISBN.AddISBN(isbn);

            Assert.IsFalse(validadorISBN.Validar());
        }

        [TestMethod]
        public void Ao_Adicionar_Um_Isbn_De_13_Digito_Calcular_Digito_Verificador()
        {
            string isbn = "9788577803064";

            ValidadorDeISBN validadorISBN = new ValidadorDeISBN();

            validadorISBN.AddISBN(isbn);

            Assert.IsTrue(validadorISBN.Validar());
        }

        [TestMethod]
        public void Ao_Adicionar_Um_Isbn_De_10_Valido_Eh_Um_Isbn_De_13_Invalido()
        {
            ValidadorDeISBN validadorIsbn = new ValidadorDeISBN();
            validadorIsbn.AddISBN("8577803066");
            validadorIsbn.AddISBN("9788577803066");

            Assert.IsFalse(validadorIsbn.Validar());
        }

        [TestMethod]
        public void Ao_Adicionar_Dois_Isbn_Vazio_Eh_Invalido()
        {
            ValidadorDeISBN validadorIsbn = new ValidadorDeISBN();
            validadorIsbn.AddISBN("");
            validadorIsbn.AddISBN("");

            Assert.IsFalse(validadorIsbn.Validar());
        }

    }
}
