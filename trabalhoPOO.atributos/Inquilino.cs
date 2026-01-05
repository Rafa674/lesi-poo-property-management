using System;
using System.Collections.Generic;

namespace Atributos
{
    /**
     * @file Inquilino.cs
     * @brief Representa um inquilino.
     *
     * Herda de `Pessoa` e adiciona dados profissionais e financeiros.
     */
    [Serializable]
    public class Inquilino : Pessoa, IComparable<Inquilino>
    {
        #region Atributos
        private string profissao;
        private double rendimentoMensal;
        #endregion

        /**
         * @brief Profissão do inquilino.
         */
        public string Profissao
        {
            get { return profissao; }
            set { profissao = value; }
        }

        /**
         * @brief Rendimento mensal do inquilino.
         */
        public double RendimentoMensal
        {
            get { return rendimentoMensal; }
            set { rendimentoMensal = value; }
        }

        /**
         * @brief Construtor por omissão.
         */
        public Inquilino() : base() { }

        /**
         * @brief Construtor completo.
         */
        public Inquilino(int id, int nif, string nome, int contacto, string profissao, double rendimentoMensal, Localidade localidade)
            : base(id, nif, nome, contacto, localidade)
        {
            Profissao = profissao;
            RendimentoMensal = rendimentoMensal;
        }

        /**
         * @brief Comparação natural por ID.
         */
        public int CompareTo(Inquilino? other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }
    }
}

