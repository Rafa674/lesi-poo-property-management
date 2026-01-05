using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Atributos;
using Excecoes;

namespace regras
{
    /**
     * @file GestaoDespesa.cs
     * @brief Regras para criar, atualizar, remover e consultar despesas (dentro de Imovel.Despesas).
     */
    public class GestaoDespesa
    {
        private RepositorioImovel dadosImoveis;

        /**
         * @brief Construtor com repositório de imóveis.
         */
        public GestaoDespesa(RepositorioImovel dadosImoveis)
        {
            this.dadosImoveis = dadosImoveis;
        }

        /**
         * @brief Cria uma despesa (valida imóvel e valor).
         */
        public bool Criar(int id, int idImovel, DateTime data, double valor)
        {
            var imovel = dadosImoveis.ObterPorId(idImovel);
            if (imovel == null)
            {
                throw new ImovelNaoEncontrado(idImovel);
            }

            if (valor < 0)
            {
                throw new OperacaoInvalida("Valor da despesa não pode ser negativo.");
            }

            var despesa = new Despesa(id, imovel, data, valor);

            if (imovel.Despesas == null)
            {
                imovel.Despesas = new List<Despesa>();
            }

            imovel.Despesas.Add(despesa);

            return true;
        }

        /**
         * @brief Atualiza uma despesa existente (valida valor).
         */
        public bool Alterar(int idImovel, int idDespesa, DateTime data, double valor)
        {
            var imovel = dadosImoveis.ObterPorId(idImovel);
            if (imovel == null)
            {
                throw new ImovelNaoEncontrado(idImovel);
            }

            if (imovel.Despesas == null)
            {
                imovel.Despesas = new List<Despesa>();
            }

            var despesa = imovel.Despesas.FirstOrDefault(d => d.Id == idDespesa);
            if (despesa == null)
            {
                throw new DespesaNaoEncontrada(idDespesa);
            }

            if (valor < 0)
            {
                throw new OperacaoInvalida("Valor da despesa não pode ser negativo.");
            }

            despesa.Data = data;
            despesa.Valor = valor;

            return true;
        }

        /**
         * @brief Remove uma despesa pelo Id (dentro do imóvel).
         */
        public bool Remover(int idImovel, int idDespesa)
        {
            var imovel = dadosImoveis.ObterPorId(idImovel);
            if (imovel == null)
            {
                throw new ImovelNaoEncontrado(idImovel);
            }

            if (imovel.Despesas == null)
            {
                imovel.Despesas = new List<Despesa>();
            }

            var despesa = imovel.Despesas.FirstOrDefault(d => d.Id == idDespesa);
            if (despesa == null)
            {
                throw new DespesaNaoEncontrada(idDespesa);
            }

            imovel.Despesas.Remove(despesa);
            return true;
        }

        /**
         * @brief Obtém uma despesa pelo Id (dentro do imóvel).
         */
        public Despesa ObterPorId(int idImovel, int idDespesa)
        {
            var imovel = dadosImoveis.ObterPorId(idImovel);
            if (imovel == null)
            {
                throw new ImovelNaoEncontrado(idImovel);
            }

            if (imovel.Despesas == null)
            {
                imovel.Despesas = new List<Despesa>();
            }

            var despesa = imovel.Despesas.FirstOrDefault(d => d.Id == idDespesa);
            if (despesa == null)
            {
                throw new DespesaNaoEncontrada(idDespesa);
            }

            return despesa;
        }

        /**
         * @brief Lista despesas de um imóvel ordenadas por Id.
         */
        public List<Despesa> Listar(int idImovel)
        {
            var imovel = dadosImoveis.ObterPorId(idImovel);
            if (imovel == null)
            {
                throw new ImovelNaoEncontrado(idImovel);
            }

            if (imovel.Despesas == null)
            {
                imovel.Despesas = new List<Despesa>();
            }

            var lista = imovel.Despesas;
            lista.Sort();
            return lista;
        }
    }
}


