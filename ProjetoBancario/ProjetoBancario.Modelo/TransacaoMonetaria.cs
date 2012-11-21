using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo
{
    public abstract class TransacaoMonetaria : TransacaoBancaria
    {
        public TransacaoMonetaria(ContaCorrente conta)
            : base(conta)
        {

        }

        public decimal Valor { get; set; }
    }



}
