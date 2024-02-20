using System.Collections.Generic;
using AulaMVC2._1.Dados;
using AulaMVC2._1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AulaMVC2._1.Controllers
{
    public class ContatoController : Controller
    {
		public IActionResult Index(Contato contato)
        {
            Dados.Listas.listaContato = new ModosDao.CrudContato().consultar(contato);
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
            new ModosDao.CrudContato().salvar(contato);
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
            new ModosDao.CrudContato().editar(conta);
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
			new ModosDao.CrudContato().excluir(contato);
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