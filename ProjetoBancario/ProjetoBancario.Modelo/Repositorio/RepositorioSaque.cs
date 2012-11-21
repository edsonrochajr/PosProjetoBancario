using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo.Repositorio
{
    public static class RepositorioSaque
    {
        private static List<Saque> saques = new List<Saque>();

        public static void Adicionar(Saque saque)
        {
            saques.Add(saque);
        }


        public static List<Saque> Listar()
        {
            return saques;
        }
    }
}
