using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo
{
    public abstract class Cliente
    {

        public string Nome { get; set; }
        public string Email { get; set; }
        List<Telefone> telefones = new List<Telefone>();
        public IList<Telefone> Telefones
        {
            get { return telefones; }
        }

        public Endereco Endereco { get; set; }
    }
}
