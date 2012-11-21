using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo.Repositorio
{
    public class RepositorioContaCorrente
    {
        static List<ContaCorrente> Contas = new List<ContaCorrente>();

        public static ContaCorrente AbrirContaNormal(Cliente cliente, Agencia agencia)
        {
            return new ContaCorrente()
            {
                Numero = Contas.Max(c => c.Numero) + 1,
                DataAbertura = DateTime.Now,
                Agencia = agencia,
            };
        }

        public static ContaCorrente AbrirContaEspecial(Cliente cliente, Agencia agencia, decimal LimiteDeCredito)
        {
            return new ContaEspecial()
            {
                Numero = Contas.Max(c => c.Numero) + 1,
                DataAbertura = DateTime.Now,
                Agencia = agencia,
                LimiteCredito = LimiteDeCredito,
            };
        }



    }
}
