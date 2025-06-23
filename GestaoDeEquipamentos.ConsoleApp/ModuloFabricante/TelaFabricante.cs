
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class TelaFabricante : TelaBase
{
    private RepositorioFabricante repositorioFabricante;

    public TelaFabricante(
        RepositorioFabricante repositorioFabricante)
        : base("Fabricante", repositorioFabricante)
    {
        this.repositorioFabricante = repositorioFabricante;
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Fabricantes");
        Console.WriteLine();

        Console.WriteLine(
            "{0,  -10} | {1,  -20} | {2,  -30} | {3,  -15}",
            "Id", "Nome", "Email", "Telefone"
            );

        EntidadeBase[] fabricantes = repositorioFabricante.SelecionarRegistros();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante f = (Fabricante)fabricantes[i];

            if (f == null)
                continue;

            Console.WriteLine(
                "{0,  -10} | {1,  -20} | {2,  -30} | {3,  -15}",
            f.id, f.nome, f.email, f.telefone
            );
        }

        Console.ReadLine();
    }

    protected override Fabricante ObterDados()
    {
        Console.Write("Digite o nome do fabricante: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o email do fabricante: ");
        string email = Console.ReadLine();

        Console.Write("Digite o telefone do fabricante: ");
        string telefone = Console.ReadLine();

        Fabricante fabricante = new Fabricante(nome, email, telefone);

        return fabricante;
    }
}
