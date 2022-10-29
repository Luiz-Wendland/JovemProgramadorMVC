using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorMVC.Controllers
{
    public class AlunosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Adicionar()
        {
            return View();
        }
    }
}
