using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class RepositorioChamado
{
    public Chamado[] chamados = new Chamado[100];
    public int contadorChamados = 0;

    public void CadastrarChamado(Chamado chamado)
    {
        chamados[contadorChamados] = chamado;
        contadorChamados++;
    }

    public bool EditarChamado(int idSelecionado, Chamado chamadoAtualizado)
    {
        Chamado chamadoSelecionado = SelecionarChamadoPorId(idSelecionado);

        if (chamadoSelecionado == null)
            return false;

        chamadoSelecionado.AtualizarRegistro(chamadoAtualizado);

        return true;
    }


    public bool ExcluirChamado(int idSelecionado)
    {
        for (int i = 0; i < chamados.Length; i++)
        {
            if (chamados[i] == null)
                continue;

            if (chamados[i].id == idSelecionado)
            {
                chamados[i] = null;

                return true;
            }
        }

        return false;
    }

    public Chamado[] SelecionarChamado()
    {
        return chamados;
    }

    public Chamado SelecionarChamadoPorId(int idSelecionado)
    {
        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado c = chamados[i];

            if (c == null)
                continue;
            if (c.id == idSelecionado)
                return c;
        }

        return null;
    }
}