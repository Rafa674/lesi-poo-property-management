using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Atributos;

namespace Dados
{
    /**
     * @file RepositorioInquilino.cs
     * @brief Gestão de inquilinos.
     */
    public class RepositorioInquilino
    {
        private List<Inquilino> inquilinos;

        public RepositorioInquilino()
        {
            inquilinos = new List<Inquilino>();
        }

        /**
         * @brief Adiciona um inquilino ao repositório.
        */

        public bool Adicionar(Inquilino inquilino)
        {
            if (inquilino == null)
                return false;
            
            inquilinos.Add(inquilino);
            return true;
        }

        /**
         * @brief Atualiza os dados de um inquilino existente.
        */
        public bool Alterar(int id, Inquilino novosDados)
        {
            var inquilino = ObterPorId(id);
            if (inquilino == null)
                return false;

            inquilino.Nome = novosDados.Nome;
            inquilino.Nif = novosDados.Nif;
            inquilino.Contacto = novosDados.Contacto;
            inquilino.Localidade = novosDados.Localidade;
            inquilino.Profissao = novosDados.Profissao;
            inquilino.RendimentoMensal = novosDados.RendimentoMensal;

            return true;
        }

        /**
         * @brief Remove um inquilino pelo seu Id.
        */

        public bool Remover(int id)
        {
            var inquilino = ObterPorId(id);
            if (inquilino == null)
                return false;

            inquilinos.Remove(inquilino);
            return true;
        }

        /**
         * @brief Obtém um inquilino pelo seu Id.
        */

        public Inquilino ObterPorId(int id)
        {
            foreach (Inquilino i in inquilinos)
            {
                if (i.Id == id)
                {
                    return i;
                }

            } 
            return null;
        }   
        

        /**
         * @brief Guarda a lista de inquilinos em formato binário.
        */

        public bool GuardarEmBinario(string ficheiro)
        {
            try
            {
#pragma warning disable SYSLIB0011
                using FileStream fs = new FileStream(ficheiro, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, inquilinos);
#pragma warning restore SYSLIB0011
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
         * @brief Carrega a lista de inquilinos a partir de um ficheiro binário.
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
                inquilinos = (List<Inquilino>)bf.Deserialize(fs);
#pragma warning restore SYSLIB0011
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**
         * @brief Lista todos os inquilinos.
        */

        public List<Inquilino> Listar()
        {
            return inquilinos;
        }
    }
}
