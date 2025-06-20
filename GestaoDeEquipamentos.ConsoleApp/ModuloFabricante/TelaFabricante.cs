
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class TelaFabricante
{
    private RepositorioFabricante repositorioFabricante;

    public TelaFabricante(RepositorioFabricante repositorioF)
    {
        repositorioFabricante = repositorioF;
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine("1 - Cadastro de Fabricante");
        Console.WriteLine("2 - Visualizar Fabricante");
        Console.WriteLine("3 - Editar Fabricante");
        Console.WriteLine("4 - Excluir fabricante");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;
    }

    public void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastro de Fabricante");

        Console.WriteLine();

        Fabricante novoFabricante = ObterDados();

        string erros = novoFabricante.Validar();

        if (erros.Length > 0)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erros);
            Console.ResetColor();

            Console.Write("\nDigite enter para continuar...");
            Console.ReadLine();

            //Recursão
            CadastrarRegistro();
            return;
        }

        repositorioFabricante.CadastrarRegistro(novoFabricante);

        Console.WriteLine($"\nFabricante \"{novoFabricante.nome}\" cadastro com sucesso");
        Console.ReadLine();
    }

    public void EditarRegistros()
    {
        ExibirCabecalho();

        Console.WriteLine("Edição de Fabricantes");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Digite o Id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Fabricante fabricanteAtualizado = ObterDados();

        repositorioFabricante.EditarRegistro(idSelecionado, fabricanteAtualizado);

        Console.WriteLine($"\nFabricante \"{fabricanteAtualizado.nome}\"editado com suecesso");
        Console.ReadLine();
    }

    public void ExcluirRegistros()
    {
        ExibirCabecalho();

        Console.WriteLine("Exclusão de Fabricantes");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        repositorioFabricante.ExcluirRegistro(idSelecionado);

        Console.WriteLine($"\nFabricante excluído com sucesso!");
        Console.ReadLine();
    }

    public void VisualizarRegistros(bool exibirCabecalho)
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

    private void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine();
    }

    private Fabricante ObterDados()
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
