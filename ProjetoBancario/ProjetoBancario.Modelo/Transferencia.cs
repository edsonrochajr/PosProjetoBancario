using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo
{
    public class Transferencia : TransacaoMonetaria
    {


        public Transferencia(ContaCorrente conta, ContaCorrente contaDestino,decimal valor)
            : base(conta)
        {
            this.Valor = valor;
        }


        public ContaCorrente ContaDestino { get; private set; }


        public override void Executa()
        {
            Conta.Debita(Valor);
            ContaDestino.Credita(Valor);
            Comprovante = GerarComprovante();
        }

        private Comprovante GerarComprovante()
        {
            return new Comprovante("Transferência de conta: " + Conta.Numero + " para a conta de destino: " + ContaDestino.Numero + " em:" + Data + " Custo:" + Custo + " no Valor de:" + Valor);
        }

        public override Comprovante Comprovante
        {
            get;
            protected set;
        }

    }
}
