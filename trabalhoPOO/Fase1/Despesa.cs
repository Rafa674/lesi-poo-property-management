using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoPOO.Fase1;

/**
 * @file Despesa.cs
 * @brief Representa uma despesa associada a um imóvel.
 *
 * Inclui referência ao imóvel, data e valor.
 */
public class Despesa
{
    #region Atributos
    private int id;
    private int idImovel;
    private DateTime data;
    private double valor;
    #endregion

    /**
     * @brief Identificador único da despesa.
     */
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    /**
     * @brief Identificador do imóvel ao qual a despesa pertence.
     */
    public int IdImovel
    {
        get { return idImovel; }
        set { idImovel = value; }
    }

    /**
     * @brief Data em que ocorreu a despesa.
     */
    public DateTime Data
    {
        get { return data; }
        set { data = value; }
    }

    /**
     * @brief Valor monetário da despesa.
     */
    public double Valor
    {
        get { return valor; }
        set { valor = value; }
    }

    /**
     * @brief Construtor por omissão.
     */
    public Despesa() { }

    /**
     * @brief Construtor que inicializa os dados da despesa.
     * @param id Identificador único.
     * @param idImovel Identificador do imóvel relacionado.
     * @param data Data da despesa.
     * @param valor Valor monetário.
     */
    public Despesa(int id, int idImovel, DateTime data, double valor)
    {
        Id = id;
        IdImovel = idImovel;
        Data = data;
        Valor = valor;
    }
}
