using JovemProgramadorMVC.Data.Repositorio.Interface;
using JovemProgramadorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace JovemProgramadorMVC.Controllers
{
    public class ProfessoresController : Controller
    {
        private readonly IProfessorRepositorio _professorRepositorio;
        private readonly IConfiguration _configuration;
        public ProfessoresController(IProfessorRepositorio professorRepositorio, IConfiguration configuration)
        {
            _professorRepositorio = professorRepositorio;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            try
            {
                var result = _configuration.GetSection("ConnectionStrings")["StringConexao"];

                var professores = _professorRepositorio.BuscarProfessores();
                return View(professores);
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Ocorreu um erro de conexão com o Banco de Dados, tente novamente mais tarde.";
                return View("Index");
            }

        }
        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult InserirProfessor(ProfessorModel professor)
        {
            try
            {
                _professorRepositorio.InserirProfessor(professor);

                TempData["MensagemSucesso"] = "Professor adicionado com sucesso!";
                return RedirectToAction("Index");

            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro ao adicionar o professor, tente novamente mais tarde.";
                return RedirectToAction("Index");
            }

            // Poderia ser return RedirectToAction("Index"); -> Pois redireciona para a tela na View professor Index que é a principal
        }

        public IActionResult Editar(int id)
        {
            var professor = _professorRepositorio.BuscarId(id);
            return View(professor);

        }

        public IActionResult Atualizar(ProfessorModel professor)
        {
            try
            {
                _professorRepositorio.Atualizar(professor);
                TempData["EditarSucesso"] = $"Dados do professor {professor.Nome} editado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                TempData["EditarErro"] = $"Dados do professor {professor.Nome} editado com sucesso!";
                return RedirectToAction("Index");
            }

        }

        public IActionResult RemoverProfessor(int id)
        {
            try
            {
                var professor = _professorRepositorio.BuscarId(id);
                _professorRepositorio.ExcluirProfessor(professor);
                TempData["MensagemSucesso"] = $"Professor {professor.Nome} excluído com sucesso.";
                return RedirectToAction("Index");

            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Erro ao tentar excluir professor, tente novamente mais tarde.";
                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            try
            {
                cep = cep.Replace("-", "");

                EnderecoModel enderecoModel = new();

                using var cliente = new HttpClient();

                var result = await cliente.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");

                if (result.IsSuccessStatusCode)
                {
                    enderecoModel = JsonSerializer.Deserialize<EnderecoModel>(
                        await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { });

                }

                return View("Endereco", enderecoModel);
            }
            catch (System.Exception)
            {

                throw;
            }

        }


    }
}