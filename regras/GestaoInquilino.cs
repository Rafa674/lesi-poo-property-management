using System;
using System.Collections.Generic;
using Dados;
using Atributos;
using Excecoes;

namespace regras
{
    /**
     * @file GestaoInquilino.cs
     * @brief Regras para criar, atualizar, remover e consultar inquilinos.
     */
    public class GestaoInquilino
    {
        private RepositorioInquilino dadosInquilinos;

        /**
         * @brief Construtor com repositório de inquilinos.
         */
        public GestaoInquilino(RepositorioInquilino repositorio)
        {
            dadosInquilinos = repositorio;
        }

        /**
         * @brief Cria um inquilino (valida nome, NIF e rendimento).
         */
        public bool Criar(int id, int nif, string nome, int contacto, string profissao, double rendimentoMensal, Localidade localidade)
        {
            if (string.IsNullOrWhiteSpace(nome) || nif <= 0)
            {
                throw new OperacaoInvalida("Nome e NIF do inquilino são obrigatórios.");
            }

            if (localidade == null)
            {
                throw new OperacaoInvalida("Localidade do inquilino é obrigatória.");
            }

            if (rendimentoMensal < 0)
            {
                throw new OperacaoInvalida("Rendimento mensal não pode ser negativo.");
            }

            var novoInquilino = new Inquilino(id, nif, nome, contacto, profissao, rendimentoMensal, localidade);
            dadosInquilinos.Adicionar(novoInquilino);

            return true;
        }

        /**
         * @brief Atualiza um inquilino existente (valida entrada).
         */
        public bool Alterar(int id, int nif, string nome, int contacto, string profissao, double rendimentoMensal, Localidade localidade)
        {
            var existente = dadosInquilinos.ObterPorId(id);
            if (existente == null)
            {
                throw new InquilinoNaoEncontrado(id);
            }

            if (string.IsNullOrWhiteSpace(nome) || nif <= 0)
            {
                throw new OperacaoInvalida("Nome e NIF do inquilino são obrigatórios.");
            }

            if (localidade == null)
            {
                throw new OperacaoInvalida("Localidade do inquilino é obrigatória.");
            }

            if (rendimentoMensal < 0)
            {
                throw new OperacaoInvalida("Rendimento mensal não pode ser negativo.");
            }

            var novosDados = new Inquilino(id, nif, nome, contacto, profissao, rendimentoMensal, localidade);

            dadosInquilinos.Alterar(id, novosDados);
            return true;
        }

        /**
         * @brief Remove um inquilino pelo Id.
         */
        public bool Remover(int id)
        {
            var existente = dadosInquilinos.ObterPorId(id);
            if (existente == null)
            {
                throw new InquilinoNaoEncontrado(id);
            }

            dadosInquilinos.Remover(id);
            return true;
        }

        /**
         * @brief Lista todos os inquilinos ordenados por Id.
         */
        public List<Inquilino> Listar()
        {
            var lista = dadosInquilinos.Listar();
            lista.Sort();
            return lista;
        }
    }
}