using AulaMVC2._1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AulaMVC2._1.Controllers
{
    public class ContatoController : Controller
    {
        static List<Models.Contato> lista = new();
        public IActionResult Index()
        {
            return View(lista);

        }
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(AulaMVC2._1.Models.Contato contato)
        {
            contato.Id = lista.Count + 1;
            lista.Add(contato);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            var i = from l in lista where l.Id == id select l;
            Models.Contato contato = i.FirstOrDefault();
            return View(contato);
        }
        [HttpPost]
        public IActionResult Editar(Models.Contato contato)
        {
            Models.Contato conta = lista.FirstOrDefault(ct => ct.Id == contato.Id);
            conta.Nome = contato.Nome;
            conta.Email = contato.Email;
            conta.Fone = contato.Fone;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public  IActionResult Deletar(int? id)
        {
            Models.Contato cont = lista.FirstOrDefault(i => i.Id == id);
            return View(cont);
        }
        [HttpPost]
        public IActionResult Deletar(Models.Contato cont)
        {
            Models.Contato contato = lista.FirstOrDefault(i => i.Id == cont.Id);
            lista.Remove(contato);
            return RedirectToAction("Index");
        }
		public IActionResult Mostrar(int? id)
		{
			Models.Contato cont = lista.FirstOrDefault(i => i.Id == id);
			return View(cont);
		}
		[HttpPost]
		public IActionResult Mostrar(Models.Contato cont)
		{
			Models.Contato contato = lista.FirstOrDefault(i => i.Id == cont.Id);
            return View(cont);
		}


	}
}