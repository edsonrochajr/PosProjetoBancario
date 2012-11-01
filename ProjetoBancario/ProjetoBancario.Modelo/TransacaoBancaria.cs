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
        }

        public DateTime Data { get; set; }
        public decimal Custo { get; set; }

        public Comprovante Comprovante { get; protected set; }

        public virtual Comprovante GeraComprovante()
        {
            return new Comprovante(Operacao + "em:" + Data + "Custo:" + Custo);
        }

        public abstract string Operacao
        { get; }


        public virtual void Executa()
        {
            Conta.Debita(Custo);
        }




    }
}
