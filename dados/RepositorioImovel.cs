using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Atributos;

namespace Dados
{
    /**
     * @file RepositorioImovel.cs
     * @brief Gestão de imóveis.
     */
    public class RepositorioImovel
    {
        private List<Imovel> imoveis = new();

        /**
         * @brief Adiciona um imóvel ao repositório.
        */

        public bool Adicionar(Imovel imovel)
        {
            if (imovel == null)
                return false;

            imoveis.Add(imovel);
            return true;
        }

        /**
         * @brief Atualiza os dados de um imóvel existente.
        */

        public bool Alterar(int id, Imovel novosDados)
        {
            var imovel = ObterPorId(id);
            if (imovel == null)
                return false;

            imovel.Tipo = novosDados.Tipo;
            imovel.Area = novosDados.Area;
            imovel.RendaMensal = novosDados.RendaMensal;
            imovel.Estado = novosDados.Estado;
            imovel.Localidade = novosDados.Localidade;
            imovel.Descricao = novosDados.Descricao;
            imovel.Senhorio = novosDados.Senhorio;

            return true;
        }

        /**
         * @brief Remove um imóvel pelo seu Id.
        */

        public bool Remover(int id)
        {
            var imovel = ObterPorId(id);
            if (imovel == null)
                return false;

            imoveis.Remove(imovel);
            return true;
        }

        /** 
         * @brief Obtém um imóvel pelo seu Id.
        */

        public Imovel ObterPorId(int id)
        {
            foreach (Imovel s in imoveis)
            {
                if (s.Id == id)
                {
                    return s;
                }
            }

            return null;
        }


        /**
         * @brief Guarda a lista de imóveis em ficheiro binário.
        */

        public bool GuardarEmBinario(string ficheiro)
        {
            try
            {
#pragma warning disable SYSLIB0011
                using FileStream fs = new FileStream(ficheiro, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, imoveis);
#pragma warning restore SYSLIB0011
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
         * @brief Carrega a lista de imóveis de um ficheiro binário.
        */

        public bool CarregarDeBinario(string ficheiro)
        {
            try
            {
                if (!File.Exists(ficheiro))
                    return false;

#pragma warning disable SYSLIB0011
                using FileStream fs = new FileStream(ficheiro, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                imoveis = (List<Imovel>)bf.Deserialize(fs);
#pragma warning restore SYSLIB0011

                
                foreach (var i in imoveis)
                {
                    if (i.Despesas == null)
                        i.Despesas = new List<Despesa>();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
         * @brief Lista todos os imóveis.
        */

        public List<Imovel> Listar()
        {
            return imoveis;
        }
    }
}