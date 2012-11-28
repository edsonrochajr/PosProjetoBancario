using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ProjetoBancario.Modelo.Repositorio;
using ProjetoBancario.Modelo.Servico;


namespace ProjetoBancario.Modelo.Teste
{
    public class ExtratoTeste
    {

        [Test]
        public void Imprimir_Extrato()
        {

            ContaCorrente conta = new ContaCorrente();

            RepositorioTransacaoBancaria.Adicionar(new Deposito(conta, 1000));
            RepositorioTransacaoBancaria.Adicionar(new Saque(conta, 200));

            Extrato extrato = new Extrato(conta, DateTime.Now.AddDays(-1), DateTime.Now);

            extrato.Executa();

            Assert.AreEqual(2, extrato.TransacoesBancarias.Count());

        }


        [Test]
        public void Imprimir_Extrato_Conta_Inativa()
        {

            ContaCorrente conta = new ContaCorrente();
            RepositorioTransacaoBancaria.Adicionar(new Deposito(conta, 1000));
            RepositorioTransacaoBancaria.Adicionar(new Saque(conta, 200));
            ServicoConta.Bloquear(conta);

            Extrato extrato = new Extrato(conta, DateTime.Now.AddDays(-1), DateTime.Now);
            Assert.Throws<InvalidOperationException>(() => extrato.Executa());

            Assert.IsNotNull(extrato.Comprovante.Descricao);
        }




    }
}
