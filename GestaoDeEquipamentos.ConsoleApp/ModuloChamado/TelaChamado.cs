using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class TelaChamado
{
    public RepositorioEquipamento repositorioEquipamento;

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Equipamentos");

        Console.WriteLine();
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

    public void CadastrarRegistro()
    {
        Console.Clear();
        Console.WriteLine("Cadastro de Chamado");
        Console.WriteLine();
        Chamado chamado = ObterDados();
       
        Console.WriteLine($"\nEChamado \"{chamado.titulo}\" cadastro com sucesso");
        Console.ReadLine();
    }

    public void EditarRegistros()
    {
        throw new NotImplementedException();
    }

    public void ExcluirRegistros()
    {
        throw new NotImplementedException();
    }

    public void VisualizarRegistros(bool exibirCabecalho)
    {
        throw new NotImplementedException();
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

        return null;
    }

    public void VisualizarEquipamentos()
    {
        Console.WriteLine("Visualização de Equipamentos");
        Console.WriteLine();

        Console.WriteLine(
            "{0,  -10} | {1,  -20} | {2,  -10} | {3,  -10} | {4,  -20} | {5,  -20}",
            "Id", "Nome", "Preço de Aquisição", "Número Série", "Fabricante", "Data Fabricação"
            );
        Equipamento[] equipamentos = repositorioEquipamento.SelecionarEquipamento();

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0,  -10} | {1,  -20} | {2,  -10} | {3,  -10} | {4,  -20} | {5,  -20}",
            e.id, e.nome, e.precoAquisicao.ToString("C2"), e.numeroSerie, e.fabricante, e.datafabricante.ToShortDateString()
            );
        }

        Console.ReadLine();
    }
}
