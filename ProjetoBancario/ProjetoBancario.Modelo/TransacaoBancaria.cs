using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo
{
    public abstract class TransacaoBancaria
    {
        public ContaCorrente Conta { get; private set; }

        public TransacaoBancaria(ContaCorrente contaCorrente)
        {
            Conta = contaCorrente;
            Data = DateTime.Now;
            Custo = 0;
        }

        public DateTime Data { get; set; }
        public decimal Custo { get; set; }

        public abstract Comprovante Comprovante { get; protected set; }

        public abstract void Executa();
    }
}
