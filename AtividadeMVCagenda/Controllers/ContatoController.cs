using AulaMVC2._1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AulaMVC2._1.Controllers
{
    public class ContatoController : Controller
    {
		public IActionResult Index()
        {
            return View(Dados.Listas.listaContato);
        }
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(AulaMVC2._1.Models.Contato contato)
        {
            contato.Id = Dados.Listas.listaContato.Count + 1;
			Dados.Listas.listaContato.Add(contato);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            var i = from l in Dados.Listas.listaContato where l.Id == id select l;
            Models.Contato contato = i.FirstOrDefault();
            return View(contato);
        }
        [HttpPost]
        public IActionResult Editar(Models.Contato contato)
        {
            Models.Contato conta = Dados.Listas.listaContato.FirstOrDefault(ct => ct.Id == contato.Id);
            conta.Nome = contato.Nome;
            conta.Email = contato.Email;
            conta.Fone = contato.Fone;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public  IActionResult Deletar(int? id)
        {
            Models.Contato cont = Dados.Listas.listaContato.FirstOrDefault(i => i.Id == id);
            return View(cont);
        }
        [HttpPost]
        public IActionResult Deletar(Models.Contato cont)
        {
            Models.Contato contato = Dados.Listas.listaContato.FirstOrDefault(i => i.Id == cont.Id);
			Dados.Listas.listaContato.Remove(contato);
            return RedirectToAction("Index");
        }
		public IActionResult Mostrar(int? id)
		{
			Models.Contato cont = Dados.Listas.listaContato.FirstOrDefault(i => i.Id == id);
			return View(cont);
		}
		[HttpPost]
		public IActionResult Mostrar(Models.Contato cont)
		{
			Models.Contato contato = Dados.Listas.listaContato.FirstOrDefault(i => i.Id == cont.Id);
            return View(cont);
		}


	}
}