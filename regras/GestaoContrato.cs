using System;
using System.Collections.Generic;
using Dados;
using Atributos;
using Excecoes;

namespace regras
{
    /**
     * @file GestaoContrato.cs
     * @brief Regras para criar, atualizar, remover e consultar contratos.
     */
    public class GestaoContrato
    {
        private RepositorioContrato dadosContratos;

        /**
         * @brief Construtor com repositório de contratos.
         */
        public GestaoContrato(RepositorioContrato repositorio)
        {
            dadosContratos = repositorio;
        }

        /**
         * @brief Cria um contrato (valida datas e entidades).
         */
        public bool Criar(int id, Senhorio senhorio, Inquilino inquilino, Imovel imovel, DateTime dataInicio, DateTime dataFim, int estado)
        {
            if (dataFim < dataInicio)
            {
                throw new OperacaoInvalida("Data de fim não pode ser anterior à data de início.");
            }

            if (senhorio == null)
            {
                throw new OperacaoInvalida("Senhorio inválido.");
            }

            if (inquilino == null)
            {
                throw new OperacaoInvalida("Inquilino inválido.");
            }

            var contrato = new Contrato(id, senhorio, inquilino, imovel, dataInicio, dataFim, estado);
            dadosContratos.Adicionar(contrato);

            return true;
        }

        /**
         * @brief Atualiza um contrato existente (valida entrada).
         */
        public bool Alterar(int id, DateTime dataInicio, DateTime dataFim, int estado, Inquilino inquilino, Imovel imovel, Senhorio senhorio)
        {
            var existente = dadosContratos.ObterPorId(id);
            if (existente == null)
            {
                throw new ContratoNaoEncontrado(id);
            }

            if (dataFim < dataInicio)
            {
                throw new OperacaoInvalida("Data de fim não pode ser anterior à data de início.");
            }

            if (senhorio == null)
            {
                throw new OperacaoInvalida("Senhorio inválido.");
            }

            if (inquilino == null)
            {
                throw new OperacaoInvalida("Inquilino inválido.");
            }

            var novosDados = new Contrato(id, senhorio, inquilino, imovel, dataInicio, dataFim, estado);

            dadosContratos.Alterar(id, novosDados);
            return true;
        }

        /**
         * @brief Remove um contrato pelo Id.
         */
        public bool Remover(int id)
        {
            var existente = dadosContratos.ObterPorId(id);
            if (existente == null)
            {
                throw new ContratoNaoEncontrado(id);
            }

            dadosContratos.Remover(id);
            return true;
        }

        /**
         * @brief Lista todos os contratos ordenados por Id.
         */
        public List<Contrato> Listar()
        {
            var lista = dadosContratos.Listar();
            lista.Sort();
            return lista;
        }
    }
}