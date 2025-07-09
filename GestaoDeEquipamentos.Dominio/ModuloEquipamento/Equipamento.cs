using GestaoDeEquipamentos.Dominio.Compartilhado;
using GestaoDeEquipamentos.Dominio.ModuloFabricante;

namespace GestaoDeEquipamentos.Dominio.ModuloEquipamento;

public class Equipamento : EntidadeBase<Equipamento>
{
    public string Nome { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public string NumeroSerie { get; set; }
    public Fabricante Fabricante { get; set; }
    public DateTime DataFabricacao { get; set; }

    public Equipamento() { }

    public Equipamento(
        string nome,
        decimal precoAquisicao,
        string numeroSerie,
        Fabricante fabricante,
        DateTime dataFabricacao) : this()

    {
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        NumeroSerie = numeroSerie;
        Fabricante = fabricante;
        DataFabricacao = dataFabricacao;
    }

    public override void AtualizarRegistro(Equipamento registroAtualizado)
    {
        Equipamento equipamentoAtualizado = (Equipamento)registroAtualizado;

        this.Nome = equipamentoAtualizado.Nome;
        this.PrecoAquisicao = equipamentoAtualizado.PrecoAquisicao;
        this.NumeroSerie = equipamentoAtualizado.NumeroSerie;
        this.Fabricante = equipamentoAtualizado.Fabricante;
        this.DataFabricacao = equipamentoAtualizado.DataFabricacao;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo \"Nome\" é obrigatório.\n";

        else if (Nome.Length < 3)
            erros += "O campo \"Nome\" precisa conter ao menos 3 caracteres.\n";

        if (PrecoAquisicao <= 0)
            erros += "O campo \"Preço de Aquisição\" deve ser maior que zero.\n";

        if (DataFabricacao > DateTime.Now)
            erros += "O campo \"Data de Fabricação\" deve conter uma data passada.\n";

        return erros;
    }
}
