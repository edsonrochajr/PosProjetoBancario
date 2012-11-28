using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo.Repositorio
{
    public static class RepositorioContaCorrente
    {
        static List<ContaCorrente> Contas = new List<ContaCorrente>();

        public static void Limpa() { Contas.Clear(); }

        public static IEnumerable<ContaCorrente> Listar()
        {
            return Contas.AsEnumerable();
        }

        public static ContaCorrente AbrirContaNormal(Cliente cliente, Agencia agencia)
        {
            var cc = new ContaCorrente()
            {
                Numero = Contas.Count > 0 ? Contas.Max(c => c.Numero) + 1 : 1,
                DataAbertura = DateTime.Now,
                Agencia = agencia,
                Cliente = cliente,
            };
            Contas.Add(cc);
            return cc;
        }

        public static ContaCorrente AbrirContaEspecial(Cliente cliente, Agencia agencia, decimal LimiteDeCredito)
        {
            var cc = new ContaEspecial()
            {
                Numero = Contas.Count > 0 ? Contas.Max(c => c.Numero) + 1 : 1,
                DataAbertura = DateTime.Now,
                Agencia = agencia,
                LimiteCredito = LimiteDeCredito,
                Cliente = cliente,
            };
            Contas.Add(cc);
            return cc;
        }



    }
}
