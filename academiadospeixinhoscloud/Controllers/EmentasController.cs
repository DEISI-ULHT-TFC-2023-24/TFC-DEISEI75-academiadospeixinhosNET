using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using academiadospeixinhoscloud.Data;
using academiadospeixinhoscloud.Models;

namespace academiadospeixinhoscloud.Controllers
{
    public class EmentasController : Controller
    {
        private readonly academiadospeixinhoscloudContext _context;

        public EmentasController(academiadospeixinhoscloudContext context)
        {
            _context = context;
        }

        // GET: Ementas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ementa.ToListAsync());
        }

        // GET: Ementas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ementa = await _context.Ementa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ementa == null)
            {
                return NotFound();
            }

            return View(ementa);
        }

        // GET: Ementas/Create
        public IActionResult Create()
        {
            ViewBag.Salas = new SelectList(_context.Sala, "Nome", "Nome");
            return View();
        }

        // POST: Ementas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Valida,NomesSalas")] Ementa ementa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ementa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ementa);
        }

        // GET: Ementas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ementa = await _context.Ementa.FindAsync(id);
            if (ementa == null)
            {
                return NotFound();
            }
            return View(ementa);
        }

        // POST: Ementas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Valida,NomesSalas")] Ementa ementa)
        {
            if (id != ementa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ementa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmentaExists(ementa.Id))
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
            return View(ementa);
        }

        // GET: Ementas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ementa = await _context.Ementa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ementa == null)
            {
                return NotFound();
            }

            return View(ementa);
        }

        // POST: Ementas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ementa = await _context.Ementa.FindAsync(id);
            if (ementa != null)
            {
                _context.Ementa.Remove(ementa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmentaExists(int id)
        {
            return _context.Ementa.Any(e => e.Id == id);
        }
    }
}
