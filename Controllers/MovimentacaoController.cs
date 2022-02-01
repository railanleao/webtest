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
    public class MovimentacaoController : Controller
    {
        private readonly EFContext _context;

        public MovimentacaoController(EFContext context)
        {
            _context = context;
        }

        // GET: Movimentacao
        public async Task<IActionResult> Index()
        {
            var eFContext = _context.Movimentacao.Include(m => m.Produto);
            return View(await eFContext.ToListAsync());
        }

        // GET: Movimentacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacao
                .Include(m => m.Produto)
                .FirstOrDefaultAsync(m => m.MovimentacaoId == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // GET: Movimentacao/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome");
            return View();
        }

        // POST: Movimentacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovimentacaoId,ProdutoId,Descricao,DataHora")] Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimentacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", movimentacao.ProdutoId);
            return View(movimentacao);
        }

        // GET: Movimentacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacao.FindAsync(id);
            if (movimentacao == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", movimentacao.ProdutoId);
            return View(movimentacao);
        }

        // POST: Movimentacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovimentacaoId,ProdutoId,Descricao,DataHora")] Movimentacao movimentacao)
        {
            if (id != movimentacao.MovimentacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimentacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentacaoExists(movimentacao.MovimentacaoId))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", movimentacao.ProdutoId);
            return View(movimentacao);
        }

        // GET: Movimentacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacao
                .Include(m => m.Produto)
                .FirstOrDefaultAsync(m => m.MovimentacaoId == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // POST: Movimentacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimentacao = await _context.Movimentacao.FindAsync(id);
            _context.Movimentacao.Remove(movimentacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentacaoExists(int id)
        {
            return _context.Movimentacao.Any(e => e.MovimentacaoId == id);
        }
    }
}
