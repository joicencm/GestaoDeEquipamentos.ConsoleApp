using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class TelaEquipamento
{
    private RepositorioEquipamento repositorioEquipamento;
    private RepositorioFabricante repositorioFabricante;

    public TelaEquipamento(RepositorioEquipamento repositorioE, RepositorioFabricante repositorioF)
    {
        this.repositorioEquipamento = repositorioE;
        this.repositorioFabricante = repositorioF;
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine("1 - Cadastro de Equipamentos");
        Console.WriteLine("2 - Visualizar Equipamentos");
        Console.WriteLine("3 - Editar Equipamentos");
        Console.WriteLine("4 - Excluir Equipamentos");
        Console.WriteLine("S - Sair");

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;
    }

    internal void CadastrarRegistro()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine();

        Console.WriteLine("Cadastro de Equipamentos");
        Equipamento equipamento = ObterDados();

        repositorioEquipamento.CadastrarEquipamento(equipamento);

        Console.WriteLine($"\nEquipamento \"{equipamento.nome}\" cadastro com sucesso");
        Console.ReadLine();

    }

    public void EditarRegistros()
    {
        ExibirCabecalho();

        Console.WriteLine("Edição de Equipamentos");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Ditite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoAtualizado = ObterDados();

        bool conseguiuEditar = repositorioEquipamento.EditarEquipamento(idSelecionado, equipamentoAtualizado);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Não foi possivel encontrar o registro selecionado.");
            Console.ReadLine();

            return;
        }
        Console.WriteLine($"\nEquipamento \"{equipamentoAtualizado.nome}\" editado com sucesso");
        Console.ReadLine();
    }

    public void ExcluirRegistros()
    {
        ExibirCabecalho();

        Console.WriteLine("Exclusão de Equipamentos");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Ditite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExluir = repositorioEquipamento.ExcluirEquipamento(idSelecionado);

        if (!conseguiuExluir)
        {
            Console.WriteLine("Não foi possivel encontrar o registro selecionado.");
            Console.ReadLine();

            return;
        }

        Console.WriteLine($"\nEquipamento excluído com sucesso");
        Console.ReadLine();
    }

    public void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Equipamentos");
        Console.WriteLine();

        Console.WriteLine(
            "{0,  -10} | {1,  -20} | {2,  -15} | {3,  -15} | {4,  -20} | {5,  -15}",
            "Id", "Nome", "Preço de Aquisição", "Número Série", "Fabricante", "Data Fabricação"
            );
        Equipamento[] equipamentos = repositorioEquipamento.SelecionarEquipamento();

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0,  -10} | {1,  -20} | {2,  -15} | {3,  -15} | {4,  -20} | {5,  -15}",
            e.id, e.nome, e.precoAquisicao.ToString("C2"), e.numeroSerie, e.fabricante.nome, e.datafabricante.ToShortDateString()
            );
        }

        Console.ReadLine();
    }

    public void VisualizarFabricantes()
    {
        Console.WriteLine();

        Console.WriteLine("Visualização de Fabricantes");

        Console.WriteLine();

        Console.WriteLine("{0, -10} | {1, -20} | {2, -30} | {3, -15}",
            "Id", "Nome", "Email", "Telefone"
            );

        Fabricante[] fabricantes = repositorioFabricante.SelecionarFabricantes();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante f = fabricantes[i];

            if (f == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                f.id, f.nome, f.email, f.telefone
                );
        }

        Console.ReadLine();
    }

    private void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Equipamentos");

        Console.WriteLine();
    }

    private Equipamento ObterDados()
    {
        Console.Write("Digite o nome do equipamento: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o preço do equipamento: ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite o numero de série do equipamento: ");
        string numeroSerie = Console.ReadLine();

        Console.Write("Digite a data de fabricação do equipamento: ");
        DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

        VisualizarFabricantes();

        Console.Write("Digite o id do fabricante do equipamento: ");
        int idFabricante = Convert.ToInt32(Console.ReadLine());

        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarFabricantePorId(idFabricante);

        Equipamento equipamento = new Equipamento(nome, precoAquisicao, numeroSerie, fabricanteSelecionado, dataFabricacao);

        return equipamento;
    }
}