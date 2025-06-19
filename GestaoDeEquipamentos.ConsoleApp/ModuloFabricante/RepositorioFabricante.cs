using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class RepositorioFabricante
{
    private Fabricante[] fabricantes = new Fabricante[100];
    private int contadorFabricante = 0;

    public void CadastrarFabricante(Fabricante fabricante)
    {
        fabricantes[contadorFabricante] = fabricante;
        contadorFabricante++;
    }

    public bool EditarFabricante(int idSelecionado, Fabricante fabricanteAtualizado)
    {
        Fabricante fabricanteSelecionado = SelecionarFabricantePorId(idSelecionado);

        if (fabricanteSelecionado == null)
            return false;

        fabricanteSelecionado.AtualizarRegistro(fabricanteAtualizado);

        return true;
    }

    public bool ExcluirFabricante(int idSelecionado)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            if (fabricantes[1] == null)
                continue;

            else if (fabricantes[i].id == idSelecionado)
            {
                fabricantes[i] = null;

                return true;
            }
        }

        return false;
    }
    public Fabricante[] SelecionarFabricantes()
    {
        return fabricantes;
    }

    public Fabricante SelecionarFabricantePorId(int idSelecionado)
    {
        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante f = fabricantes[i];

            if (f == null)
                continue;

            else if (f.id == idSelecionado)
                return f;
        }

        return null;
    }

}
