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


        public static IEnumerable<TransacaoBancaria> EmiteExtrato(ContaCorrente conta, int disParaTras)
        {
            var hoje = DateTime.Now;
            return EmiteExtrato(conta, hoje.AddDays(-disParaTras), hoje);
        }

        public static IEnumerable<TransacaoBancaria> EmiteExtrato(ContaCorrente conta, DateTime ini, DateTime fim)
        {
            return transacoes.Where(t => 
                t.Data >= ini && t.Data <= fim &&
                t.Conta == conta);
        }
    }
}
