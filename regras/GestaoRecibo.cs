using System;
using System.Collections.Generic;
using System.Linq;
using Atributos;
using Dados;
using Excecoes;

namespace regras
{
    /**
     * @file GestaoRecibo.cs
     * @brief Regras para criar, atualizar, remover e consultar recibos (dentro de Contrato.Recibos).
     */
    public class GestaoRecibo
    {
        private RepositorioContrato dadosContratos;

        /**
         * @brief Construtor com repositório de contratos.
         */
        public GestaoRecibo(RepositorioContrato dadosContratos)
        {
            this.dadosContratos = dadosContratos;
        }

        /**
         * @brief Cria um recibo (valida valor positivo).
         */
        public bool Criar(int id, int idContrato, DateTime dataEmissao, int mes, int ano, double valor, int estado, DateTime dataPagamento, int metodoPagamento)
        {
            var contrato = dadosContratos.ObterPorId(idContrato);
            if (contrato == null)
            {
                throw new ContratoNaoEncontrado(idContrato);
            }

            if (valor <= 0)
            {
                throw new OperacaoInvalida("O valor do recibo deve ser positivo.");
            }

            var recibo = new Recibo(id, contrato, dataEmissao, mes, ano, valor, estado, dataPagamento, metodoPagamento);

            if (contrato.Recibos == null)
            {
                contrato.Recibos = new List<Recibo>();
            }

            contrato.Recibos.Add(recibo);

            return true;
        }

        /**
         * @brief Atualiza um recibo existente (valida valor).
         */
        public bool Alterar(int idContrato, int idRecibo, int estado, DateTime dataPagamento, int metodoPagamento, double valor)
        {
            var contrato = dadosContratos.ObterPorId(idContrato);
            if (contrato == null)
            {
                throw new ContratoNaoEncontrado(idContrato);
            }

            if (contrato.Recibos == null)
            {
                contrato.Recibos = new List<Recibo>();
            }

            var recibo = contrato.Recibos.FirstOrDefault(r => r.Id == idRecibo);
            if (recibo == null)
            {
                throw new ReciboNaoEncontrado(idRecibo);
            }

            if (valor < 0)
            {
                throw new OperacaoInvalida("Valor do recibo deve ser positivo.");
            }

            recibo.Estado = estado;
            recibo.DataPagamento = dataPagamento;
            recibo.MetodoPagamento = metodoPagamento;
            recibo.ValorPagamento = valor;

            return true;
        }

        /**
         * @brief Remove um recibo pelo Id (dentro do contrato).
         */
        public bool Remover(int idContrato, int idRecibo)
        {
            var contrato = dadosContratos.ObterPorId(idContrato);
            if (contrato == null)
            {
                throw new ContratoNaoEncontrado(idContrato);
            }

            if (contrato.Recibos == null)
            {
                contrato.Recibos = new List<Recibo>();
            }

            var recibo = contrato.Recibos.FirstOrDefault(r => r.Id == idRecibo);
            if (recibo == null)
            {
                throw new ReciboNaoEncontrado(idRecibo);
            }

            contrato.Recibos.Remove(recibo);
            return true;
        }

        /**
         * @brief Obtém um recibo pelo Id (dentro do contrato).
         */
        public Recibo ObterPorId(int idContrato, int idRecibo)
        {
            var contrato = dadosContratos.ObterPorId(idContrato);
            if (contrato == null)
            {
                throw new ContratoNaoEncontrado(idContrato);
            }

            if (contrato.Recibos == null)
            {
                contrato.Recibos = new List<Recibo>();
            }

            var recibo = contrato.Recibos.FirstOrDefault(r => r.Id == idRecibo);
            if (recibo == null)
            {
                throw new ReciboNaoEncontrado(idRecibo);
            }

            return recibo;
        }

        /**
         * @brief Lista recibos de um contrato ordenados por Id.
         */
        public List<Recibo> Listar(int idContrato)
        {
            var contrato = dadosContratos.ObterPorId(idContrato);
            if (contrato == null)
            {
                throw new ContratoNaoEncontrado(idContrato);
            }

            if (contrato.Recibos == null)
            {
                contrato.Recibos = new List<Recibo>();
            }

            var lista = contrato.Recibos;
            lista.Sort();
            return lista;
        }
    }
}
