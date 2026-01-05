using System;

namespace Excecoes
{
    /**
     * @file ImovelNaoEncontrado.cs
     * @brief Exceção lançada quando um imóvel não é encontrado.
     */
    public class ImovelNaoEncontrado : OperacaoInvalida
    {
        /**
         * @brief Construtor com Id do imóvel.
         * @param id Identificador do imóvel.
         */
        public ImovelNaoEncontrado(int id)
            : base($"Imóvel com ID {id} não encontrado.")
        {
        }

        /**
         * @brief Construtor com mensagem personalizada.
         * @param mensagem Texto descritivo do erro.
         */
        public ImovelNaoEncontrado(string mensagem)
            : base(mensagem)
        {
        }
    }
}
