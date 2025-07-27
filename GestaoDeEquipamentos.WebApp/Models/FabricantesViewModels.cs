using GestaoDeEquipamentos.Dominio.ModuloFabricante;

namespace GestaoDeEquipamentos.WebApp.Models
{
    public class CadastrarFabricantesViewModels
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public CadastrarFabricantesViewModels()
        {
        }
    }

    public class EditarFabricantesViewModels
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public EditarFabricantesViewModels()
        {
        }

        public EditarFabricantesViewModels(int id, string nome, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }

    public class ExcluirFabricantesViewModels
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ExcluirFabricantesViewModels(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }

    public class VisualizarFabricantesViewModels
    {
        public List<DetalhesFabricantesViewModels> Registros { get; set; }

        public VisualizarFabricantesViewModels(List<Fabricante> fabricantes)
        {
            Registros = new List<DetalhesFabricantesViewModels>();

            foreach (Fabricante f in fabricantes)
            {
                DetalhesFabricantesViewModels detalhesVm = new DetalhesFabricantesViewModels(
                    f.Id,
                    f.Nome,
                    f.Email,
                    f.Telefone);

                Registros.Add(detalhesVm);
            }
        }
    }

    public class DetalhesFabricantesViewModels
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public DetalhesFabricantesViewModels(int id, string nome, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}
