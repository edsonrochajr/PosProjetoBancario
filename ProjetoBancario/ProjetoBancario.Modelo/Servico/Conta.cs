using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo.Servico
{
    public class Conta
    {
        public static void Cancelar(ContaCorrente conta)
        {
            if (conta.Saldo != 0)
                throw new InvalidOperationException("Não se pode cancelar uma conta com saldo negativo ou positivo");
            conta.Status = "Fechada";
        }
        public static void Bloquear(ContaCorrente conta)
        {
            conta.Status = "Bloqueada";
        }
        public static void Desbloquear(ContaCorrente conta)
        {
            if (conta.Status == "Bloqueada")
                conta.Status = "Ativa";
            else
                throw new InvalidOperationException("Não se pode desbloquear uma conta com o status=" + conta.Status);
        }

    }
}
