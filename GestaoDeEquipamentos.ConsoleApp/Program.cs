using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        RepositorioFabricante repositorioFabricante = new RepositorioFabricante();
        RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
        RepositorioChamado repositorioChamado = new RepositorioChamado();

        TelaFabricante telaFabricante = new TelaFabricante(repositorioFabricante);

        TelaEquipamento telaEquipamento = new TelaEquipamento(repositorioEquipamento, repositorioFabricante);

        TelaChamado telaChamado = new TelaChamado(repositorioEquipamento, repositorioChamado);

        while (true)
        {
            char telaEscolhida = ApresentarMenuPrincipal();

            if (telaEscolhida == 'S' || telaEscolhida == 's')
                break;

            if (telaEscolhida == '1')
            {
                char opcaoEscolhida = telaFabricante.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaFabricante.CadastrarRegistro();
                        break;

                    case '2':
                        telaFabricante.VisualizarRegistros(true);
                        break;

                    case '3':
                        telaFabricante.EditarRegistros();
                        break;

                    case '4':
                        telaFabricante.ExcluirRegistros();
                        break;
                }
            }

            else if (telaEscolhida == '2')
            {
                char opcaoEscolhida = telaEquipamento.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaEquipamento.CadastrarRegistro();
                        break;

                    case '2':
                        telaEquipamento.VisualizarRegistros(true);
                        break;

                    case '3':
                        telaEquipamento.EditarRegistros();
                        break;

                    case '4':
                        telaEquipamento.ExcluirRegistros();
                        break;
                }
            }

            else if (telaEscolhida == '3')
            {
                char opcaoEscolhida = telaChamado.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaChamado.CadastrarRegistro();
                        break;

                    case '2':
                        telaChamado.VisualizarRegistros(true);
                        break;

                    case '3':
                        telaChamado.EditarRegistros();
                        break;

                    case '4':
                        telaChamado.ExcluirRegistros();
                        break;
                }
            }
        }
    }

    public static char ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Equipamentos        |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Fabricantes");
        Console.WriteLine("2 - Controle de Equipamentos");
        Console.WriteLine("3 - Controle de Chamados");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];


        return opcaoEscolhida;
    }
}
