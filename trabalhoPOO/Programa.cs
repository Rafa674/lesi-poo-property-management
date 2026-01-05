using System;
using System.Linq;
using Atributos;
using Dados;
using regras;
using Excecoes;

namespace Aplicacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // REPOSITÓRIOS 
            var repoInquilino = new RepositorioInquilino();
            var repoSenhorio = new RepositorioSenhorio();
            var repoImovel = new RepositorioImovel();
            var repoContrato = new RepositorioContrato();

            // CARREGAR BINÁRIO
            repoInquilino.CarregarDeBinario("inquilinos.dat");
            repoSenhorio.CarregarDeBinario("senhorios.dat");
            repoImovel.CarregarDeBinario("imoveis.dat");
            repoContrato.CarregarDeBinario("contratos.dat");

            // GESTÕES 
            var gInq = new GestaoInquilino(repoInquilino);
            var gSen = new GestaoSenhorio(repoSenhorio);
            var gImo = new GestaoImovel(repoImovel);
            var gCon = new GestaoContrato(repoContrato);
            var gRec = new GestaoRecibo(repoContrato);
            var gDes = new GestaoDespesa(repoImovel);

            // IDS (MAX + 1) 
            int idInq = repoInquilino.Listar().Count == 0 ? 1 : repoInquilino.Listar().Max(x => x.Id) + 1;
            int idSen = repoSenhorio.Listar().Count == 0 ? 1 : repoSenhorio.Listar().Max(x => x.Id) + 1;
            int idImo = repoImovel.Listar().Count == 0 ? 1 : repoImovel.Listar().Max(x => x.Id) + 1;
            int idCon = repoContrato.Listar().Count == 0 ? 1 : repoContrato.Listar().Max(x => x.Id) + 1;

            // Recibo/Despesa: calcular "MAX + 1" após carregar binário
            // (usando exatamente a ideia do: int idRecContrato = 1; ... contrato.Recibos.Max(...) + 1;)
            int idRec = 1;
            foreach (var contrato in repoContrato.Listar())
            {
                int idRecContrato = 1;
                if (contrato.Recibos != null && contrato.Recibos.Count > 0)
                    idRecContrato = contrato.Recibos.Max(r => r.Id) + 1;

                if (idRecContrato > idRec)
                    idRec = idRecContrato;
            }

            int idDes = 1;
            foreach (var imovel in repoImovel.Listar())
            {
                int idDesImovel = 1;
                if (imovel.Despesas != null && imovel.Despesas.Count > 0)
                    idDesImovel = imovel.Despesas.Max(d => d.Id) + 1;

                if (idDesImovel > idDes)
                    idDes = idDesImovel;
            }

            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Gestão de Arrendamentos ===");
                Console.WriteLine("1  Criar Inquilino");
                Console.WriteLine("2  Alterar Inquilino");
                Console.WriteLine("3  Remover Inquilino");
                Console.WriteLine("4  Listar Inquilinos");
                Console.WriteLine("5  Criar Senhorio");
                Console.WriteLine("6  Alterar Senhorio");
                Console.WriteLine("7  Remover Senhorio");
                Console.WriteLine("8  Listar Senhorios");
                Console.WriteLine("9  Criar Imóvel");
                Console.WriteLine("10 Alterar Imóvel");
                Console.WriteLine("11 Remover Imóvel");
                Console.WriteLine("12 Listar Imóveis");
                Console.WriteLine("13 Criar Contrato");
                Console.WriteLine("14 Alterar Contrato");
                Console.WriteLine("15 Remover Contrato");
                Console.WriteLine("16 Listar Contratos");
                Console.WriteLine("17 Criar Recibo");
                Console.WriteLine("18 Alterar Recibo");
                Console.WriteLine("19 Remover Recibo");
                Console.WriteLine("20 Listar Recibos");
                Console.WriteLine("21 Criar Despesa");
                Console.WriteLine("22 Alterar Despesa");
                Console.WriteLine("23 Remover Despesa");
                Console.WriteLine("24 Listar Despesas");
                Console.WriteLine("25 Guardar tudo");
                Console.WriteLine("0  Sair");
                Console.Write("Opção: ");

                if (!int.TryParse(Console.ReadLine(), out op))
                {
                    Console.WriteLine("Opção inválida.");
                    Console.ReadLine();
                    continue;
                }

                try
                {
                    switch (op)
                    {
                        case 1: // Criar Inquilino
                        {
                            Console.Write("Nome: ");
                            string nome = Console.ReadLine();

                            Console.Write("NIF: ");
                            int nif = int.Parse(Console.ReadLine());

                            Console.Write("Contacto: ");
                            int contacto = int.Parse(Console.ReadLine());

                            Console.Write("Profissão: ");
                            string profissao = Console.ReadLine();

                            Console.Write("Rendimento: ");
                            double rendimento = double.Parse(Console.ReadLine());

                            Console.Write("Distrito: ");
                            string distrito = Console.ReadLine();
                            Console.Write("Concelho: ");
                            string concelho = Console.ReadLine();
                            Console.Write("Freguesia: ");
                            string freguesia = Console.ReadLine();

                            var localidade = new Localidade(distrito, concelho, freguesia);

                            gInq.Criar(idInq++, nif, nome, contacto, profissao, rendimento, localidade);
                            Console.WriteLine("Inquilino criado.");
                            break;
                        }

                        case 2: // Alterar Inquilino
                        {
                            Console.Write("Id do inquilino: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("Nome: ");
                            string nome = Console.ReadLine();

                            Console.Write("NIF: ");
                            int nif = int.Parse(Console.ReadLine());

                            Console.Write("Contacto: ");
                            int contacto = int.Parse(Console.ReadLine());

                            Console.Write("Profissão: ");
                            string profissao = Console.ReadLine();

                            Console.Write("Rendimento: ");
                            double rendimento = double.Parse(Console.ReadLine());

                            Console.Write("Distrito: ");
                            string distrito = Console.ReadLine();
                            Console.Write("Concelho: ");
                            string concelho = Console.ReadLine();
                            Console.Write("Freguesia: ");
                            string freguesia = Console.ReadLine();

                            var localidade = new Localidade(distrito, concelho, freguesia);

                            gInq.Alterar(id, nif, nome, contacto, profissao, rendimento, localidade);
                            Console.WriteLine("Inquilino alterado.");
                            break;
                        }

                        case 3: // Remover Inquilino
                        {
                            Console.Write("Id do inquilino: ");
                            int id = int.Parse(Console.ReadLine());
                            gInq.Remover(id);
                            Console.WriteLine("Inquilino removido.");
                            break;
                        }

                        case 4: // Listar Inquilinos
                        {
                            foreach (var x in gInq.Listar())
                                Console.WriteLine($"{x.Id} - {x.Nome}");
                            break;
                        }

                        case 5: // Criar Senhorio
                        {
                            Console.Write("Nome: ");
                            string nome = Console.ReadLine();

                            Console.Write("NIF: ");
                            int nif = int.Parse(Console.ReadLine());

                            Console.Write("Contacto: ");
                            int contacto = int.Parse(Console.ReadLine());

                            Console.Write("Número de imóveis: ");
                            int numeroImoveis = int.Parse(Console.ReadLine());

                            Console.Write("Distrito: ");
                            string distrito = Console.ReadLine();
                            Console.Write("Concelho: ");
                            string concelho = Console.ReadLine();
                            Console.Write("Freguesia: ");
                            string freguesia = Console.ReadLine();

                            var localidade = new Localidade(distrito, concelho, freguesia);

                            gSen.Criar(idSen++, nif, nome, contacto, localidade, numeroImoveis);
                            Console.WriteLine("Senhorio criado.");
                            break;
                        }

                        case 6: // Alterar Senhorio
                        {
                            Console.Write("Id do senhorio: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("Nome: ");
                            string nome = Console.ReadLine();

                            Console.Write("NIF: ");
                            int nif = int.Parse(Console.ReadLine());

                            Console.Write("Contacto: ");
                            int contacto = int.Parse(Console.ReadLine());

                            Console.Write("Número de imóveis: ");
                            int numeroImoveis = int.Parse(Console.ReadLine());

                            Console.Write("Distrito: ");
                            string distrito = Console.ReadLine();
                            Console.Write("Concelho: ");
                            string concelho = Console.ReadLine();
                            Console.Write("Freguesia: ");
                            string freguesia = Console.ReadLine();

                            var localidade = new Localidade(distrito, concelho, freguesia);

                            gSen.Alterar(id, nif, nome, contacto, localidade, numeroImoveis);
                            Console.WriteLine("Senhorio alterado.");
                            break;
                        }

                        case 7: // Remover Senhorio
                        {
                            Console.Write("Id do senhorio: ");
                            int id = int.Parse(Console.ReadLine());
                            gSen.Remover(id);
                            Console.WriteLine("Senhorio removido.");
                            break;
                        }

                        case 8: // Listar Senhorios
                        {
                            foreach (var x in gSen.Listar())
                                Console.WriteLine($"{x.Id} - {x.Nome}");
                            break;
                        }

                        case 9: // Criar Imóvel
                        {
                            Console.Write("Tipo (1=Apartamento, 2=Vivenda): ");
                            int tipo = int.Parse(Console.ReadLine());

                            Console.Write("Área: ");
                            double area = double.Parse(Console.ReadLine());

                            Console.Write("Renda mensal: ");
                            double renda = double.Parse(Console.ReadLine());

                            Console.Write("Estado (1=Livre, 2=Ocupado, 3=Manutenção): ");
                            int estado = int.Parse(Console.ReadLine());

                            Console.Write("Distrito: ");
                            string distrito = Console.ReadLine();
                            Console.Write("Concelho: ");
                            string concelho = Console.ReadLine();
                            Console.Write("Freguesia: ");
                            string freguesia = Console.ReadLine();

                            var localidade = new Localidade(distrito, concelho, freguesia);

                            Console.Write("Id do senhorio: ");
                            int idS = int.Parse(Console.ReadLine());
                            var senhorio = repoSenhorio.ObterPorId(idS) ?? throw new SenhorioNaoEncontrado(idS);

                            Console.Write("Descrição: ");
                            string descricao = Console.ReadLine();

                            gImo.Criar(idImo++, tipo, area, renda, estado, localidade, descricao, senhorio);
                            Console.WriteLine("Imóvel criado.");
                            break;
                        }

                        case 10: // Alterar Imóvel
                        {
                            Console.Write("Id do imóvel: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("Tipo (1=Apartamento, 2=Vivenda): ");
                            int tipo = int.Parse(Console.ReadLine());

                            Console.Write("Área: ");
                            double area = double.Parse(Console.ReadLine());

                            Console.Write("Renda mensal: ");
                            double renda = double.Parse(Console.ReadLine());

                            Console.Write("Estado (1=Livre, 2=Ocupado, 3=Manutenção): ");
                            int estado = int.Parse(Console.ReadLine());

                            Console.Write("Distrito: ");
                            string distrito = Console.ReadLine();
                            Console.Write("Concelho: ");
                            string concelho = Console.ReadLine();
                            Console.Write("Freguesia: ");
                            string freguesia = Console.ReadLine();

                            var localidade = new Localidade(distrito, concelho, freguesia);

                            Console.Write("Id do senhorio: ");
                            int idS = int.Parse(Console.ReadLine());
                            var senhorio = repoSenhorio.ObterPorId(idS) ?? throw new SenhorioNaoEncontrado(idS);

                            Console.Write("Descrição: ");
                            string descricao = Console.ReadLine();

                            gImo.Alterar(id, tipo, area, renda, estado, localidade, descricao, senhorio);
                            Console.WriteLine("Imóvel alterado.");
                            break;
                        }

                        case 11: // Remover Imóvel
                        {
                            Console.Write("Id do imóvel: ");
                            int id = int.Parse(Console.ReadLine());
                            gImo.Remover(id);
                            Console.WriteLine("Imóvel removido.");
                            break;
                        }

                        case 12: // Listar Imóveis
                        {
                            foreach (var x in gImo.Listar())
                                Console.WriteLine($"{x.Id} - Tipo: {x.Tipo} - Renda: {x.RendaMensal}");
                            break;
                        }

                        case 13: // Criar Contrato
                        {
                            Console.Write("Id do senhorio: ");
                            int idS = int.Parse(Console.ReadLine());
                            var senhorio = repoSenhorio.ObterPorId(idS) ?? throw new SenhorioNaoEncontrado(idS);

                            Console.Write("Id do inquilino: ");
                            int idI = int.Parse(Console.ReadLine());
                            var inquilino = repoInquilino.ObterPorId(idI) ?? throw new InquilinoNaoEncontrado(idI);

                            Console.Write("Id do imóvel: ");
                            int idIm = int.Parse(Console.ReadLine());
                            var imovel = repoImovel.ObterPorId(idIm) ?? throw new ImovelNaoEncontrado(idIm);

                            Console.Write("Data início: ");
                            DateTime di = DateTime.Parse(Console.ReadLine());

                            Console.Write("Data fim: ");
                            DateTime df = DateTime.Parse(Console.ReadLine());

                            Console.Write("Estado (1=Ativo, 2=Desativo): ");
                            int estado = int.Parse(Console.ReadLine());

                            gCon.Criar(idCon++, senhorio, inquilino, imovel, di, df, estado);
                            Console.WriteLine("Contrato criado.");
                            break;
                        }

                        case 14: // Alterar Contrato
                        {
                            Console.Write("Id do contrato: ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("Id do senhorio: ");
                            int idS = int.Parse(Console.ReadLine());
                            var senhorio = repoSenhorio.ObterPorId(idS) ?? throw new SenhorioNaoEncontrado(idS);

                            Console.Write("Id do inquilino: ");
                            int idI = int.Parse(Console.ReadLine());
                            var inquilino = repoInquilino.ObterPorId(idI) ?? throw new InquilinoNaoEncontrado(idI);

                            Console.Write("Id do imóvel: ");
                            int idIm = int.Parse(Console.ReadLine());
                            var imovel = repoImovel.ObterPorId(idIm) ?? throw new ImovelNaoEncontrado(idIm);

                            Console.Write("Data início: ");
                            DateTime di = DateTime.Parse(Console.ReadLine());

                            Console.Write("Data fim: ");
                            DateTime df = DateTime.Parse(Console.ReadLine());

                            Console.Write("Estado (1=Ativo, 2=Desativo): ");
                            int estado = int.Parse(Console.ReadLine());

                            gCon.Alterar(id, di, df, estado, inquilino, imovel, senhorio);
                            Console.WriteLine("Contrato alterado.");
                            break;
                        }

                        case 15: // Remover Contrato
                        {
                            Console.Write("Id do contrato: ");
                            int id = int.Parse(Console.ReadLine());
                            gCon.Remover(id);
                            Console.WriteLine("Contrato removido.");
                            break;
                        }

                        case 16: // Listar Contratos
                        {
                            foreach (var c in gCon.Listar())
                                Console.WriteLine($"{c.Id} - {c.Senhorio?.Nome} / {c.Inquilino?.Nome} / Imóvel {c.Imovel?.Id}");
                            break;
                        }

                        case 17: // Criar Recibo
                        {
                            Console.Write("Id do contrato: ");
                            int idC = int.Parse(Console.ReadLine());

                            Console.Write("Mês: ");
                            int mes = int.Parse(Console.ReadLine());

                            Console.Write("Ano: ");
                            int ano = int.Parse(Console.ReadLine());

                            Console.Write("Valor: ");
                            double valor = double.Parse(Console.ReadLine());

                            Console.Write("Estado (1=Pendente, 2=Pago): ");
                            int estado = int.Parse(Console.ReadLine());

                            Console.Write("Método (1=Transf, 2=MBWay, 3=Numerário): ");
                            int metodo = int.Parse(Console.ReadLine());

                            gRec.Criar(idRec++, idC, DateTime.Now, mes, ano, valor, estado, DateTime.Now, metodo);
                            Console.WriteLine("Recibo criado.");
                            break;
                        }

                        case 18: // Alterar Recibo 
                        {
                            Console.Write("Id do contrato: ");
                            int idC = int.Parse(Console.ReadLine());

                            Console.Write("Id do recibo: ");
                            int idR = int.Parse(Console.ReadLine());

                            Console.Write("Estado (1=Pendente, 2=Pago): ");
                            int estado = int.Parse(Console.ReadLine());

                            Console.Write("Data pagamento: ");
                            DateTime dp = DateTime.Parse(Console.ReadLine());

                            Console.Write("Método (1=Transf, 2=MBWay, 3=Numerário): ");
                            int metodo = int.Parse(Console.ReadLine());

                            Console.Write("Valor: ");
                            double valor = double.Parse(Console.ReadLine());

                            gRec.Alterar(idC, idR, estado, dp, metodo, valor);
                            Console.WriteLine("Recibo alterado.");
                            break;
                        }

                        case 19: // Remover Recibo 
                        {
                            Console.Write("Id do contrato: ");
                            int idC = int.Parse(Console.ReadLine());

                            Console.Write("Id do recibo: ");
                            int idR = int.Parse(Console.ReadLine());

                            gRec.Remover(idC, idR);
                            Console.WriteLine("Recibo removido.");
                            break;
                        }

                        case 20: // Listar Recibos 
                        {
                            Console.Write("Id do contrato: ");
                            int idC = int.Parse(Console.ReadLine());

                            var lista = gRec.Listar(idC);
                            foreach (var r in lista)
                                Console.WriteLine($"{r.Id} - {r.MesReferencia}/{r.AnoReferencia} - {r.ValorPagamento}");
                            break;
                        }

                        case 21: // Criar Despesa 
                        {
                            Console.Write("Id do imóvel: ");
                            int idI = int.Parse(Console.ReadLine());

                            Console.Write("Data: ");
                            DateTime data = DateTime.Parse(Console.ReadLine());

                            Console.Write("Valor: ");
                            double valor = double.Parse(Console.ReadLine());

                            gDes.Criar(idDes++, idI, data, valor);
                            Console.WriteLine("Despesa criada.");
                            break;
                        }

                        case 22: // Alterar Despesa 
                        {
                            Console.Write("Id do imóvel: ");
                            int idI = int.Parse(Console.ReadLine());

                            Console.Write("Id da despesa: ");
                            int idD = int.Parse(Console.ReadLine());

                            Console.Write("Data: ");
                            DateTime data = DateTime.Parse(Console.ReadLine());

                            Console.Write("Valor: ");
                            double valor = double.Parse(Console.ReadLine());

                            gDes.Alterar(idI, idD, data, valor);
                            Console.WriteLine("Despesa alterada.");
                            break;
                        }

                        case 23: // Remover Despesa
                        {
                            Console.Write("Id do imóvel: ");
                            int idI = int.Parse(Console.ReadLine());

                            Console.Write("Id da despesa: ");
                            int idD = int.Parse(Console.ReadLine());

                            gDes.Remover(idI, idD);
                            Console.WriteLine("Despesa removida.");
                            break;
                        }

                        case 24: // Listar Despesas 
                        {
                            Console.Write("Id do imóvel: ");
                            int idI = int.Parse(Console.ReadLine());

                            var lista = gDes.Listar(idI);
                            foreach (var d in lista)
                                Console.WriteLine($"{d.Id} - {d.Data} - {d.Valor}");
                            break;
                        }

                        case 25: // Guardar tudo
                        {
                            repoInquilino.GuardarEmBinario("inquilinos.dat");
                            repoSenhorio.GuardarEmBinario("senhorios.dat");
                            repoImovel.GuardarEmBinario("imoveis.dat");
                            repoContrato.GuardarEmBinario("contratos.dat");
                            Console.WriteLine("Dados guardados.");
                            break;
                        }
                    }
                }
                catch (OperacaoInvalida ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro inesperado: " + ex.Message);
                }
                Console.WriteLine("\nENTER para continuar...");
                Console.ReadLine();

            } while (op != 0);

            // Guardar ao sair
            repoInquilino.GuardarEmBinario("inquilinos.dat");
            repoSenhorio.GuardarEmBinario("senhorios.dat");
            repoImovel.GuardarEmBinario("imoveis.dat");
            repoContrato.GuardarEmBinario("contratos.dat");
            Console.WriteLine("Working dir: " + Environment.CurrentDirectory);
        }
    }
}