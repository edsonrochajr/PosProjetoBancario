using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo
{
    public class Telefone : Cliente
    {
        public string Tipo { get; set; }
        public int DDD { get; set; }
        public int Numero { get; set; }
    }
}
