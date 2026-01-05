using System;

namespace Excecoes
{
    /**
     * @file SenhorioNaoEncontrado.cs
     * @brief Exceção lançada quando um senhorio não é encontrado.
     */
    public class SenhorioNaoEncontrado : OperacaoInvalida
    {
        /**
         * @brief Construtor com Id do senhorio.
         * @param id Identificador do senhorio.
         */
        public SenhorioNaoEncontrado(int id)
            : base($"Senhorio com ID {id} não encontrado.")
        {
        }

        /**
         * @brief Construtor com mensagem personalizada.
         * @param mensagem Texto descritivo do erro.
         */
        public SenhorioNaoEncontrado(string mensagem)
            : base(mensagem)
        {
        }
    }
}