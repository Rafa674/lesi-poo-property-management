using System;
using System.Collections.Generic;
using Dados;
using Atributos;
using Excecoes;

namespace regras
{
    /**
     * @file GestaoImovel.cs
     * @brief Regras para criar, atualizar, remover e consultar imóveis.
     */
    public class GestaoImovel
    {
        private RepositorioImovel dadosImoveis;

        /**
         * @brief Construtor com repositório de imóveis.
         */
        public GestaoImovel(RepositorioImovel repositorio)
        {
            dadosImoveis = repositorio;
        }

        /**
         * @brief Cria um imóvel (valida tipo, área e renda).
         */
        public bool Criar(int id, int tipo, double area, double rendaMensal, int estado, Localidade localidade, string descricao, Senhorio senhorio)
        {
            if (tipo != 1 && tipo != 2)
            {
                throw new OperacaoInvalida("Tipo do imóvel inválido. Use 1=Apartamento ou 2=Vivenda.");
            }

            if (area <= 0)
            {
                throw new OperacaoInvalida("Área inválida.");
            }

            if (senhorio == null)
            {
                throw new OperacaoInvalida("Senhorio do imóvel é obrigatório.");
            }

            var imovel = new Imovel(id, tipo, area, rendaMensal, estado, localidade, descricao, senhorio);

            dadosImoveis.Adicionar(imovel);

            if (senhorio.Imoveis == null)
                senhorio.Imoveis = new List<Imovel>();

            senhorio.Imoveis.Add(imovel);

            return true;
        }

        /**
         * @brief Atualiza um imóvel existente (valida entrada).
         */
        public bool Alterar(int id, int tipo, double area, double rendaMensal, int estado, Localidade localidade, string descricao, Senhorio senhorio)
        {
            var existente = dadosImoveis.ObterPorId(id);
            if (existente == null)
            {
                throw new ImovelNaoEncontrado(id);
            }

            if (tipo != 1 && tipo != 2)
            {
                throw new OperacaoInvalida("Tipo do imóvel inválido. Use 1=Apartamento ou 2=Vivenda.");
            }

            if (area <= 0)
            {
                throw new OperacaoInvalida("Área inválida.");
            }

            if (senhorio == null)
            {
                throw new OperacaoInvalida("Senhorio do imóvel é obrigatório.");
            }

            var novosDados = new Imovel(id, tipo, area, rendaMensal, estado, localidade, descricao, senhorio);

            dadosImoveis.Alterar(id, novosDados);
            return true;
        }

        /**
         * @brief Remove um imóvel pelo Id.
         */
        public bool Remover(int id)
        {
            var existente = dadosImoveis.ObterPorId(id);
            if (existente == null)
            {
                throw new ImovelNaoEncontrado(id);
            }

            if (existente.Senhorio != null && existente.Senhorio.Imoveis != null)
            {
                existente.Senhorio.Imoveis.Remove(existente);
            }

            dadosImoveis.Remover(id);
            return true;
        }

        /**
         * @brief Lista todos os imóveis ordenados por Id.
         */
        public List<Imovel> Listar()
        {
            var lista = dadosImoveis.Listar();
            lista.Sort();
            return lista;
        }
    }
}

