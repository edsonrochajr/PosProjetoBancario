using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBancario.Modelo.Repositorio
{
    public static class RepositorioCliente
    {

        public static Cliente CriarPessoaFisica(string nome, string email, string dddTelefone, string telefone, string dddCelular, string celular, string cpf, string rg, string sexo, DateTime dtNascimento, string tipoLogradouro, string logradouro, int numero, string comp, string bairro, string cidade, string uF, string cep)
        {

            var PF = new PessoaFisica()
            {
                Nome = nome,
                Email = email,
                Cpf = cpf,
                DataNascimento = dtNascimento,
                Rg = rg,
                Sexo = sexo,
                Endereco = new Endereco()
                {
                    TipoLogradouro = tipoLogradouro,
                    Logradouro = logradouro,
                    Numero = numero,
                    Comp = comp,
                    Bairro = bairro,
                    Cidade = cidade,
                    UF = uF,
                    Cep = cep,
                }
            };


            PF.Telefones.Add(new Telefone()
            {
                DDD = dddTelefone,
                Numero = telefone,
                Tipo = "Residencial",
            });


            PF.Telefones.Add(new Telefone()
            {
                DDD = dddCelular,
                Numero = celular,
                Tipo = "Celular",
            });

            return PF;

        }



        public static Cliente CriarPessoaJuridica(string nome, string email, string dddTelefone, string telefone, string dddCelular, string celular, string cnpj, string insEst, DateTime dtFundacao, string tipoLogradouro, string logradouro, int numero, string comp, string bairro, string cidade, string uF, string cep)
        {

            var PJ = new PessoaJuridica()
            {
                Nome = nome,
                Email = email,

                Cnpj = cnpj,
                DataFundacao = dtFundacao,
                InscricaoEstadual = insEst,

                Endereco = new Endereco()
                {
                    TipoLogradouro = tipoLogradouro,
                    Logradouro = logradouro,
                    Numero = numero,
                    Comp = comp,
                    Bairro = bairro,
                    Cidade = cidade,
                    UF = uF,
                    Cep = cep,
                }
            };


            PJ.Telefones.Add(new Telefone()
            {
                DDD = dddTelefone,
                Numero = telefone,
                Tipo = "Empresa",
            });


            PJ.Telefones.Add(new Telefone()
            {
                DDD = dddCelular,
                Numero = celular,
                Tipo = "Celular",
            });

            return PJ;

        }



    }
}
