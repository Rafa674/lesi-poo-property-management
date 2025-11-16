using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoPOO.Fase1;

/**
 * @file Localidade.cs
 * @brief Representa uma localidade (endereço físico).
 *
 * Inclui código postal, rua e número de porta.
 */
public class Localidade
{
    #region Atributos
    private int id;
    private string codigoPostal;
    private string rua;
    private int numeroPorta;
    #endregion

    /**
     * @brief Identificador único da localidade.
     */
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    /**
     * @brief Código postal associado.
     */
    public string CodigoPostal
    {
        get { return codigoPostal; }
        set { codigoPostal = value; }
    }

    /**
     * @brief Nome da rua.
     */
    public string Rua
    {
        get { return rua; }
        set { rua = value; }
    }

    /**
     * @brief Número de porta.
     */
    public int NumeroPorta
    {
        get { return numeroPorta; }
        set { numeroPorta = value; }
    }

    /**
     * @brief Construtor por omissão.
     */
    public Localidade() { }

    /**
     * @brief Construtor que inicializa os dados da localidade.
     * @param id Identificador único.
     * @param codigoPostal Código postal.
     * @param rua Nome da rua.
     * @param numeroPorta Número de porta.
     */
    public Localidade(int id, string codigoPostal, string rua, int numeroPorta)
    {
        Id = id;
        CodigoPostal = codigoPostal;
        Rua = rua;
        NumeroPorta = numeroPorta;
    }
}