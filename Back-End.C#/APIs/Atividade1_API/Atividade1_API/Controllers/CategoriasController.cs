using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atividade1_API.Data;
using Atividade1_API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace Atividade1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CategoriasController : ControllerBase
    {
        private readonly Context _context;

        public CategoriasController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        [Authorize(Roles = "Empregado,Gerente,Admin")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Empregado, Gerente")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {   
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpPost("/api/[controller]")]
        [Authorize(Roles = "Empregado")]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
        [HttpGet("/api/[controller]/procurarDescrição/{nome}")]
        [Authorize(Roles = "Empregado,Gerente")]
        public async Task<IEnumerable<Categoria>> GetCategoriaProduto(string nome)
        {
            /*List<Categoria> lista = await _context.Categorias.ToListAsync();
            lista = (from categoria in lista where categoria.Nome.ToLower().Contains(nome.ToLower()) select categoria).ToList();*/
            List<Categoria> lista = await _context.Categorias.ToListAsync();
            List<Categoria> lista2 = new();
            foreach (var item in lista)
            {
                if (Caracteres(nome, item.Nome) >= 3)
                {
                    lista2.Add(item);
                }
            }


            return lista2;
        }
        private int Caracteres(string c1, string c2)
        {
            return c1.Zip(c2, (e1, e2) => e2 == e1 ? 1 : 0).Sum();
        }
    }
}
