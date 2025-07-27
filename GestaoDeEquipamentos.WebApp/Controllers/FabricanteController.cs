using GestaoDeEquipamentos.Dominio.ModuloFabricante;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloFabricante;
using GestaoDeEquipamentos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Controllers
{
    public class FabricanteController : Controller
    {
        private RepositorioFabricanteEmArquivo repositorioFabricante;

        public FabricanteController()
        {
            ContextoDados contexto = new ContextoDados(true);
            repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);
        }
        public IActionResult Index()
        {
            List<Fabricante> fabricantes = repositorioFabricante.SelecionarRegistros();

            VisualizarFabricantesViewModels visualizarVm = new VisualizarFabricantesViewModels(fabricantes);

            return View(visualizarVm);
        }

        public IActionResult Cadastrar()
        {
            CadastrarFabricantesViewModels cadastrarVm = new CadastrarFabricantesViewModels();

            return View(cadastrarVm);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarFabricantesViewModels cadastrarVm)
        {
            Fabricante novoFabricante = new Fabricante(cadastrarVm.Nome, cadastrarVm.Email, cadastrarVm.Telefone);

            repositorioFabricante.CadastrarRegistro(novoFabricante);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Editar(int id)
        {
            Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

            if (fabricanteSelecionado == null)
                return RedirectToAction(nameof(Index));

            EditarFabricantesViewModels editarVm = new EditarFabricantesViewModels(
                fabricanteSelecionado.Id,
                fabricanteSelecionado.Nome,
                fabricanteSelecionado.Email,
                fabricanteSelecionado.Telefone
                );

            return View(editarVm);
        }

        [HttpPost]
        public IActionResult Editar(int id, EditarFabricantesViewModels editarVm)
        {
            Fabricante fabricanteEditado = new Fabricante(
                editarVm.Nome,
                editarVm.Email,
                editarVm.Telefone
                );

            bool edicaoConcluida = repositorioFabricante.EditarRegistro(id, fabricanteEditado);

            if (!edicaoConcluida)
            {
                fabricanteEditado.Id = id;
                return View(fabricanteEditado);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

            if (fabricanteSelecionado == null)
                return RedirectToAction(nameof(Index));

            ExcluirFabricantesViewModels excluirVm =
                new ExcluirFabricantesViewModels(id, fabricanteSelecionado.Nome);

            return View(excluirVm);
        }

        public IActionResult ExcluirConfirmado(int id)
        {
            repositorioFabricante.ExcluirRegistro(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
