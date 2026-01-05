using System;
using System.Collections.Generic;

namespace Atributos
{
    /**
     * @file Localidade.cs
     * @brief Representa uma localidade.
     *
     * Guarda distrito, concelho e freguesia.
     */
    [Serializable]
    public class Localidade
    {
        #region Atributos
        private string distrito;
        private string concelho;
        private string freguesia;
        #endregion

        /**
         * @brief Distrito.
         */
        public string Distrito
        {
            get { return distrito; }
            set { distrito = value; }
        }

        /**
         * @brief Concelho.
         */
        public string Concelho
        {
            get { return concelho; }
            set { concelho = value; }
        }

        /**
         * @brief Freguesia.
         */
        public string Freguesia
        {
            get { return freguesia; }
            set { freguesia = value; }
        }

        /**
         * @brief Construtor por omissão.
         */
        public Localidade() { }

        /**
         * @brief Construtor completo.
         */
        public Localidade(string distrito, string concelho, string freguesia)
        {
            Distrito = distrito;
            Concelho = concelho;
            Freguesia = freguesia;
        }
    }
}