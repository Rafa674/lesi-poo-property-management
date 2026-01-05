using System;

namespace Excecoes
{
    /**
     * @file DespesaNaoEncontrada.cs
     * @brief Exceção lançada quando uma despesa não é encontrada.
     */
    public class DespesaNaoEncontrada : OperacaoInvalida
    {
        /**
         * @brief Construtor com Id da despesa.
         * @param id Identificador da despesa.
         */
        public DespesaNaoEncontrada(int id)
            : base($"Despesa com ID {id} não encontrada.")
        {
        }

        /**
         * @brief Construtor com mensagem personalizada.
         * @param mensagem Texto descritivo do erro.
         */
        public DespesaNaoEncontrada(string mensagem)
            : base(mensagem)
        {
        }
    }
}