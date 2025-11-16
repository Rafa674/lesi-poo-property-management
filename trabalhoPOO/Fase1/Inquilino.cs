using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalhoPOO.Fase1;

/**
 * @file Inquilino.cs
 * @brief Representa um inquilino que arrenda imóveis.
 *
 * Estende a classe Pessoa adicionando profissão e rendimento mensal.
 */
public class Inquilino : Pessoa
{
    #region Atributos
    private string profissao;
    private double rendimentoMensal;
    #endregion

    /**
     * @brief Profissão do inquilino.
     */
    public string Profissao
    {
        get { return profissao; }
        set { profissao = value; }
    }

    /**
     * @brief Rendimento mensal declarado do inquilino.
     */
    public double RendimentoMensal
    {
        get { return rendimentoMensal; }
        set { rendimentoMensal = value; }
    }

    /**
     * @brief Construtor por omissão.
     */
    public Inquilino() : base() { }

    /**
     * @brief Construtor que inicializa os dados do inquilino.
     * @param id Identificador único.
     * @param nif Número de Identificação Fiscal.
     * @param nome Nome completo.
     * @param contacto Número de contacto telefónico.
     * @param profissao Profissão exercida.
     * @param rendimentoMensal Valor do rendimento mensal.
     * @param idLocalidade Identificador da localidade associada.
     */
    public Inquilino(int id, int nif, string nome, int contacto, string profissao, double rendimentoMensal, int idLocalidade)
        : base(id, nif, nome, contacto, idLocalidade)
    {
        Profissao = profissao;
        RendimentoMensal = rendimentoMensal;
    }
}


