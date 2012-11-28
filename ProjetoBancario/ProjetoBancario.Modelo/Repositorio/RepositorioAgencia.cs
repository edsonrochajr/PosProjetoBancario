using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo.Repositorio
{
    public static class RepositorioAgencia
    {

        static List<Agencia> Agencias = new List<Agencia>();

        public static Agencia Criar(int numero, string descricao, int numeroBanco, string nomeBanco)
        {

            if (Agencias.Any(a => a.Numero == numero && a.NumeroBanco == numeroBanco))
                throw new InvalidOperationException("Agencia já existe!");

            var ag = new Agencia()
            {
                Numero = numero,
                Descricao = descricao,
                NumeroBanco = numeroBanco,
                NomeBanco = nomeBanco
            };
            Agencias.Add(ag);
            return ag;

        }

        public static Agencia Acha(int numeroAgencia)
        {
            return Agencias.Single(a => a.Numero == numeroAgencia);
        }

        internal static void Limpa()
        {
            Agencias.Clear();
        }
    }
}
