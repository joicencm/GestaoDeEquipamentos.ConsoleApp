using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class TelaChamado
{
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioChamado repositorioChamado;

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Chamados");
        Console.WriteLine();
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine("1 - Cadastro de Chamado");
        Console.WriteLine("2 - Visualizar Chamado");
        Console.WriteLine("3 - Editar chamado");
        Console.WriteLine("4 - Excluir Chamado");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;
    }

    public void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastro de Chamado");
        Console.WriteLine();
        Chamado chamado = ObterDados();

        repositorioChamado.CadastrarChamado(chamado);

        Console.WriteLine($"\nChamado \"{chamado.titulo}\" cadastro com sucesso");
        Console.ReadLine();
    }

    public void EditarRegistros()
    {
        ExibirCabecalho();

        Console.WriteLine("Edição de Chamados");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Ditite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Chamado chamadoAtualizado = ObterDados();

        bool conseguiuEditar = repositorioChamado.EditarChamado(idSelecionado, chamadoAtualizado);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Não foi possivel encontrar o registro selecionado.");
            Console.ReadLine();

            return;
        }
        Console.WriteLine($"\nChamado \"{chamadoAtualizado.titulo}\" editado com sucesso");
        Console.ReadLine();
    }

    public void ExcluirRegistros()
    {
        ExibirCabecalho();

        Console.WriteLine("Exclusão de Chamados");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Ditite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExluir = repositorioChamado.ExcluirChamado(idSelecionado);

        if (!conseguiuExluir)
        {
            Console.WriteLine("Não foi possivel encontrar o registro selecionado.");
            Console.ReadLine();

            return;
        }

        Console.WriteLine($"\nChamado excluído com sucesso");
        Console.ReadLine();
    }

    public void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Chamados");
        Console.WriteLine();

        Console.WriteLine(
            "{0,  -10} | {1,  -20} | {2,  -15} | {3,  -15} | {4,  -20}",
            "Id", "Titulo", "Descrição", "data de Abertura", "Equipamento"
            );
        Chamado[] chamados = repositorioChamado.SelecionarChamado();

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado c = chamados[i];

            if (c == null)
                continue;

            Console.WriteLine(
                "{0,  -10} | {1,  -20} | {2,  -15} | {3,  -15} | {4,  -20}",
            c.id, c.titulo, c.descricao, c.dataAbertura.ToShortDateString(), c.equipamento.nome
            );
        }

        Console.ReadLine();
    }

    public Chamado ObterDados()
    {
        Console.Write("Digite o titulo do chamado");
        string titulo = Console.ReadLine();

        Console.Write("Digite a descrição do chamado");
        string descricao = Console.ReadLine();

        DateTime dataAbertura = DateTime.Now; // data e hora de agora

        VisualizarEquipamentos();

        Console.Write("Digite o ID do equipmaneto que deseja selecionar: ");
        int idEquipamento = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarEquipamentoPorId(idEquipamento);

        Chamado chamado = new Chamado();
        chamado.titulo = titulo;
        chamado.descricao = descricao;
        chamado.dataAbertura = dataAbertura;
        chamado.equipamento = equipamentoSelecionado;

        return chamado;
    }

    public void VisualizarEquipamentos()
    {
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
}
