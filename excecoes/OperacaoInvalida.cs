using System;

namespace Excecoes
{
    /**
     * @file OperacaoInvalida.cs
     * @brief Exceção base para operações inválidas de negócio.
     */
    public class OperacaoInvalida : ApplicationException
    {
        /**
         * @brief Construtor com mensagem padrão.
         */
        public OperacaoInvalida()
            : base("Operação inválida.")
        {
        }

        /**
         * @brief Construtor com mensagem personalizada.
         * @param mensagem Texto descritivo do erro.
         */
        public OperacaoInvalida(string mensagem)
            : base(mensagem)
        {
        }
    }
}
