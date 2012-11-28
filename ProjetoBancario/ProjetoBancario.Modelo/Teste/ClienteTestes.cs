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

            var cliente = (PessoaFisica) ServicoCliente.CadastrarPessoaFisica("Edson", "eddsss@gmail.com", "21", "1234-5678", "21", "9876-5432", "1234567890", "55889966", "M", new DateTime(1985, 10, 3), "AV", "Americas", 3000, "", "Barra da Tijuca", "Rio de Janeiro", "RJ", "22640102", 4999, 125);

            

            Assert.IsNotNull(cliente);

            Assert.AreEqual("Edson", cliente.Nome);
            Assert.AreEqual("eddsss@gmail.com", cliente.Email);

            Assert.IsNotNull(cliente.Endereco);

            Assert.AreEqual("AV", cliente.Endereco.TipoLogradouro);
            Assert.AreEqual("Americas", cliente.Endereco.Logradouro);
            Assert.AreEqual(3000, cliente.Endereco.Numero);
            Assert.AreEqual("", cliente.Endereco.Comp);
            Assert.AreEqual("Barra da Tijuca", cliente.Endereco.Bairro);
            Assert.AreEqual("Rio de Janeiro", cliente.Endereco.Cidade);
            Assert.AreEqual("RJ", cliente.Endereco.UF);
            Assert.AreEqual("22640102", cliente.Endereco.Cep);


            Assert.AreEqual("1234567890", cliente.Cpf);
            Assert.AreEqual("55889966", cliente.Rg);
            Assert.AreEqual("M", cliente.Sexo);
            Assert.AreEqual(new DateTime(1985, 10, 3), cliente.DataNascimento);

            var tel = cliente.Telefones.First();
            Assert.AreEqual("21", tel.DDD);
            Assert.AreEqual("1234-5678", tel.Numero);
            Assert.AreEqual("Residencial", tel.Tipo);

        }

        [Test]
        public void SolicitarAberturaDeContaMenorIdade()
        {
            RepositorioAgencia.Limpa();
            RepositorioAgencia.Criar(125, "ag 125", 1, "banco");
            Assert.Throws<InvalidOperationException>(() => ServicoCliente.CadastrarPessoaFisica("Edson", "eddsss@gmail.com", "21", "1234-5678", "21", "9876-5432", "1234567890", "55889966", "M", new DateTime(2005, 10, 3), "AV", "Americas", 3000, "", "Barra da Tijuca", "Rio de Janeiro", "RJ", "22640102", 4999, 125));
        }

        [Test]
        public void SolicitarAberturaDeContaEspecialPessoaFisica()
        {
            RepositorioAgencia.Limpa();
            RepositorioAgencia.Criar(125, "ag 125", 1, "banco");
            Assert.IsNotNull(ServicoCliente.CadastrarPessoaFisica("Edson", "eddsss@gmail.com", "21", "1234-5678", "21", "9876-5432", "1234567890", "55889966", "M", new DateTime(1985, 10, 3), "AV", "Americas", 3000, "", "Barra da Tijuca", "Rio de Janeiro", "RJ", "22640102", 5500, 125));
        }



        [Test]
        public void SolicitarAberturaDeContaPessoaFisica_SegundaConta()
        {
            RepositorioAgencia.Limpa();
            RepositorioContaCorrente.Limpa();
            RepositorioAgencia.Criar(125, "ag 125", 1, "banco");


            Assert.IsNotNull(ServicoCliente.CadastrarPessoaFisica("Edson", "eddsss@gmail.com", "21", "1234-5678", "21", "9876-5432", "1234567890", "55889966", "M", new DateTime(1985, 10, 3), "AV", "Americas", 3000, "", "Barra da Tijuca", "Rio de Janeiro", "RJ", "22640102", 4999, 125));
            var cliente2 = ServicoCliente.CadastrarPessoaFisica("Edson2", "eddsss@gmail.com", "21", "1234-5678", "21", "9876-5432", "1234567890", "55889966", "M", new DateTime(1985, 10, 3), "AV", "Americas2", 3000, "", "Barra da Tijuca2", "Rio de Janeiro", "RJ", "22640102", 4999, 125);

            var conta = RepositorioContaCorrente.Listar().Where(c => c.Cliente == cliente2).First();
            Assert.AreEqual(2, conta.Numero);

        }




        [Test]
        public void SolicitarAberturaDeContaPessoaJuridica()
        {
            RepositorioAgencia.Limpa();
            RepositorioAgencia.Criar(125, "ag 125", 1, "banco");

            var cliente = (PessoaJuridica)ServicoCliente.CadastrarPessoaJuridica("EMPRESA XPTO", "empresaxpto@gmail.com", "21", "1234-5678", "21", "9876-5432", "1234567890", "55889966", new DateTime(1985, 1, 1), "AV", "Americas", 3000, "", "Barra da Tijuca", "Rio de Janeiro", "RJ", "22640102", 4000, 125);

            Assert.AreEqual("1234567890", cliente.Cnpj);
            Assert.AreEqual(new DateTime(1985, 1, 1), cliente.DataFundacao);
            Assert.AreEqual("55889966", cliente.InscricaoEstadual);

            Assert.IsNotNull(cliente);

        }

        [Test]
        public void SolicitarAberturaDeContaPessoaJuridica_DataFundacao_Recente()
        {
            RepositorioAgencia.Limpa();
            RepositorioAgencia.Criar(125, "ag 125", 1, "banco");
            Assert.Throws<InvalidOperationException>(() => ServicoCliente.CadastrarPessoaJuridica("EMPRESA XPTO", "empresaxpto@gmail.com", "21", "1234-5678", "21", "9876-5432", "1234567890", "55889966", new DateTime(2010, 1, 1), "AV", "Americas", 3000, "", "Barra da Tijuca", "Rio de Janeiro", "RJ", "22640102", 4000, 125));
        }



        [Test]
        public void SolicitarAberturaDeContaPessoaEspecialJuridica()
        {
            RepositorioAgencia.Limpa();
            RepositorioAgencia.Criar(125, "ag 125", 1, "banco");
            Assert.IsNotNull(ServicoCliente.CadastrarPessoaJuridica("EMPRESA XPTO", "empresaxpto@gmail.com", "21", "1234-5678", "21", "9876-5432", "1234567890", "55889966", new DateTime(1985, 1, 1), "AV", "Americas", 3000, "", "Barra da Tijuca", "Rio de Janeiro", "RJ", "22640102", 5500, 125));
        }






    }
}