using System;
using System.Collections.Generic;

namespace Atributos
{
    /**
     * @file Contrato.cs
     * @brief Representa um contrato de arrendamento.
     *
     * Liga `Senhorio`, `Inquilino` e `Imovel` num período de arrendamento.
     *
     * Agregação:
     * - Um contrato tem vários recibos.
     */
    [Serializable]
    public class Contrato : IComparable<Contrato>
    {
        #region Atributos
        private int id;
        [NonSerialized]
        private Senhorio senhorio;
        [NonSerialized]
        private Inquilino inquilino;
        [NonSerialized]
        private Imovel imovel;
        private DateTime dataInicio;
        private DateTime dataFim;
        private int estado; // 1=Ativo, 2=Desativo
        private List<Recibo> recibos;
        #endregion

        /**
         * @brief Identificador único do contrato.
         */
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /**
         * @brief Senhorio do contrato.
         */
        public Senhorio Senhorio
        {
            get { return senhorio; }
            set { senhorio = value; }
        }

        /**
         * @brief Inquilino do contrato.
         */
        public Inquilino Inquilino
        {
            get { return inquilino; }
            set { inquilino = value; }
        }

        /**
         * @brief Imóvel arrendado.
         */
        public Imovel Imovel
        {
            get { return imovel; }
            set { imovel = value; }
        }

        /**
         * @brief Data de início do contrato.
         */
        public DateTime DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }
        }

        /**
         * @brief Data de fim do contrato.
         */
        public DateTime DataFim
        {
            get { return dataFim; }
            set { dataFim = value; }
        }

        /**
         * @brief Estado do contrato (1=Ativo, 2=Desativo).
         */
        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        /**
         * @brief Recibos do contrato.
         */
        public List<Recibo> Recibos
        {
            get { return recibos; }
            set { recibos = value; }
        }

        /**
         * @brief Construtor por omissão.
         */
        public Contrato()
        {
            recibos = new List<Recibo>();
        }

        /**
         * @brief Construtor completo.
         */
        public Contrato(int id, Senhorio senhorio, Inquilino inquilino, Imovel imovel, DateTime dataInicio, DateTime dataFim, int estado)
        {
            Id = id;
            Senhorio = senhorio;
            Inquilino = inquilino;
            Imovel = imovel;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Estado = estado;
            recibos = new List<Recibo>();
        }

        /**
         * @brief Comparação natural por ID.
         */
        public int CompareTo(Contrato? other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }
    }
}