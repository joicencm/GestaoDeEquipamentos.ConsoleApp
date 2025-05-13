using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

        public class Equipamento
        {
            public int id;
            public string nome;
            public decimal precoAquisicao;
            public string numeroSerie;
            public Fabricante fabricante;
            public DateTime datafabricante;
        }
