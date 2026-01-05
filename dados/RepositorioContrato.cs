using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Atributos;

namespace Dados
{
    /**
     * @file RepositorioContrato.cs
     * @brief Gestão de contratos.
     */
    public class RepositorioContrato
    {
        private List<Contrato> contratos = new();

        /**
         *  @brief Adiciona um contrato ao repositório.
        */

        public bool Adicionar(Contrato contrato)
        {
            if (contrato == null)
                return false;

            contratos.Add(contrato);
            return true;
        }

        /**
         *  @brief Atualiza os dados de um contrato existente.
        */

        public bool Alterar(int id, Contrato novosDados)
        {
            var contrato = ObterPorId(id);
            if (contrato == null)
                return false;

            contrato.Senhorio = novosDados.Senhorio;
            contrato.Inquilino = novosDados.Inquilino;
            contrato.Imovel = novosDados.Imovel;
            contrato.DataInicio = novosDados.DataInicio;
            contrato.DataFim = novosDados.DataFim;
            contrato.Estado = novosDados.Estado;

            return true;
        }
        /**
        *  @brief Remove um contrato pelo seu Id.
        */

        public bool Remover(int id)
        {
            var contrato = ObterPorId(id);
            if (contrato == null)
                return false;

            contratos.Remove(contrato);
            return true;
        }

        /**
         * @brief Obtém um contrato pelo seu Id.
        */
        public Contrato? ObterPorId(int id)
        {
            return contratos.FirstOrDefault(c => c.Id == id);
        }

        /**
         * @brief Guarda os contratos num ficheiro binário.
        */

        public bool GuardarEmBinario(string ficheiro)
        {
            try
            {
#pragma warning disable SYSLIB0011
                using FileStream fs = new FileStream(ficheiro, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, contratos);
#pragma warning restore SYSLIB0011
                return true;
            }
            catch
            {
                return false;
            }
        }
        /**
         * @brief Carrega contratos a partir de um ficheiro binário.
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
                contratos = (List<Contrato>)bf.Deserialize(fs);
#pragma warning restore SYSLIB0011

                
                foreach (var c in contratos)
                {
                    if (c.Recibos == null)
                        c.Recibos = new List<Recibo>();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
         * @brief Lista todos os contratos em memória.
        */

        public List<Contrato> Listar()
        {
            return contratos;
        }
    }
}
