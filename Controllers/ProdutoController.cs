#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webtest.Connection;
using webtest.Objects;

namespace webtest.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly EFContext _context;

        public ProdutoController(EFContext context)
        {
            _context = context;
        }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            var eFContext = _context.Produtos.Include(p => p.Categoria).Include(p => p.ItenVenda).Include(p => p.Venda);
            return View(await eFContext.ToListAsync());
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.ItenVenda)
                .Include(p => p.Venda)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId");
            ViewData["ProdutoId"] = new SelectList(_context.Set<ItenVenda>(), "ItenVendaId", "ItenVendaId");
            ViewData["ProdutoId"] = new SelectList(_context.Vendas, "NumVendaId", "NumVendaId");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,Nome,Descricao,Quantidade,Preco,CategoriaId,NumVendaId,ItenVendaId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", produto.CategoriaId);
            ViewData["ProdutoId"] = new SelectList(_context.Set<ItenVenda>(), "ItenVendaId", "ItenVendaId", produto.ProdutoId);
            ViewData["ProdutoId"] = new SelectList(_context.Vendas, "NumVendaId", "NumVendaId", produto.ProdutoId);
            return View(produto);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", produto.CategoriaId);
            ViewData["ProdutoId"] = new SelectList(_context.Set<ItenVenda>(), "ItenVendaId", "ItenVendaId", produto.ProdutoId);
            ViewData["ProdutoId"] = new SelectList(_context.Vendas, "NumVendaId", "NumVendaId", produto.ProdutoId);
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,Nome,Descricao,Quantidade,Preco,CategoriaId,NumVendaId,ItenVendaId")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", produto.CategoriaId);
            ViewData["ProdutoId"] = new SelectList(_context.Set<ItenVenda>(), "ItenVendaId", "ItenVendaId", produto.ProdutoId);
            ViewData["ProdutoId"] = new SelectList(_context.Vendas, "NumVendaId", "NumVendaId", produto.ProdutoId);
            return View(produto);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.ItenVenda)
                .Include(p => p.Venda)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
