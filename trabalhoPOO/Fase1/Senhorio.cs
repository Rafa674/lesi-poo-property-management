using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoPOO.Fase1;

/**
 * @file Senhorio.cs
 * @brief Representa um senhorio (proprietário) de imóveis.
 *
 * Estende a classe Pessoa adicionando o número de imóveis que possui.
 */
public class Senhorio : Pessoa
{
    #region Atributos
    private int numeroImoveis;
    #endregion

    /**
     * @brief Quantidade de imóveis pertencentes ao senhorio.
     */
    public int NumeroImoveis
    {
        get { return numeroImoveis; }
        set { numeroImoveis = value; }
    }

    /**
     * @brief Construtor por omissão.
     */
    public Senhorio() : base() { }

    /**
     * @brief Construtor que inicializa os dados do senhorio.
     * @param id Identificador único.
     * @param nif Número de Identificação Fiscal.
     * @param nome Nome completo.
     * @param contacto Número de contacto telefónico.
     * @param numeroImoveis Quantidade de imóveis do senhorio.
     * @param idLocalidade Identificador da localidade associada.
     */
    public Senhorio(int id, int nif, string nome, int contacto, int numeroImoveis, int idLocalidade)
        : base(id, nif, nome, contacto, idLocalidade)
    {
        NumeroImoveis = numeroImoveis;
    }
}