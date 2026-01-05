using System;
using System.Collections.Generic;

namespace Atributos
{
    /**
     * @file Despesa.cs
     * @brief Representa uma despesa.
     *
     * Agregação:
     * - A despesa é guardada dentro de `Imovel.Despesas`.
     */
    [Serializable]
    public class Despesa : IComparable<Despesa>
    {
        #region Atributos
        private int id;
        private DateTime data;
        private double valor;
        [NonSerialized]
        private Imovel imovel;
        #endregion

        /**
         * @brief Identificador único da despesa.
         */
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /**
         * @brief Data da despesa.
         */
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        /**
         * @brief Valor da despesa.
         */
        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        /**
         * @brief Imóvel associado à despesa.
         */
        public Imovel Imovel
        {
            get { return imovel; }
            set { imovel = value; }
        }

        /**
         * @brief Construtor por omissão.
         */
        public Despesa() { }

        /**
         * @brief Construtor completo.
         */
        public Despesa(int id, Imovel imovel, DateTime data, double valor)
        {
            Id = id;
            Imovel = imovel;
            Data = data;
            Valor = valor;
        }

        /**
         * @brief Comparação natural por ID.
         */
        public int CompareTo(Despesa? other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }
    }
}
