using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Atributos
{
    /**
     * @file Senhorio.cs
     * @brief Representa um senhorio.
     *
     * Herda de `Pessoa` e inclui informação sobre imóveis.
     *
     * Agregação:
     * - Um senhorio tem vários imóveis.
     */
    [Serializable]
    public class Senhorio : Pessoa, IComparable<Senhorio>
    {
        #region Atributos
        private int numeroImoveis;
        [NonSerialized]
        private List<Imovel> imoveis;
        #endregion

        /**
         * @brief Número de imóveis do senhorio.
         */
        public int NumeroImoveis
        {
            get { return numeroImoveis; }
            set { numeroImoveis = value; }
        }

        /**
         * @brief Imóveis pertencentes ao senhorio.
         */
        public List<Imovel> Imoveis
        {
            get { return imoveis; }
            set { imoveis = value; }
        }

        /**
         * @brief Construtor por omissão.
         */
        public Senhorio() : base()
        {
            imoveis = new List<Imovel>();
        }

        /**
         * @brief Construtor completo.
         */
        public Senhorio(int id, int nif, string nome, int contacto, int numeroImoveis, Localidade localidade)
            : base(id, nif, nome, contacto, localidade)
        {
            NumeroImoveis = numeroImoveis;
            imoveis = new List<Imovel>();
        }

        /**
         * @brief Comparação natural por ID.
         */
        public int CompareTo(Senhorio other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }
    }
}