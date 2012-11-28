using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBancario.Modelo.Repositorio;

namespace ProjetoBancario.Modelo.Servico
{
    public static class ServicoConta
    {

        public static void Cancelar(ContaCorrente conta)
        {
            if (conta.Saldo != 0)
                throw new InvalidOperationException("Não se pode cancelar uma conta com saldo negativo ou positivo");
            conta.Status = "Fechada";
        }

        public static void Bloquear(ContaCorrente conta)
        {
            conta.Status = "Bloqueado";
        }

        public static void Desbloquear(ContaCorrente conta)
        {
            if (conta.Status == "Bloqueado")
                conta.Status = "Ativa";
            else
                throw new InvalidOperationException("Não se pode desbloquear uma conta com o status=" + conta.Status);
        }


        public static Saque ExecutarSaque(ContaCorrente conta, decimal valor)
        {
            Saque saque;
            if (conta.Ativa && conta.Saldo >= valor)
            {
                saque = new Saque(conta, valor);
                saque.Executa();
                RepositorioTransacaoBancaria.Adicionar(saque);
            }
            else
            {
                throw new InvalidOperationException("Conta bloqueada ou saldo insuficiente!");
            }
            return saque;
        }


        public static Deposito ExecutarDeposito(ContaCorrente conta, decimal valor)
        {
            Deposito deposito = null;
            if (conta.Ativa)
            {
                deposito = new Deposito(conta, valor);
                deposito.Executa();
                RepositorioTransacaoBancaria.Adicionar(deposito);

            }
            else
            {
                throw new InvalidOperationException("Conta bloqueada ou saldo insuficiente!");
            }
            return deposito;
        }


        public static Transferencia ExecutarTransferencia(ContaCorrente contaOrigem, ContaCorrente contaDestino, decimal valor)
        {
            Transferencia transacao;
            if (contaOrigem.Ativa && contaDestino.Ativa)
            {
                transacao = new Transferencia(contaOrigem, contaDestino, valor);
                transacao.Executa();
                RepositorioTransacaoBancaria.Adicionar(transacao);
            }
            else
            {
                throw new InvalidOperationException("Conta bloqueada ou saldo insuficiente!");
            }
            return transacao;
        }




       








    }
}
