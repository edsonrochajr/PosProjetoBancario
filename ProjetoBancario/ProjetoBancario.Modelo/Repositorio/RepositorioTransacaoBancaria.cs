using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo.Repositorio
{
    //class RepositorioTransacaoBancaria
    //{
    //}

    public static class RepositorioTransacaoBancaria
    {
        private static List<TransacaoBancaria> transacoes = new List<TransacaoBancaria>();

        public static void Adicionar(TransacaoBancaria transacao)
        {
            transacoes.Add(transacao);
        }

        public static void Limpar()
        {
            transacoes.Clear();
        }

        public static List<TransacaoBancaria> Listar()
        {
            return transacoes;
        }

        public static IEnumerable<TransacaoBancaria> EmiteExtrato(ContaCorrente conta, int diasParaTras)
        {
            return transacoes.Where(t => 
                t.Data > DateTime.Now.Date.AddDays(-diasParaTras) &&
                t.Conta == conta);
        }
    }
}
