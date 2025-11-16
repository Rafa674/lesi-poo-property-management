using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoPOO.Fase1;

/**
 * @file Contrato.cs
 * @brief Representa um contrato de arrendamento entre um inquilino e um senhorio.
 *
 * Contém datas de início e fim e referências ao senhorio, inquilino e imóvel.
 */
public class Contrato
{
    #region Atributos
    private int id;
    private int idSenhorio;
    private int idInquilino;
    private int idImovel;
    private DateTime dataInicio;
    private DateTime dataFim;
    #endregion

    /**
     * @brief Identificador único do contrato.
     */
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    /**
     * @brief Identificador do senhorio envolvido.
     */
    public int IdSenhorio
    {
        get { return idSenhorio; }
        set { idSenhorio = value; }
    }

    /**
     * @brief Identificador do inquilino envolvido.
     */
    public int IdInquilino
    {
        get { return idInquilino; }
        set { idInquilino = value; }
    }

    /**
     * @brief Identificador do imóvel arrendado.
     */
    public int IdImovel
    {
        get { return idImovel; }
        set { idImovel = value; }
    }

    /**
     * @brief Data de início do contrato.
     */
    public DateTime DataInicio
    {
        get { return dataInicio; }
        set { dataInicio = value; }
    }

    /**
     * @brief Data de fim do contrato.
     */
    public DateTime DataFim
    {
        get { return dataFim; }
        set { dataFim = value; }
    }

    /**
     * @brief Construtor por omissão.
     */
    public Contrato() { }

    /**
     * @brief Construtor que inicializa os dados do contrato.
     * @param id Identificador único.
     * @param idSenhorio Identificador do senhorio.
     * @param idInquilino Identificador do inquilino.
     * @param idImovel Identificador do imóvel.
     * @param dataInicio Data de início.
     * @param datafim Data de fim.
     */
    public Contrato(int id, int idSenhorio, int idInquilino, int idImovel, DateTime dataInicio, DateTime datafim)
    {
        Id = id;
        IdSenhorio = idSenhorio;
        IdInquilino = idInquilino;
        IdImovel = idImovel;
        DataInicio = dataInicio;
        DataFim = datafim;
    }
}