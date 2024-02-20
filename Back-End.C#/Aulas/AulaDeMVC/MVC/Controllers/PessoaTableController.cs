using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class PessoaTableController : Controller
    {
        public IActionResult Index()
        {
            List<Pessoa> lista = new List<Pessoa>();
            lista.Add(new Pessoa() { Id = 1, Nome = "Mariano", Email = "mari@gmail.com" });
            lista.Add(new Pessoa() { Id = 2, Nome = "Fabiante", Email = "fabiant@gmail.com" });
            lista.Add(new Pessoa() { Id = 3, Nome = "Puilo", Email = "ortu@gmail.com" });

            return View(lista);
        }
        public IActionResult Index1() 
        { 
            return View(new Pessoa() { Id = 4, Nome = "Ortrick", Email = "caua@gmail.com"});
        }
    }
}
