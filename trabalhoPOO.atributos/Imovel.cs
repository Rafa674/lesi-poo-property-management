using System;
using System.Collections.Generic;

namespace Atributos
{
    /**
     * @file Imovel.cs
     * @brief Representa um imóvel.
     *
     * Guarda dados do imóvel e a sua localidade.
     *
     * Agregação:
     * - Um imóvel tem várias despesas.
     */
    [Serializable]
    public class Imovel : IComparable<Imovel>
    {
        #region Atributos
        private int id;
        private int tipo;        // 1=Apartamento, 2=Vivenda
        private double area;
        private double rendaMensal;
        private int estado;      // 1=Livre, 2=Ocupado, 3=Manutenção
        private Localidade localidade;
        private string descricao;
        [NonSerialized]
        private Senhorio senhorio;
        [NonSerialized]
        private List<Despesa> despesas;
        
        #endregion

        /**
         * @brief Identificador único do imóvel.
         */
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /**
         * @brief Tipo do imóvel.
         */
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        /**
         * @brief Área do imóvel.
         */
        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        /**
         * @brief Renda mensal do imóvel.
         */
        public double RendaMensal
        {
            get { return rendaMensal; }
            set { rendaMensal = value; }
        }

        /**
         * @brief Estado do imóvel.
         */
        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        /**
         * @brief Localidade do imóvel.
         */
        public Localidade Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }

        /**
         * @brief Descrição do imóvel.
         */
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        /**
         * @brief Despesas associadas ao imóvel.
         */
        public List<Despesa> Despesas
        {
            get { return despesas; }
            set { despesas = value; }
        }

        /**
         * @brief Senhorio do imóvel.
         */
        public Senhorio Senhorio
        {
            get { return senhorio; }
            set { senhorio = value; }
        }

        /**
         * @brief Construtor por omissão.
         */
        public Imovel()
        {
            despesas = new List<Despesa>();
        }

        /**
         * @brief Construtor completo.
         */
        public Imovel(int id, int tipo, double area, double rendaMensal, int estado, Localidade localidade, string descricao, Senhorio senhorio)
        {
            Id = id;
            Tipo = tipo;
            Area = area;
            RendaMensal = rendaMensal;
            Estado = estado;
            Localidade = localidade;
            Descricao = descricao;
            Senhorio = senhorio;
            despesas = new List<Despesa>();
        }


        /**
         * @brief Comparação natural por ID.
         */
        public int CompareTo(Imovel? other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }
    }
}
