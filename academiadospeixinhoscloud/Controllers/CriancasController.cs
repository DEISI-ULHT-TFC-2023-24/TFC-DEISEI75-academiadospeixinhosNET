using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using academiadospeixinhoscloud.Data;
using academiadospeixinhoscloud.Models;
using Microsoft.AspNetCore.Authorization;

namespace academiadospeixinhoscloud.Controllers
{

    [Authorize(Roles = "ADMIN")]
    public class CriancasController : Controller
    {
        private readonly academiadospeixinhoscloudContext _context;

        public CriancasController(academiadospeixinhoscloudContext context)
        {
            _context = context;
        }

        // GET: Criancas
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Crianca.ToListAsync());
        }

        // GET: Criancas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crianca = await _context.Crianca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crianca == null)
            {
                return NotFound();
            }

            return View(crianca);
        }

        // GET: Criancas/Create
        public IActionResult Create()
        {
            ViewBag.Atividade = new SelectList(_context.Atividade, "Nome", "Nome");
            ViewBag.Pai = new SelectList(_context.Pai, "Nome", "Nome");
            ViewBag.Subscricao = new SelectList(_context.Subscricao, "Nome", "Nome");
            ViewBag.Produto = new SelectList(_context.Produto, "Nome", "Nome");
            return View();
        }

        // POST: Criancas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,NIS,NumeroUtente,SeguroSaude,Apolice,Seguradora,MoradaFiscal,Nacionalidade,QuantidadeAgregado,Autorizados,Doencas,NBI,ValidadeBI,NomesAtividades,NomesPais,NomesSubscricao,NomesProduto")] Crianca crianca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crianca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crianca);
        }

        // GET: Criancas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Atividade = new SelectList(_context.Atividade, "Nome", "Nome");
            ViewBag.Pai = new SelectList(_context.Pai, "Nome", "Nome");
            ViewBag.Subscricao = new SelectList(_context.Subscricao, "Nome", "Nome");
            ViewBag.Produto = new SelectList(_context.Produto, "Nome", "Nome");

            if (id == null)
            {
                return NotFound();
            }

            var crianca = await _context.Crianca.FindAsync(id);
            if (crianca == null)
            {
                return NotFound();
            }
            return View(crianca);
        }

        // POST: Criancas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,NIS,NumeroUtente,SeguroSaude,Apolice,Seguradora,MoradaFiscal,Nacionalidade,QuantidadeAgregado,Autorizados,Doencas,NBI,ValidadeBI,NomesAtividades,NomesPais,NomesSubscricao,NomesProduto")] Crianca crianca)
        {
            if (id != crianca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crianca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CriancaExists(crianca.Id))
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
            return View(crianca);
        }

        // GET: Criancas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crianca = await _context.Crianca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (crianca == null)
            {
                return NotFound();
            }

            return View(crianca);
        }

        // POST: Criancas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crianca = await _context.Crianca.FindAsync(id);
            if (crianca != null)
            {
                _context.Crianca.Remove(crianca);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CriancaExists(int id)
        {
            return _context.Crianca.Any(e => e.Id == id);
        }
    }
}
