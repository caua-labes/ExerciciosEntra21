using System.Diagnostics.Contracts;
using AulaMVC2._1.Dados;
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
			List<SelectListItem> Contato = new List<SelectListItem>();
			Contato = Dados.Listas.listaContato.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
			ViewBag.contatos = Contato;
			List<SelectListItem> Local = new List<SelectListItem>();
			Local = Dados.Listas.listaLocal.Select(l => new SelectListItem() { Text = l.NomeLocal, Value = l.Id.ToString() }).ToList();
			ViewBag.locais = Local;
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
			Dados.Listas.listaCompromissos.Add(lista);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Editar(int? id)
		{
            List<SelectListItem> Contato = new List<SelectListItem>();

            Contato = Dados.Listas.listaContato.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewBag.contatos = Contato;
            List<SelectListItem> Local = new();
            Local = Dados.Listas.listaContato.Select(l => new SelectListItem() { Text = l.Nome, Value = l.Id.ToString() }).ToList();
            ViewBag.locais = Local;
            var i = from l in Dados.Listas.listaCompromissos where l.Id == id select l;
			Models.Compromissos compromissos = i.FirstOrDefault();
			return View(compromissos);
		}
		[HttpPost]
		public IActionResult Editar(Models.Compromissos compromissos)
		{
			Models.Compromissos nLista = Dados.Listas.listaCompromissos.FirstOrDefault(ct => ct.Id == compromissos.Id);
            Models.Local lc = Dados.Listas.listaLocal.FirstOrDefault(c => c.Id == compromissos.Local.Id);
            compromissos.Local = lc;
            Models.Contato ct = Dados.Listas.listaContato.FirstOrDefault(c => c.Id == compromissos.Contato.Id);
            compromissos.Contato = ct;
            nLista.Descricão = compromissos.Descricão;
			nLista.Local = compromissos.Local;
			nLista.Data = compromissos.Data;
			nLista.Contato = compromissos.Contato;
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Deletar(int? id)
		{
			Models.Compromissos comp = Dados.Listas.listaCompromissos.FirstOrDefault(x => x.Id == id);
			return View(comp);
		}
		[HttpPost]
		public IActionResult Deletar(Models.Compromissos comp)
		{
			Models.Compromissos compromissos = Dados.Listas.listaCompromissos.FirstOrDefault( x => x.Id == comp.Id	);
			Dados.Listas.listaCompromissos.Remove(compromissos);
			return RedirectToAction("Index");
		}
        [HttpGet]
        public IActionResult Mostrar(int? id)
        {
            Models.Compromissos comp = Dados.Listas.listaCompromissos.FirstOrDefault(x => x.Id == id);
            return View(comp);
        }
        [HttpPost]
        public IActionResult Mostrar(Models.Compromissos comp)
        {
            Models.Compromissos compromissos = Dados.Listas.listaCompromissos.FirstOrDefault(x => x.Id == comp.Id);
			return View(compromissos);
        }
    }
}
