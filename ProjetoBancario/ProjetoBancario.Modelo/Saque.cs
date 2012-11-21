using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo
{
    public class Saque : TransacaoMonetaria
    {
        public Saque(ContaCorrente conta, decimal valor) : base(conta)
        {
            this.Valor = valor;
        }

        public override void Executa()
        {
            Conta.Debita(Valor);
            Comprovante = GerarComprovante();
        }

        private Comprovante GerarComprovante()
        {
            return new Comprovante("Saque em:" + Data + "Custo:" + Custo + "Valor de:" + Valor);
        }

        public override Comprovante Comprovante
        {
            get;
            protected set;
        }


    }
}
