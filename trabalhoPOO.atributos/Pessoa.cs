using System;
using System.Collections.Generic;

namespace Atributos
{
    /**
     * @file Pessoa.cs
     * @brief Classe base abstrata para entidades que representam pessoas (Senhorio, Inquilino).
     *
     * Contém propriedades comuns: identificador (ID), NIF, nome, contacto telefónico e localidade.
     */
    [Serializable]
    public abstract class Pessoa : IComparable<Pessoa>
    {
        #region Atributos
        private int id;
        private int nif;
        private string nome;
        private int contacto;
        private Localidade localidade;
        #endregion

        /**
         * @brief Identificador único da pessoa (ID).
         */
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /**
         * @brief Número de Identificação Fiscal (NIF).
         */
        public int Nif
        {
            get { return nif; }
            set { nif = value; }
        }

        /**
         * @brief Nome completo da pessoa.
         */
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /**
         * @brief Número de contacto telefónico.
         */
        public int Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }

        /**
         * @brief Localidade onde a pessoa está associada.
         */
        public Localidade Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }

        /**
         * @brief Construtor por omissão.
         */
        public Pessoa() { }

        /**
         * @brief Construtor que inicializa os dados principais da pessoa.
         */
        public Pessoa(int id, int nif, string nome, int contacto, Localidade localidade)
        {
            Id = id;
            Nif = nif;
            Nome = nome;
            Contacto = contacto;
            Localidade = localidade;
        }

        /**
         * @brief Comparação natural por Id para permitir ordenação.
         */
        public int CompareTo(Pessoa? other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }
    }
}