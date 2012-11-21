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
    public class SaqueTestes
    {
        //[Test]
        //public void testar_saque()
        //{
        //    ContaCorrente conta = new ContaCorrente();
        //    conta.Credita(1000);
        //    conta.Numero = 123;

        //    Saque saque = new Saque(conta, 500);
        //    saque.Executa();
            
        //    Comprovante comprovante = saque.Comprovante;

        //    RepositorioSaque.Adicionar(saque);

        //    Assert.Contains(saque, RepositorioSaque.Listar());
        //}

        //[Test]
        //public void testar_saque_transacoesBancarias()
        //{
        //    ContaCorrente conta = new ContaCorrente();
        //    conta.Credita(1000);
        //    conta.Numero = 123;

        //    TransacaoBancaria saque = new Saque(conta, 500);
        //    saque.Executa();

        //    Comprovante comprovante = saque.Comprovante;

        //    RepositorioTransacaoBancaria.Adicionar(saque);

        //    Assert.Contains(saque, RepositorioTransacaoBancaria.Listar());

        //    Saque recuperado = RepositorioTransacaoBancaria.Listar().Cast<Saque>().FirstOrDefault();
            
        //    List<Saque> saques = RepositorioTransacaoBancaria.Listar()
        //        .Where(t => t.GetType().Name == typeof(Saque).Name)
        //        .Cast<Saque>()
        //        .ToList();


        //    Assert.AreEqual(saque, recuperado);

        //}

        [Test]
        public void testar_saque_transacoesBancarias1()
        {
            RepositorioTransacaoBancaria.Limpar();
            ContaCorrente conta = new ContaCorrente();
            conta.Credita(1000);
            conta.Numero = 123;

            ServicoSaque servicoSaque = new ServicoSaque(conta, 500);
            Assert.AreEqual(1, RepositorioTransacaoBancaria.Listar().Count);

            Assert.IsNotNull(RepositorioTransacaoBancaria.Listar().Cast<Saque>().FirstOrDefault());
        }
    }
}