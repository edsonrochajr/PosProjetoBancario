using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo
{
    public class ContaCorrente
    {
        public int Numero { get; set; }
        public Agencia Agencia { get; set; }
        public string Status { get; set; }
        public DateTime DataAbertura { get; set; }
        public decimal Saldo { get; protected set; }
        public Cliente Cliente { get; set; }

        public bool Ativa { get { return Status != "Bloqueado" && Status != "Fechado"; } }


        public virtual decimal Debita(decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor a debitar não pode ser negativo!");

            if (Saldo - valor < 0)
                throw new InvalidOperationException("Saldo insuficiente!");

            return Saldo -= valor;
        }


        public virtual decimal Credita(decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor a creditar não pode ser negativo!");

            return Saldo += valor;
        }




    }
}
