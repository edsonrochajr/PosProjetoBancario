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
    public class ContaCorrenteTestes
    {
        [Test]
        public void EmitirExtratos()
        {
            RepositorioTransacaoBancaria.Limpar();
            ContaCorrente conta = new ContaCorrente();
            conta.Numero = 123;
            RepositorioTransacaoBancaria.Adicionar(new Deposito(conta, 10000));
            RepositorioTransacaoBancaria.Adicionar(new Saque(conta, 500));
            RepositorioTransacaoBancaria.Adicionar(new Saque(conta, 500));
            Assert.AreEqual(3, RepositorioTransacaoBancaria.EmiteExtrato(conta, 20).Count());
        }
    }
}