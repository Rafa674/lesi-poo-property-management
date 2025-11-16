using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoPOO.Fase1;

/**
 * @file Imovel.cs
 * @brief Representa um imóvel (apartamento ou vivenda) com estado e localização.
 *
 * Contém tipo, área, renda mensal, estado, referência à localidade e ao senhorio, e uma descrição.
 */
public class Imovel
{
    #region Atributos
    private int id;
    private string tipo;        // apartamento, vivenda
    private double area;
    private double rendaMensal;
    private string estado;      // Livre, Ocupado, Manutencao
    private int idLocalidade;   // referência à localidade
    private int idSenhorio;
    private string descricao;
    #endregion

    /**
     * @brief Identificador único do imóvel.
     */
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    /**
     * @brief Tipo do imóvel (ex.: apartamento, vivenda).
     */
    public string Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }

    /**
     * @brief Área total do imóvel em metros quadrados.
     */
    public double Area
    {
        get { return area; }
        set { area = value; }
    }

    /**
     * @brief Valor da renda mensal.
     */
    public double RendaMensal
    {
        get { return rendaMensal; }
        set { rendaMensal = value; }
    }

    /**
     * @brief Estado atual (Livre, Ocupado, Manutencao).
     */
    public string Estado
    {
        get { return estado; }
        set { estado = value; }
    }

    /**
     * @brief Identificador da localidade onde se encontra.
     */
    public int IdLocalidade
    {
        get { return idLocalidade; }
        set { idLocalidade = value; }
    }

    /**
     * @brief Identificador do senhorio proprietário.
     */
    public int IdSenhorio
    {
        get { return idSenhorio; }
        set { idSenhorio = value; }
    }

    /**
     * @brief Descrição textual do imóvel.
     */
    public string Descricao
    {
        get { return descricao; }
        set { descricao = value; }
    }

    /**
     * @brief Construtor por omissão.
     */
    public Imovel() { }

    /**
     * @brief Construtor que inicializa todos os dados do imóvel.
     * @param id Identificador único.
     * @param tipo Tipo (apartamento, vivenda).
     * @param area Área em m².
     * @param rendaMensal Valor da renda mensal.
     * @param estado Estado atual.
     * @param idLocalidade Identificador da localidade.
     * @param idSenhorio Identificador do senhorio.
     * @param descricao Texto descritivo.
     */
    public Imovel(int id, string tipo, double area, double rendaMensal, string estado, int idLocalidade, int idSenhorio, string descricao)
    {
        Id = id;
        Tipo = tipo;
        Area = area;
        RendaMensal = rendaMensal;
        Estado = estado;
        IdLocalidade = idLocalidade;
        IdSenhorio = idSenhorio;
        Descricao = descricao;
    }
}
