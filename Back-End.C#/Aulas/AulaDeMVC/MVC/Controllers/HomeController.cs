using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Teste2()
        {
            List<Pessoa> lista = new List<Pessoa>();
            lista.Add(new Pessoa() { Id = 1, Nome = "Mariano", Email = "mari@gmail.com" });
            lista.Add(new Pessoa() { Id = 2, Nome = "Fabiante", Email = "fabiant@gmail.com" });
            lista.Add(new Pessoa() { Id = 3, Nome = "Puilo", Email = "ortu@gmail.com" });
            return View(lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}