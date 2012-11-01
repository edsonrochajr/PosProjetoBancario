using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo
{
    public class Deposito : TransacaoMonetaria
    {
        public Deposito(ContaCorrente conta)
            : base(conta)
        {

        }

        public override string Operacao
        {
            get { return "Deposito"; }
        }
    }
}
