using System;
using System.Collections.Generic;

namespace Atributos
{
    /**
     * @file Recibo.cs
     * @brief Representa um recibo.
     *
     * Contém dados do pagamento (estado, data e método).
     *
     * Agregação:
     * - O recibo é guardado dentro de `Contrato.Recibos`.
     */
    [Serializable]
    public class Recibo : IComparable<Recibo>
    {
        #region Atributos
        private int id;
        private DateTime dataEmissao;
        private int mesReferencia;
        private int anoReferencia;
        private double valorPagamento;
        private int estado; // 1=Pendente, 2=Pago
        private DateTime dataPagamento;
        private int metodoPagamento; // 1=Transferência, 2=MB Way, 3=Numerário
        [NonSerialized]
        private Contrato contrato;
        #endregion

        /**
         * @brief Identificador único do recibo.
         */
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /**
         * @brief Data de emissão do recibo.
         */
        public DateTime DataEmissao
        {
            get { return dataEmissao; }
            set { dataEmissao = value; }
        }

        /**
         * @brief Mês de referência (1-12).
         */
        public int MesReferencia
        {
            get { return mesReferencia; }
            set { mesReferencia = value; }
        }

        /**
         * @brief Ano de referência.
         */
        public int AnoReferencia
        {
            get { return anoReferencia; }
            set { anoReferencia = value; }
        }


        /**
         * @brief Contrato associado ao recibo.
         */
        public Contrato Contrato
        {
            get { return contrato; }
            set { contrato = value; }
        }

        /**
         * @brief Valor do recibo.
         */
        public double ValorPagamento
        {
            get { return valorPagamento; }
            set { valorPagamento = value; }
        }

        /**
         * @brief Estado do recibo (1=Pendente, 2=Pago).
         */
        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        /**
         * @brief Data de pagamento (se aplicável).
         */
        public DateTime DataPagamento
        {
            get { return dataPagamento; }
            set { dataPagamento = value; }
        }

        /**
         * @brief Método de pagamento (1=Transferência, 2=MB Way, 3=Numerário).
         */
        public int MetodoPagamento
        {
            get { return metodoPagamento; }
            set { metodoPagamento = value; }
        }

        /**
         * @brief Construtor por omissão.
         */
        public Recibo() { }

        /**
         * @brief Construtor completo.
         */
        public Recibo(int id, Contrato contrato, DateTime dataEmissao, int mesReferencia, int anoReferencia,
                      double valorPagamento, int estado, DateTime dataPagamento, int metodoPagamento)
        {
            Id = id;
            Contrato = contrato;
            DataEmissao = dataEmissao;
            MesReferencia = mesReferencia;
            AnoReferencia = anoReferencia;
            ValorPagamento = valorPagamento;
            Estado = estado;
            DataPagamento = dataPagamento;
            MetodoPagamento = metodoPagamento;
        }

        /**
         * @brief Comparação natural por ID.
         */
        public int CompareTo(Recibo? other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }
    }
}