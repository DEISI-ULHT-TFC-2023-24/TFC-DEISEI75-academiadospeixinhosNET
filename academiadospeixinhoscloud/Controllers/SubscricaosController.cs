using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using academiadospeixinhoscloud.Data;
using academiadospeixinhoscloud.Models;
using Microsoft.IdentityModel.Tokens;

namespace academiadospeixinhoscloud.Controllers
{
    public class SubscricaosController : Controller
    {
        private readonly academiadospeixinhoscloudContext _context;

        public SubscricaosController(academiadospeixinhoscloudContext context)
        {
            _context = context;
        }

        // GET: Subscricaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subscricao.ToListAsync());
        }

        // GET: Subscricaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscricao = await _context.Subscricao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscricao == null)
            {
                return NotFound();
            }

            return View(subscricao);
        }

        // GET: Subscricaos/Create
        public IActionResult Create()
        {
            ViewBag.Salas = new SelectList(_context.Sala, "Nome", "Nome");
            ViewBag.Criancas = new SelectList(_context.Crianca, "Nome", "Nome");
            return View();
        }

        // POST: Subscricaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco,Valida,Descricao,DataInicio,DataFim,NomesCriancas,NomesSalas")] Subscricao subscricao)
        {

            if (ModelState.IsValid)
            {
                _context.Add(subscricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subscricao);
        }

        // GET: Subscricaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscricao = await _context.Subscricao.FindAsync(id);
            if (subscricao == null)
            {
                return NotFound();
            }
            return View(subscricao);
        }

        // POST: Subscricaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco,Valida,Descricao,DataInicio,DataFim,NomesCriancas")] Subscricao subscricao)
        {
            if (id != subscricao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscricao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscricaoExists(subscricao.Id))
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
            return View(subscricao);
        }

        // GET: Subscricaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscricao = await _context.Subscricao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subscricao == null)
            {
                return NotFound();
            }

            return View(subscricao);
        }

        // POST: Subscricaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscricao = await _context.Subscricao.FindAsync(id);
            if (subscricao != null)
            {
                _context.Subscricao.Remove(subscricao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscricaoExists(int id)
        {
            return _context.Subscricao.Any(e => e.Id == id);
        }
    }
}
