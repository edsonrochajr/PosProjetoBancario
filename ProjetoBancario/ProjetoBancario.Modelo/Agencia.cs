﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo
{
    public class Agencia
    {
        public int Numero { get; set; }
        public string Descricao { get; set; }
        public Banco Banco { get; set; }

        List<ContaCorrente> contas = new List<ContaCorrente>();
        public IList<ContaCorrente> Contas
        {
            get { return contas; }
        }


    }
}
