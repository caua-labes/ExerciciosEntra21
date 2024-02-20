using Aula_de_EntityFramework.Data;
using Aula_de_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula_de_EntityFramework.Controllers
{
    public class LocaisController : Controller
    {
        private readonly Aula_de_EntityFrameworkContext _context;

        public LocaisController(Aula_de_EntityFrameworkContext context)
        {
            _context = context;
        }

        // GET: Locais
        public async Task<IActionResult> Index()
        {
            return _context.Locais != null ?
                        View(await _context.Locais.ToListAsync()) :
                        Problem("Entity set 'Aula_de_EntityFrameworkContexto.Locais'  is null.");
        }

        // GET: Locais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Locais == null)
            {
                return NotFound();
            }

            var locais = await _context.Locais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locais == null)
            {
                return NotFound();
            }

            return View(locais);
        }

        // GET: Locais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeLocal,Cep,Numero")] Locais locais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locais);
        }

        // GET: Locais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Locais == null)
            {
                return NotFound();
            }

            var locais = await _context.Locais.FindAsync(id);
            if (locais == null)
            {
                return NotFound();
            }
            return View(locais);
        }

        // POST: Locais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeLocal,Cep,Numero")] Locais locais)
        {
            if (id != locais.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocaisExists(locais.Id))
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
            return View(locais);
        }

        // GET: Locais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Locais == null)
            {
                return NotFound();
            }

            var locais = await _context.Locais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locais == null)
            {
                return NotFound();
            }

            return View(locais);
        }

        // POST: Locais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Locais == null)
            {
                return Problem("Entity set 'Aula_de_EntityFrameworkContexto.Locais'  is null.");
            }
            var locais = await _context.Locais.FindAsync(id);
            if (locais != null)
            {
                _context.Locais.Remove(locais);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocaisExists(int id)
        {
            return (_context.Locais?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
