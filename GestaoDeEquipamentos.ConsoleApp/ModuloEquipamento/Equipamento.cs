using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class Equipamento : EntidadeBase
{
    public int id;
    public string nome;
    public decimal precoAquisicao;
    public string numeroSerie;
    public Fabricante fabricante;
    public DateTime datafabricante;

    public Equipamento(string nome, decimal precoAquisicao, string numeroSerie, Fabricante fabricante, DateTime datafabricante)
    {
        this.nome = nome;
        this.precoAquisicao = precoAquisicao;
        this.numeroSerie = numeroSerie;
        this.fabricante = fabricante;
        this.datafabricante = datafabricante;
    }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Equipamento equipamentoAtualizado = (Equipamento)registroAtualizado;

        this.nome = equipamentoAtualizado.nome;
        this.precoAquisicao = equipamentoAtualizado.precoAquisicao;
        this.numeroSerie = equipamentoAtualizado.numeroSerie;
        this.fabricante = equipamentoAtualizado.fabricante;
        this.datafabricante = equipamentoAtualizado.datafabricante;
    }
}
