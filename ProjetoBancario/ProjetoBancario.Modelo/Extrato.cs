using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo
{
    public class Extrato : TransacaoBancaria
    {
        public Extrato(ContaCorrente conta)
            : base(conta)
        {

        }

        public override string Operacao
        {
            get { return "Extrato"; }
        }

    }
}
