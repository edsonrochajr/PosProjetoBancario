using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ProjetoBancario.Modelo.Repositorio;
using ProjetoBancario.Modelo.Servico;

namespace ProjetoBancario.Modelo.Teste
{
    [TestFixture]
    public class ClienteTestes
    {
        [Test]
        public void SolicitarAberturaDeContaPessoaFisica()
        {
            RepositorioAgencia.Limpa();
            RepositorioAgencia.Criar(125, "ag 125", 1, "banco");
            Assert.IsNotNull(ServicoCliente.CadastrarPessoaFisica("Edson", "Edson@edson.com", "21", "1234-5678", "21", "9876-5432", "1234567890", "55889966", "M", new DateTime(1985, 10, 3), "AV", "Americas", 3000, "", "Barra da Tijuca", "Rio de Janeiro", "RJ", "22640102", 4999, 125));
        }

        [Test]
        public void SolicitarAberturaDeContaPessoaFisicaNaoAceitaMenorDeIdade()
        {
            RepositorioAgencia.Limpa();
            RepositorioAgencia.Criar(125, "ag 125", 1, "banco");
            Assert.Throws<InvalidOperationException>(() => ServicoCliente.CadastrarPessoaFisica("Edson", "Edson@edson.com", "21", "1234-5678", "21", "9876-5432", "1234567890", "55889966", "M", new DateTime(2000, 10, 3), "AV", "Americas", 3000, "", "Barra da Tijuca", "Rio de Janeiro", "RJ", "22640102", 4999, 125));
        }





    }
}