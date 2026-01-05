using System;

namespace Excecoes
{
    /**
     * @file InquilinoNaoEncontrado.cs
     * @brief Exceção lançada quando um inquilino não é encontrado.
     */
    public class InquilinoNaoEncontrado : OperacaoInvalida
    {
        /**
         * @brief Construtor com Id do inquilino.
         * @param id Identificador do inquilino.
         */
        public InquilinoNaoEncontrado(int id)
            : base($"Inquilino com ID {id} não encontrado.")
        {
        }

        /**
         * @brief Construtor com mensagem personalizada.
         * @param mensagem Texto descritivo do erro.
         */
        public InquilinoNaoEncontrado(string mensagem)
            : base(mensagem)
        {
        }
    }
}
