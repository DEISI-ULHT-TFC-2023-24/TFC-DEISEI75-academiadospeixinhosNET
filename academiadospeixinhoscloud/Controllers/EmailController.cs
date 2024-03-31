using academiadospeixinhoscloud.Data;
using academiadospeixinhoscloud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System.Linq;

namespace academiadospeixinhoscloud.Controllers
{
    public class EmailController : Controller
    {
        private readonly academiadospeixinhoscloudContext _context;

        public EmailController(academiadospeixinhoscloudContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Crianca = new SelectList(_context.Crianca, "Nome", "Nome");
            ViewBag.Atividade = new SelectList(_context.Atividade, "Nome", "Nome");
            ViewBag.Pai = new SelectList(_context.Pai, "Nome", "Nome");
            ViewBag.Subscricao = new SelectList(_context.Subscricao, "Nome", "Nome");
            ViewBag.Produto = new SelectList(_context.Produto, "Nome", "Nome");

            List<string> selectedList = new List<string>();
            ViewBag.Selected = selectedList;

            List<string> selectedEmailList = new List<string>();
            ViewBag.SelectedEmail = selectedEmailList;

            return View(await _context.Crianca.ToListAsync());
        }

        [HttpPost]
        public ActionResult Select(IEnumerable<string> Crianca, IEnumerable<string> Pai)
        {
            List<string> selectedEmailList = new List<string>();

            

            List<string> selectedCriancaList = new List<string>();
            foreach (var item in Crianca)
            {
                
                selectedCriancaList.Add(item);
            }

            List<string> selectedPaiList = new List<string>();
            foreach (var item in Pai)
            {

                selectedPaiList.Add(item);
            }


            var pais = _context.Pai.ToList();
            foreach (Pai pai in pais) 
            {
                foreach (string selectedPai in selectedPaiList)
                {
                    if (pai.Nome == selectedPai)
                    {
                        if (!selectedEmailList.Contains(pai.Email))
                        {
                            selectedEmailList.Add(pai.Email);
                        }
                    }
                }

            }
            
            foreach (Pai pai in pais)
            {
                foreach (string selectedCrianca in selectedCriancaList)
                {
                    Crianca crianca = _context.Crianca.FirstOrDefault(c => c.Nome == selectedCrianca);
                    if (crianca != null)
                    {
                        foreach(string nomePai in crianca.NomesPais) 
                        {
                            if (pai.Nome == nomePai)
                            {
                                if (!selectedEmailList.Contains(pai.Email))
                                {
                                    selectedEmailList.Add(pai.Email);
                                }
                                
                            }
                        }
                    }
                }

            }



            ViewBag.Selected = selectedPaiList.Concat(selectedCriancaList).ToArray();
            ViewBag.SelectedEmail = selectedEmailList.ToArray();

            ViewBag.Crianca = new SelectList(_context.Crianca, "Nome", "Nome");
            ViewBag.Atividade = new SelectList(_context.Atividade, "Nome", "Nome");
            ViewBag.Pai = new SelectList(_context.Pai, "Nome", "Nome");
            ViewBag.Subscricao = new SelectList(_context.Subscricao, "Nome", "Nome");
            ViewBag.Produto = new SelectList(_context.Produto, "Nome", "Nome");

            return View("Index");
        }
    }
}

