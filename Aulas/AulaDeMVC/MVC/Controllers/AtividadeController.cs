using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class AtividadeController : Controller
    {
        public IActionResult Index2()
        {
            int val = int.Parse(Console.ReadLine());
            List<Pessoa> lista = new List<Pessoa>();
            lista.Add(new Pessoa() { Id = 1, Nome = "Mariano", Email = "mari@gmail.com" });
            lista.Add(new Pessoa() { Id = 2, Nome = "Fabiante", Email = "fabiant@gmail.com" });
            lista.Add(new Pessoa() { Id = 3, Nome = "Puilo", Email = "ortu@gmail.com" });

            var id =
                from pessoa in lista
                where pessoa.Id == val
                select pessoa;

            if (id == null)
            {
                return View("ERR");
            }
            else
            {
                return View(id.ToArray()[0]);
            }
        }
    }
}
