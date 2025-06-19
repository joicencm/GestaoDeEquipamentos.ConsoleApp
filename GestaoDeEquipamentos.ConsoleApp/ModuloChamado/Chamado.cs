using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class Chamado
{
    public int id;
    public string titulo;
    public string descricao;
    public DateTime dataAbertura;

    public Equipamento equipamento;

    public Chamado(string titulo, string descricao, DateTime dataAbertura, Equipamento equipamento)
    {
        this.titulo = titulo;
        this.descricao = descricao;
        this.dataAbertura = dataAbertura;
        this.equipamento = equipamento;
    }

    public void AtualizarRegistro(Chamado chamadoAtualizado)
    {
        this.titulo = chamadoAtualizado.titulo;
        this.descricao = chamadoAtualizado.descricao;
        this.dataAbertura = chamadoAtualizado.dataAbertura;
        this.equipamento = chamadoAtualizado.equipamento;
    }
}
