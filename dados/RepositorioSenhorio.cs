using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Atributos;

namespace Dados
{
    /**
     * @file RepositorioSenhorio.cs
     * @brief Gestão de senhorios.
     */
    public class RepositorioSenhorio
    {
        private List<Senhorio> senhorios = new();

        /**
         * @brief Adiciona um senhorio ao repositório.
        */

        public bool Adicionar(Senhorio senhorio)
        {
            if (senhorio == null)
                return false;

            senhorios.Add(senhorio);
            return true;
        }

        /**
         * @brief Atualiza os dados de um senhorio existente.
        */

        public bool Alterar(int id, Senhorio novosDados)
        {
            var senhorio = ObterPorId(id);
            if (senhorio == null)
                return false;

            senhorio.Nome = novosDados.Nome;
            senhorio.Nif = novosDados.Nif;
            senhorio.Contacto = novosDados.Contacto;
            senhorio.Localidade = novosDados.Localidade;
            senhorio.NumeroImoveis = novosDados.NumeroImoveis;

            return true;
        }

        /**
         * @brief Remove um senhorio pelo seu Id.
        */
        public bool Remover(int id)
        {
            var senhorio = ObterPorId(id);
            if (senhorio == null)
                return false;

            senhorios.Remove(senhorio);
            return true;
        }

        /**
         * @brief Obtém um senhorio pelo seu Id.
        */

        public Senhorio? ObterPorId(int id)
        {
            return senhorios.FirstOrDefault(s => s.Id == id);
        }

        /**
         * @brief Guarda os dados dos senhorios em ficheiro binário.
        */

        public bool GuardarEmBinario(string ficheiro)
        {
            try
            {
#pragma warning disable SYSLIB0011
                using FileStream fs = new FileStream(ficheiro, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, senhorios);
#pragma warning restore SYSLIB0011
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
         * @brief Carrega os dados dos senhorios de um ficheiro binário.
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
                senhorios = (List<Senhorio>)bf.Deserialize(fs);
#pragma warning restore SYSLIB0011

                // Listas dos filhos são [NonSerialized], portanto vêm a null após carregar.
                foreach (var s in senhorios)
                {
                    if (s.Imoveis == null)
                        s.Imoveis = new List<Imovel>();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
         * @brief Lista todos os senhorios.
        */
        public List<Senhorio> Listar()
        {
            return senhorios;
        }
    }
}
