using Atividade1_API.Data;
using Atividade1_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Atividade1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ProdutosController : ControllerBase
    {
        private readonly Context _context;

        public ProdutosController(Context context)
        {
            _context = context;
        }

        // GET: api/Produtos
        [HttpGet]
        [Authorize(Roles = "Empregado,Gerente,Admin")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            List<Produto> produtos = new();

            produtos = await _context.Produtos.ToListAsync();
            foreach (Produto produto in produtos)
            {
                produto.Categoria = await _context.Categorias.FirstOrDefaultAsync(s => s.Id == produto.CategoriaId);
            }

            return produtos;
        }

        // GET: api/Produtos/5        
        [HttpGet("{id}")]
        [Authorize(Roles = "Empregado,Gerente")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {

            var produto = await _context.Produtos.FindAsync(id);

            produto.Categoria = await _context.Categorias.FirstOrDefaultAsync(s => s.Id == produto.CategoriaId);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // PUT: api/Produtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }
            produto.Categoria = await _context.Categorias.FirstOrDefaultAsync(s => s.Id == produto.Categoria.Id);
            produto.CategoriaId = produto.Categoria.Id;

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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

        // POST: api/Produtos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/api/[controller]")]
        [Authorize(Roles = "Empregado")]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            produto.Categoria = await _context.Categorias.FirstOrDefaultAsync(s => s.Id == produto.Categoria.Id);
            produto.CategoriaId = produto.Categoria.Id;
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }

        [HttpGet("/searchCategoria/{id}")]
        [Authorize(Roles = "Empregado,Gerente")]
        public async Task<IEnumerable<Produto>> GetCategoriaProduto(int id)
        {
            List<Produto> lista = await _context.Produtos.ToListAsync();
            lista = (from produtos in lista where produtos.CategoriaId == id select produtos).ToList();
            foreach (var item in lista)
            {
                item.Categoria = await _context.Categorias.FirstOrDefaultAsync(s => s.Id == item.CategoriaId);
            }
            return lista;
        }

        [HttpGet("/procurarDescrição/{descricao}")]
        [Authorize(Roles = "Empregado,Gerente")]
        public async Task<IEnumerable<Produto>> GetCategoriaProduto(string descricao)
        {
            /*List<Produto> lista = await _context.Produtos.ToListAsync();
            lista = (from produtos in lista where produtos.Descricao.ToLower().Contains(descricao.ToLower()) select produtos).ToList();
            foreach (var item in lista)
            {
                item.Categoria = await _context.Categorias.FirstOrDefaultAsync(s => s.Id == item.CategoriaId);
            }*/

            List<Produto> lista = await _context.Produtos.ToListAsync();
            List<Produto> lista2 = new();
            foreach (var item in lista)
            {
                if (Caracteres(descricao, item.Descricao) >= 3)
                {
                    item.Categoria = await _context.Categorias.FirstOrDefaultAsync(s => s.Id == item.CategoriaId);
                    lista2.Add(item);
                }
            }


            return lista2;
        }
        private int Caracteres(string c1, string c2)
        {
            return c1.Zip(c2, (e1, e2) => e2 == e1 ? 1 : 0).Sum();
        }

        [HttpGet("/api/[controller]page/{page}")]
        [Authorize(Roles = "Empregado,Gerente")]
        public async Task<ActionResult<IEnumerable<Produto>>> Paginacao(int page, int tamanho)
        {
            int pageL = 0;
            List<Produto> listaV = new();
            List<Produto> lista = await _context.Produtos.ToListAsync();
            if (page > lista.Count)
            {
                tamanho = 0;
            }
            else if (page == 1)
            {
                pageL = 0;
            }
            else
            {
                pageL = page * tamanho - tamanho;
            }
            for (int i = 0; i < tamanho; i++)
            {
                listaV.Add(lista[i + pageL]);
            }
            foreach (Produto produto in listaV)
            {
                produto.Categoria = await _context.Categorias.FirstOrDefaultAsync(s => s.Id == produto.CategoriaId);
            }
            return listaV;
        }
        [HttpGet("/api/[controller]/pagesProfessor")]
        [Authorize(Roles = "Empregado,Gerente")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetPageProdutos(
            int skip,
            int take
           )
        {
            List<Produto> contatos = await _context.Produtos.AsNoTracking().Skip(skip).Take(take).ToListAsync();
            return contatos;
        }
    }
}
