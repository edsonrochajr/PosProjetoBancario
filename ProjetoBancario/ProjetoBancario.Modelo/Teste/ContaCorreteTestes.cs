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
        public void CriarContaCorrente()
        {
            ContaCorrente conta = new ContaCorrente();
            conta.DataAbertura = DateTime.Now;
            Assert.IsNull(conta.Agencia);
            Assert.AreEqual(DateTime.Now, conta.DataAbertura);
            Assert.IsNull(conta.Cliente);

        }


        [Test]
        public void EmitirExtratos()
        {
            RepositorioTransacaoBancaria.Limpar();
            ContaCorrente conta = new ContaCorrente();

            RepositorioTransacaoBancaria.Adicionar(new Deposito(conta, 10000));
            RepositorioTransacaoBancaria.Adicionar(new Saque(conta, 500));
            RepositorioTransacaoBancaria.Adicionar(new Saque(conta, 500));
            Assert.AreEqual(3, RepositorioTransacaoBancaria.EmiteExtrato(conta, 20).Count());
        }


        [Test]
        public void Saque_transacoesBancarias()
        {
            RepositorioTransacaoBancaria.Limpar();
            ContaCorrente conta = new ContaCorrente();
            conta.Credita(1000);

            var saque = ServicoConta.ExecutarSaque(conta, 500);

            Assert.AreEqual(500, conta.Saldo);
            Assert.IsNotNull(saque.Comprovante);
        }


        [Test]
        public void Saque_transacoesBancarias_Saldo_Zerado()
        {
            RepositorioTransacaoBancaria.Limpar();
            ContaCorrente conta = new ContaCorrente();
            Assert.Throws<InvalidOperationException>(() => ServicoConta.ExecutarSaque(conta, 500));
        }

        [Test]
        public void Saque_transacoesBancarias_Conta_Bloqueada()
        {
            RepositorioTransacaoBancaria.Limpar();
            ContaCorrente conta = new ContaCorrente();
            ServicoConta.Bloquear(conta);
            Assert.Throws<InvalidOperationException>(() => ServicoConta.ExecutarSaque(conta, 500));
        }



        [Test]
        public void Deposito_transacoesBancarias()
        {
            RepositorioTransacaoBancaria.Limpar();
            ContaCorrente conta = new ContaCorrente();
            conta.Credita(1000);

            var d = ServicoConta.ExecutarDeposito(conta, 500);
            Assert.IsNotNull(d.Comprovante);
            Assert.AreEqual(1500, conta.Saldo);

        }


        [Test]
        public void Transferencia_transacoesBancarias()
        {
            RepositorioTransacaoBancaria.Limpar();
            ContaCorrente conta = new ContaCorrente();
            conta.Credita(1000);

            ContaCorrente contaDestino = new ContaCorrente();

            var transf = ServicoConta.ExecutarTransferencia(conta,contaDestino, 500);
            Assert.IsNotNull(transf.Comprovante);
            Assert.AreEqual(500, conta.Saldo);
            Assert.AreEqual(500, contaDestino.Saldo);

        }


        [Test]
        public void Transferencia_transacoesBancarias_Saldo_Zerado()
        {
            RepositorioTransacaoBancaria.Limpar();
            ContaCorrente conta = new ContaCorrente();
            ContaCorrente contaDestino = new ContaCorrente();
            Assert.Throws<InvalidOperationException>(() => ServicoConta.ExecutarTransferencia(conta, contaDestino, 500));
        }

        [Test]
        public void Transferencia_transacoesBancarias_Conta_Bloqueada()
        {
            RepositorioTransacaoBancaria.Limpar();
            ContaCorrente conta = new ContaCorrente();
            ContaCorrente contaDestino = new ContaCorrente();
            ServicoConta.Bloquear(conta);
            Assert.Throws<InvalidOperationException>(() => ServicoConta.ExecutarTransferencia(conta, contaDestino, 500));
        }



        [Test]
        public void Bloquear_ContaCorrente()
        {
            ContaCorrente conta = new ContaCorrente();
            ServicoConta.Bloquear(conta);
            Assert.Throws<InvalidOperationException>(() => ServicoConta.ExecutarDeposito(conta, 500));
        }


        [Test]
        public void Desbloquear_ContaCorrente()
        {
            ContaCorrente conta = new ContaCorrente();
            ServicoConta.Bloquear(conta);
            ServicoConta.Desbloquear(conta);
            Assert.DoesNotThrow(() => ServicoConta.ExecutarDeposito(conta, 500));
        }


        [Test]
        public void Desbloquear_ContaCorrente_Ativa_Deve_Falhar()
        {
            ContaCorrente conta = new ContaCorrente();
            Assert.Throws<InvalidOperationException>(() => ServicoConta.Desbloquear(conta));
        }


        [Test]
        public void Cancelar_ContaCorrente()
        {
            ContaCorrente conta = new ContaCorrente();
            ServicoConta.Cancelar(conta);

            Assert.AreEqual("Fechada", conta.Status);
        }


        [Test]
        public void Cancelar_ContaCorrente_Com_Saldo_Deve_Falhar()
        {
            ContaCorrente conta = new ContaCorrente();
            ServicoConta.ExecutarDeposito(conta, 500);
            Assert.Throws<InvalidOperationException>(() =>ServicoConta.Cancelar(conta));
        }

        [Test]
        public void Transferencia_transacoesBancarias_ContaEspecial()
        {
            RepositorioTransacaoBancaria.Limpar();
            ContaEspecial conta = new ContaEspecial();
            conta.LimiteCredito = 7000;

            ContaCorrente contaDestino = new ContaCorrente();

            ServicoConta.ExecutarTransferencia(conta, contaDestino, 500);

            Assert.AreEqual(-500, conta.Saldo);
            Assert.AreEqual(500, contaDestino.Saldo);

        }



        [Test]
        public void Transferencia_transacoesBancarias_ContaEspecial_SemLimite()
        {
            RepositorioTransacaoBancaria.Limpar();
            ContaEspecial conta = new ContaEspecial();
            conta.LimiteCredito = 7000;

            conta.Credita(1000);

            ContaCorrente contaDestino = new ContaCorrente();

            Assert.Throws<InvalidOperationException>(() => ServicoConta.ExecutarTransferencia(conta, contaDestino, 90000));


        }



        [Test]
        public void Transferencia_transacoesBancarias_ContaEspecial_Credita_ValorNegativo()
        {
            RepositorioTransacaoBancaria.Limpar();
            ContaEspecial conta = new ContaEspecial();
            Assert.Throws<ArgumentException>(() => conta.Credita(-100));
        }


        [Test]
        public void Transferencia_transacoesBancarias_ContaEspecial_Debita_ValorNegativo()
        {
            RepositorioTransacaoBancaria.Limpar();
            ContaEspecial conta = new ContaEspecial();

            Assert.Throws<ArgumentException>(() => conta.Debita(-100));
        }


        [Test]
        public void Transferencia_transacoesBancarias_Conta_Debita_ValorNegativo()
        {
            RepositorioTransacaoBancaria.Limpar();
            var conta = new ContaCorrente();

            Assert.Throws<ArgumentException>(() => conta.Debita(-100));
        }





    }
}