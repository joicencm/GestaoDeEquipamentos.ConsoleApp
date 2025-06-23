using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado;

public abstract class TelaBase
{
    protected string nomeEntidade;
    protected RepositorioBase repositorio;

    protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
    {
        this.nomeEntidade = nomeEntidade;
        this.repositorio = repositorio;
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

        EntidadeBase novoRegistro = ObterDados();

        string erros = novoRegistro.Validar();

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

        repositorio.CadastrarRegistro(novoRegistro);

        Console.WriteLine($"\nF{nomeEntidade} cadastro com sucesso!");
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

        EntidadeBase registroAtualizado = ObterDados();

        repositorio.EditarRegistro(idSelecionado, registroAtualizado);

        Console.WriteLine($"\n{nomeEntidade} editado com suecesso!");
        Console.ReadLine();
    }

    public void ExcluirRegistros()
    {
        ExibirCabecalho();

        Console.WriteLine($"Exclusão de {nomeEntidade}");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        repositorio.ExcluirRegistro(idSelecionado);

        Console.WriteLine($"\nFabricante excluído com sucesso!");
        Console.ReadLine();
    }
    public abstract void VisualizarRegistros(bool exibirCabecalho);

    protected void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine($"Gestão de {nomeEntidade}s");
        Console.WriteLine();
    }

    protected abstract EntidadeBase ObterDados();
}
