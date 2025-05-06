namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;


        public class TelaEquipamento
        {
            public RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
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

            internal void CadastrarRegistro()
            {
                Console.Clear();
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine();

                Console.WriteLine("Cadastro de Equipamentos");
                Equipamento equipamento = ObterDados();

                repositorioEquipamento.CadastrarEquipamento(equipamento);

                Console.WriteLine($"\nEquipamento \"{equipamento.nome}\" cadastro com sucesso");
                Console.ReadLine();

            }

            public void VisualizarRegistros(bool exibirCabecalho)
            {
                if (exibirCabecalho == true)
                    ExibirCabecalho();

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

            public void EditarRegistros()
            {
                ExibirCabecalho();

                Console.WriteLine("Edição de Equipamentos");

                Console.WriteLine();

                VisualizarRegistros(false);

                Console.Write("Ditite o id do registro que deseja selecionar: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                Equipamento equipamentoAtualizado = ObterDados();

                bool conseguiuEditar = repositorioEquipamento.EditarEquipamento(idSelecionado, equipamentoAtualizado);

                if (!conseguiuEditar)
                {
                    Console.WriteLine("Não foi possivel encontrar o registro selecionado.");
                    Console.ReadLine();

                    return;
                }
                Console.WriteLine($"\nEquipamento \"{equipamentoAtualizado.nome}\" cadastro com sucesso");              Console.ReadLine();
            }

            public void ExcluirRegistros()
            {
                ExibirCabecalho();

                Console.WriteLine("Exclusão de Equipamentos");

                Console.WriteLine();

                VisualizarRegistros(false);

                Console.Write("Ditite o id do registro que deseja selecionar: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                bool conseguiuExluir = repositorioEquipamento.ExcluirEquipamento(idSelecionado);

                if (!conseguiuExluir)
                {
                    Console.WriteLine("Não foi possivel encontrar o registro selecionado.");
                    Console.ReadLine();

                    return;
                }

                Console.WriteLine($"\nEquipamento excluído com sucesso");
                Console.ReadLine();
            }

            public Equipamento ObterDados()
            {
                Console.WriteLine("Digite o nome do equipamento");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite o preço do equipamento");
                decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Digite o numero de série do equipamento");
                string numeroSerie = Console.ReadLine();

                Console.WriteLine("Digite o nome do fabricante do equipamento");
                string fabricante = Console.ReadLine();

                Console.WriteLine("Digite a data de fabricação do equipamento");
                DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

                Equipamento equipamento = new Equipamento();
                equipamento.nome = nome;
                equipamento.precoAquisicao = precoAquisicao;
                equipamento.numeroSerie = numeroSerie;
                equipamento.fabricante = fabricante;
                equipamento.datafabricante = dataFabricacao;

                return equipamento;
            }
        }