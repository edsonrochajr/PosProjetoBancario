using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo
{
    public class Comprovante
    {

        public string Descricao { get; private set; }

        public Comprovante(string descricao)
        {
            Descricao = descricao;
        }


    }
}
