using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo
{
    public class TransacaoBancaria:Cliente
    {

        public DateTime DataTransacao { get; set; }
        public decimal ValorTransacao { get; set; }


    }
}
