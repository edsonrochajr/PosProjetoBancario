using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo
{
    public class Extrato : TransacaoBancaria
    {
        public DateTime DtInicio { get ; set ; }
        public DateTime DtFim { get; set; }

        public Extrato(ContaCorrente conta, DateTime inicio, DateTime fim)
            : base(conta)
        {
            DtInicio = inicio;
            DtFim = fim;

        }

        public IEnumerable<TransacaoBancaria> TransacoesBancarias { get; private set; }

        //public override void Executa()
        //{
        //    if (Conta.Ativa)
        //        TransacoesBancarias = Repositorio.RepositorioTransacaoBancaria.Listar().Where(c => c.Data >= DtInicio && c.Data <= DtFim && c.Conta == Conta).ToArray();
        //    else
        //        throw new InvalidOperationException("Proibido a emissão de extrato para conta inativa!");
        //}


        public override void Executa()
        {
            Comprovante = new Comprovante("Comprovante em:" + Data);
            if (Conta.Ativa)
            {
                TransacoesBancarias = Repositorio.RepositorioTransacaoBancaria.EmiteExtrato(Conta, DtInicio, DtFim);
            }
            else
                throw new InvalidOperationException("Proibido a emissão de extrato para conta inativa!");
        }

        Comprovante comprovante;

        public override Comprovante Comprovante
        {
            get
            {
                return comprovante;
            }
            protected set
            {
                comprovante = value;
            }
        }
    }
}
