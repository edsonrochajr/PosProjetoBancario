using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoBancario.Modelo.Repositorio;

namespace ProjetoBancario.Modelo.Servico
{
    public static class ServicoCliente
    {

        public static Cliente CadastrarPessoaFisica(string nome, string email, string dddTelefone, string telefone, string dddCelular, string celular, string cpf, string rg, string sexo, DateTime dtNascimento, string tipoLogradouro, string logradouro, int numero, string comp, string bairro, string cidade, string uF, string cep, decimal Salario, int numeroAgencia)
        {

            if (DateTime.Now.Year - dtNascimento.Year < 18)
                throw new InvalidOperationException("Perfil do cliente não atende: Idade inferior a 18");

            var cliente = RepositorioCliente.CriarPessoaFisica(nome, email, dddTelefone, telefone, dddCelular, celular, cpf, rg, sexo, dtNascimento, tipoLogradouro, logradouro, numero, comp, bairro, cidade, uF, cep);

            // "Acha"já dá erro se nao existir a agencia!!!
            var agencia = RepositorioAgencia.Acha(numeroAgencia);

            
            // CRIAR UMA CONTA CORRENTE
            if (Salario > 5000)
                RepositorioContaCorrente.AbrirContaEspecial(cliente, agencia, Salario * 2);
            else
                RepositorioContaCorrente.AbrirContaNormal(cliente, agencia);
            

            return cliente;
        }



        public static Cliente CadastrarPessoaJuridica(string nome, string email, string dddTelefone, string telefone, string dddCelular, string celular, string cnpj, string ie, DateTime dtFundacao, string tipoLogradouro, string logradouro, int numero, string comp, string bairro, string cidade, string uF, string cep, decimal salario, int numeroAgencia)
        {

            if (DateTime.Now.Year - dtFundacao.Year < 18)
                throw new InvalidOperationException("Perfil do cliente pessoa juridica não atende: Idade inferior a 18");

            var cliente = RepositorioCliente.CriarPessoaJuridica(nome, email, dddTelefone, telefone, dddCelular, celular, cnpj, ie, dtFundacao, tipoLogradouro, logradouro, numero, comp, bairro, cidade, uF, cep);

            // "Acha"já dá erro se nao existir a agencia!!!
            var agencia = RepositorioAgencia.Acha(numeroAgencia);

            // CRIAR UMA CONTA CORRENTE
            if (salario > 5000)
                RepositorioContaCorrente.AbrirContaEspecial(cliente, agencia, salario * 2);
            else
                RepositorioContaCorrente.AbrirContaNormal(cliente, agencia);

            return cliente;

        }



    }
}
