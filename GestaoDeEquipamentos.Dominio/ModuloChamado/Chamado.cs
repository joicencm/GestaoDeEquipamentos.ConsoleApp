using GestaoDeEquipamentos.Dominio.Compartilhado;
using GestaoDeEquipamentos.Dominio.ModuloEquipamento;

namespace GestaoDeEquipamentos.Dominio.ModuloChamado;

public class Chamado : EntidadeBase<Chamado>
{
    public string titulo { get; set; }
    public string descricao { get; set; }
    public DateTime dataAbertura { get; set; }
    public Equipamento equipamento { get; set; }

    public Chamado() { }

    public Chamado(
        string titulo,
        string descricao,
        DateTime dataAbertura,
        Equipamento equipamento
        ) : this()
    {
        this.titulo = titulo;
        this.descricao = descricao;
        this.dataAbertura = dataAbertura;
        this.equipamento = equipamento;
    }

    public override void AtualizarRegistro(Chamado registroAtualizado)
    {
        Chamado chamadoAtualizado = (Chamado)registroAtualizado;

        this.titulo = chamadoAtualizado.titulo;
        this.descricao = chamadoAtualizado.descricao;
        this.dataAbertura = chamadoAtualizado.dataAbertura;
        this.equipamento = chamadoAtualizado.equipamento;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(titulo))
            erros += "O campo \"Título\" é obrigatório.\n";

        else if (titulo.Length < 3)
            erros += "O campo \"Título\" precisa conter ao menos 3 caracteres";

        if (string.IsNullOrWhiteSpace(descricao))
            erros += "O campo \"Descrição\" é obrigatório.\n";

        if (equipamento == null)
            erros += "O campo \"Equipamento\" é obrigatório.\n";

        return erros;
    }
}
