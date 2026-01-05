using System;

namespace Excecoes
{
    /**
     * @file ReciboNaoEncontrado.cs
     * @brief Exceção lançada quando um recibo não é encontrado.
     */
    public class ReciboNaoEncontrado : OperacaoInvalida
    {
        /**
         * @brief Construtor com Id do recibo.
         * @param id Identificador do recibo.
         */
        public ReciboNaoEncontrado(int id)
            : base($"Recibo com ID {id} não encontrado.")
        {
        }

        /**
         * @brief Construtor com mensagem personalizada.
         * @param mensagem Texto descritivo do erro.
         */
        public ReciboNaoEncontrado(string mensagem)
            : base(mensagem)
        {
        }
    }
}
