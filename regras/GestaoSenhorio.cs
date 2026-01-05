using System;
using System.Collections.Generic;
using Dados;
using Atributos;
using Excecoes;

namespace regras
{
    /**
     * @file GestaoSenhorio.cs
     * @brief Regras para criar, atualizar, remover e consultar senhorios.
     */
    public class GestaoSenhorio
    {
        private RepositorioSenhorio dadosSenhorios;

        /**
         * @brief Construtor com repositório de senhorios.
         */
        public GestaoSenhorio(RepositorioSenhorio dadosSenhorios)
        {
            this.dadosSenhorios = dadosSenhorios;
        }

        /**
         * @brief Cria um senhorio (valida nome, NIF e número de imóveis).
         */
        public bool Criar(int id, int nif, string nome, int contacto, Localidade localidade, int numeroImoveis)
        {
            if (string.IsNullOrWhiteSpace(nome) || nif <= 0)
            {
                throw new OperacaoInvalida("Nome e NIF do senhorio são obrigatórios.");
            }

            if (numeroImoveis < 0)
            {
                throw new OperacaoInvalida("Número de imóveis não pode ser negativo.");
            }

            var senhorio = new Senhorio(id, nif, nome, contacto, numeroImoveis, localidade);
            dadosSenhorios.Adicionar(senhorio);

            return true;
        }

        /**
         * @brief Atualiza um senhorio existente (valida entrada).
         */
        public bool Alterar(int id, int nif, string nome, int contacto, Localidade localidade, int numeroImoveis)
        {
            var senhorio = dadosSenhorios.ObterPorId(id);
            if (senhorio == null)
            {
                throw new SenhorioNaoEncontrado(id);
            }

            if (string.IsNullOrWhiteSpace(nome) || nif <= 0)
            {
                throw new OperacaoInvalida("Nome e NIF do senhorio são obrigatórios.");
            }

            if (numeroImoveis < 0)
            {
                throw new OperacaoInvalida("Número de imóveis não pode ser negativo.");
            }

            senhorio.Nome = nome;
            senhorio.Nif = nif;
            senhorio.Contacto = contacto;
            senhorio.Localidade = localidade;
            senhorio.NumeroImoveis = numeroImoveis;

            return true;
        }

        /**
         * @brief Remove um senhorio pelo Id.
         */
        public bool Remover(int id)
        {
            var existente = dadosSenhorios.ObterPorId(id);
            if (existente == null)
            {
                throw new SenhorioNaoEncontrado(id);
            }

            return dadosSenhorios.Remover(id);
        }

        /**
         * @brief Obtém um senhorio pelo Id.
         */
        public Senhorio ObterPorId(int id)
        {
            var senhorio = dadosSenhorios.ObterPorId(id);
            if (senhorio == null)
            {
                throw new SenhorioNaoEncontrado(id);
            }

            return senhorio;
        }

        /**
         * @brief Lista todos os senhorios ordenados por Id.
         */
        public List<Senhorio> Listar()
        {
            var lista = dadosSenhorios.Listar();
            lista.Sort();
            return lista;
        }
    }
}