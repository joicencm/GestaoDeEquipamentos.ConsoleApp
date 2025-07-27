using GestaoDeEquipamentos.Dominio.Compartilhado;
using GestaoDeEquipamentos.Dominio.ModuloEquipamento;

namespace GestaoDeEquipamentos.Dominio.ModuloChamado;

public class Chamado : EntidadeBase<Chamado>
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataAbertura { get; set; }
    public Equipamento Equipamento { get; set; }

    public Chamado() { }

    public Chamado(
        string titulo,
        string descricao,
        DateTime dataAbertura,
        Equipamento equipamento
        ) : this()
    {
        this.Titulo = titulo;
        this.Descricao = descricao;
        this.DataAbertura = dataAbertura;
        this.Equipamento = equipamento;
    }

    public override void AtualizarRegistro(Chamado registroAtualizado)
    {
        Chamado chamadoAtualizado = (Chamado)registroAtualizado;

        this.Titulo = chamadoAtualizado.Titulo;
        this.Descricao = chamadoAtualizado.Descricao;
        this.DataAbertura = chamadoAtualizado.DataAbertura;
        this.Equipamento = chamadoAtualizado.Equipamento;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Titulo))
            erros += "O campo \"Título\" é obrigatório.\n";

        else if (Titulo.Length < 3)
            erros += "O campo \"Título\" precisa conter ao menos 3 caracteres";

        if (string.IsNullOrWhiteSpace(Descricao))
            erros += "O campo \"Descrição\" é obrigatório.\n";

        if (Equipamento == null)
            erros += "O campo \"Equipamento\" é obrigatório.\n";

        return erros;
    }
}
