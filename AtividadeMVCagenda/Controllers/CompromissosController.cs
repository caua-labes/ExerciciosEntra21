using System.Diagnostics.Contracts;
using AulaMVC2._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AulaMVC2._1.Controllers
{
	public class CompromissosController : Controller
	{
		public IActionResult Index()
		{
			return View(Dados.Listas.listaCompromissos);
		}
		[HttpGet]
		public IActionResult Criar()
		{ 
			List<SelectListItem> lista = new();
			lista = Dados.Listas.listaContato.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString()}).ToList();
			ViewBag.contatos = lista;

            List<SelectListItem> listaL = new();
            lista = Dados.Listas.listaLocal.Select(c => new SelectListItem() { Text = c.NomeLocal, Value = c.Id.ToString() }).ToList();
            ViewBag.locais = listaL;
            return View();
		}
		[HttpPost]
		public IActionResult Criar(Models.Compromissos lista)
		{
			lista.Id = Dados.Listas.listaCompromissos.Count() + 1;
			Models.Local lc = Dados.Listas.listaLocal.FirstOrDefault(c => c.Id == lista.Local.Id);
			lista.Local = lc;
            Models.Contato ct = Dados.Listas.listaContato.FirstOrDefault(c => c.Id == lista.Contato.Id);
			lista.Contato = ct;

            Models.Contato tc = Dados.Listas.listaContato.FirstOrDefault(c => c.Id == lista.Contato.Id);
            Dados.Listas.listaCompromissos.Add(lista);
			return RedirectToAction("Index");
        }
	}
}
