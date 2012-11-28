using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ProjetoBancario.Modelo.Repositorio;
using ProjetoBancario.Modelo.Servico;

namespace ProjetoBancario.Modelo.Teste
{
    public class AgenciaTeste
    {

        [Test]
        public void Criar_Agencia()
        {
            var ag = RepositorioAgencia.Criar(123, "Xpto Barra", 100, "XPTO");
            Assert.IsNotNull(ag);
            Assert.AreEqual("Xpto Barra", ag.Descricao);
            Assert.AreEqual(123, ag.Numero);
            Assert.AreEqual(100, ag.NumeroBanco);
            Assert.AreEqual("XPTO", ag.NomeBanco);
        }

        [Test]
        public void Criar_Agencia_Existente()
        {
            RepositorioAgencia.Limpa();
            var ag = RepositorioAgencia.Criar(123, "Xpto Barra", 100, "XPTO");
            Assert.Throws<InvalidOperationException>(() => RepositorioAgencia.Criar(123, "Xpto Barra", 100, "XPTO"));
        }

    }
}
