using Aula_de_EntityFramework.Data;
using Aula_de_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Aula_de_EntityFramework.Controllers
{
    public class CompromissoController : Controller
    {
        private readonly Aula_de_EntityFrameworkContext _context;

        public CompromissoController(Aula_de_EntityFrameworkContext context)
        {
            _context = context;
        }

        // GET: Compromisso
        public async Task<IActionResult> Index()
        {

            var compromissos = await _context.Compromisso.ToListAsync();
            foreach (Compromisso comp in compromissos)
            {
                comp.Local = await _context.Locais.FirstOrDefaultAsync(l => l.Id == comp.LocalId);
                comp.Contato = await _context.Contato.FirstOrDefaultAsync(c => c.Id == comp.ContatoId);
            }
            return View(compromissos);
        }

        // GET: Compromisso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Compromisso == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromisso
                .FirstOrDefaultAsync(m => m.Id == id);
            compromisso.Local = await _context.Locais.FindAsync(compromisso.LocalId);
            compromisso.Contato = await _context.Contato.FindAsync(compromisso.ContatoId);
            if (compromisso == null)
            {
                return NotFound();
            }

            return View(compromisso);
        }

        // GET: Compromisso/Create
        public IActionResult Create()
        {
            List<SelectListItem> Contato = new List<SelectListItem>();

            Contato = _context.Contato.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();

            ViewBag.contatos = Contato;

            List<SelectListItem> Local = new();

            Local = _context.Locais.Select(l => new SelectListItem() { Text = l.NomeLocal, Value = l.Id.ToString() }).ToList();

            ViewBag.locais = Local;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,ContatoId,LocalId,Data,Descricao")] Compromisso compromisso)
        {
            compromisso.Local = await _context.Locais.FindAsync(compromisso.LocalId);
            compromisso.Contato = await _context.Contato.FindAsync(compromisso.ContatoId);
            _context.Add(compromisso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Compromisso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<SelectListItem> Contato = new List<SelectListItem>();

            Contato = _context.Contato.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();

            ViewBag.contatos = Contato;

            List<SelectListItem> Local = new();

            Local = _context.Locais.Select(l => new SelectListItem() { Text = l.NomeLocal, Value = l.Id.ToString() }).ToList();

            ViewBag.locais = Local;
            if (id == null || _context.Compromisso == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromisso.FindAsync(id);
            if (compromisso == null)
            {
                return NotFound();
            }
            return View(compromisso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContatoId,LocalId,Data,Descricao")] Compromisso compromisso)
        {
            compromisso.Local = await _context.Locais.FindAsync(compromisso.LocalId);
            compromisso.Contato = await _context.Contato.FindAsync(compromisso.ContatoId);
            if (id != compromisso.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(compromisso);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompromissoExists(compromisso.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Compromisso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null || _context.Compromisso == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromisso
                .FirstOrDefaultAsync(m => m.Id == id);
            compromisso.Local = await _context.Locais.FindAsync(compromisso.LocalId);
            compromisso.Contato = await _context.Contato.FindAsync(compromisso.ContatoId);
            if (compromisso == null)
            {
                return NotFound();
            }

            return View(compromisso);
        }

        // POST: Compromisso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Compromisso == null)
            {
                return Problem("Entity set 'Aula_de_EntityFrameworkContext.Compromisso'  is null.");
            }
            var compromisso = await _context.Compromisso.FindAsync(id);
            if (compromisso != null)
            {
                _context.Compromisso.Remove(compromisso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompromissoExists(int id)
        {
            return (_context.Compromisso?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
