using System;

namespace Excecoes
{
    /**
     * @file ContratoNaoEncontrado.cs
     * @brief Exceção lançada quando um contrato não é encontrado.
     */
    public class ContratoNaoEncontrado : OperacaoInvalida
    {
        /**
         * @brief Construtor com Id do contrato.
         * @param id Identificador do contrato.
         */
        public ContratoNaoEncontrado(int id)
            : base($"Contrato com ID {id} não encontrado.")
        {
        }

        /**
         * @brief Construtor com mensagem personalizada.
         * @param mensagem Texto descritivo do erro.
         */
        public ContratoNaoEncontrado(string mensagem)
            : base(mensagem)
        {
        }
    }
}
