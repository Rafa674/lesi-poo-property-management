using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoPOO.Fase1;

/**
 * @file Pessoa.cs
 * @brief Classe base abstrata para entidades que representam pessoas (Senhorio, Inquilino).
 *
 * Contém propriedades comuns: identificador, NIF, nome, contacto telefónico e referência à localidade.
 */
public abstract class Pessoa
{
    #region Atributos
    private int id;
    private int nif;
    private string nome;
    private int contacto;
    private int idLocalidade;
    #endregion

    /**
     * @brief Identificador único da pessoa.
     */
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    /**
     * @brief Número de Identificação Fiscal (NIF).
     */
    public int Nif
    {
        get { return nif; }
        set { nif = value; }
    }

    /**
     * @brief Nome completo da pessoa.
     */
    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    /**
     * @brief Número de contacto telefónico.
     */
    public int Contacto
    {
        get { return contacto; }
        set { contacto = value; }
    }

    /**
     * @brief Identificador da localidade associada.
     */
    public int IdLocalidade
    {
        get { return idLocalidade; }
        set { idLocalidade = value; }
    }

    /**
     * @brief Construtor público por omissão.
     */
    public Pessoa() { }

    /**
     * @brief Construtor que inicializa os dados principais da pessoa.
     * @param id Identificador único.
     * @param nif Número de Identificação Fiscal.
     * @param nome Nome completo.
     * @param contacto Número de contacto telefónico.
     * @param idLocalidade Identificador da localidade associada.
     */
    public Pessoa(int id, int nif, string nome, int contacto, int idLocalidade)
    {
        Id = id;
        Nif = nif;
        Nome = nome;
        Contacto = contacto;
        IdLocalidade = idLocalidade;
    }
}