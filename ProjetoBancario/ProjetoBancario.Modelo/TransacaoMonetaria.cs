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

        public override Comprovante GeraComprovante()
        {
            return new Comprovante(Operacao + "em:" + Data + "Custo:" + Custo + "Valor de:" + Valor);
        }

    }



}
