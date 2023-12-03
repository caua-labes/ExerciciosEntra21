using AulaMVC2._1.Dados;
using Microsoft.AspNetCore.Mvc;

namespace AulaMVC2._1.Controllers
{
	public class LocalController : Controller
	{
		public IActionResult Index()
		{
			return View(Dados.Listas.listaLocal);
		}
		[HttpGet]
		public IActionResult Criar()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Criar(Models.Local local) 
		{
			local.Id = Dados.Listas.listaLocal.Count + 1;
			Dados.Listas.listaLocal.Add(local);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Editar(int? id) 
		{
			var i = from l in Dados.Listas.listaLocal where l.Id == id select l;
			Models.Local local = i.FirstOrDefault();
			return View(local);
		}
		[HttpPost]
		public IActionResult Editar(Models.Local local) 
		{
			Models.Local lol = Dados.Listas.listaLocal.FirstOrDefault(obj => obj.Id == local.Id);
			lol.NomeLocal = local.NomeLocal;
			lol.Rua = local.Rua;
			lol.Numero = local.Numero;
			lol.Bairro = local.Bairro;
			lol.Cidade = local.Cidade;
			lol.CEP = local.CEP;
			lol.Uf = local.Uf;
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Deletar(int? id)
		{
			var i = from l in Dados.Listas.listaLocal where l.Id == id select l;
			Models.Local local = i.FirstOrDefault();
			return View(local);
		}
		[HttpPost]
		public IActionResult Deletar(Models.Local local)
		{
			Models.Local lol = Dados.Listas.listaLocal.FirstOrDefault(obj => obj.Id == local.Id);
			Dados.Listas.listaLocal.Remove(lol);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Mostrar(int? id)
		{
			var i = from l in Dados.Listas.listaLocal where l.Id == id select l;
			Models.Local local = i.FirstOrDefault();
			return View(local);
		}
		[HttpPost]
		public IActionResult Mostrar(Models.Local local)
		{
			var lol = from obj in Dados.Listas.listaLocal where obj.Id == local.Id select obj;
			return View(lol);
		}


	}
}
