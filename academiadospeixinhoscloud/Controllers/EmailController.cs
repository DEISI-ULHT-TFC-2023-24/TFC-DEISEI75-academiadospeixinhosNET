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
            ViewBag.Pai = new SelectList(_context.Pai, "Nome", "Nome");
            ViewBag.Atividade = new SelectList(_context.Atividade, "Nome", "Nome");
            ViewBag.Subscricao = new SelectList(_context.Subscricao, "Nome", "Nome");

            ViewBag.Sala = new SelectList(_context.Sala, "Nome", "Nome");

            List<string> selectedList = new List<string>();
            ViewBag.Selected = selectedList;

            List<string> selectedEmailList = new List<string>();
            ViewBag.SelectedEmail = selectedEmailList;

            return View(await _context.Crianca.ToListAsync());
        }

        [HttpPost]
        public ActionResult Select(IEnumerable<string> Crianca, IEnumerable<string> Pai, IEnumerable<string> Atividade, IEnumerable<string> Subscricao, IEnumerable<string> Sala)
        {
            List<string> selectedEmailList = new List<string>();

            
            var criancas = _context.Crianca.ToList();
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

            List<string> selectedAtividadeList = new List<string>();
            foreach (var item in Atividade)
            {

                selectedAtividadeList.Add(item);
            }

            List<string> selectedSubscricaoList = new List<string>();
            foreach (var item in Subscricao)
            {

                selectedSubscricaoList.Add(item);
            }

            List<string> selectedSalaList = new List<string>();
            foreach (var item in Sala)
            {

                selectedSalaList.Add(item);
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

            
            var atividades = _context.Atividade.ToList();
            foreach (Atividade atividade in atividades)
            {
                if (atividade != null) { 
                    if (selectedAtividadeList.Contains(atividade.Nome)){
                        foreach (Crianca crianca in criancas)
                        {
                            if (crianca != null)
                            {
                                foreach (string nomeAtividade in crianca.NomesAtividades)
                                {
                                    if (atividade.Nome == nomeAtividade)
                                    {
                                        foreach (string nomePai in crianca.NomesPais)
                                        {
                                            foreach (Pai pai in pais)
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
                            }
                        }
                    }
                }
            }

            var subscricaos = _context.Subscricao.ToList();
            foreach (Subscricao subscricao in subscricaos)
            {
                if (subscricao != null)
                {
                    if (selectedSubscricaoList.Contains(subscricao.Nome))
                    {
                        foreach (Crianca crianca in criancas)
                        {
                            if (crianca != null)
                            {
                                foreach (string nomeSubscricao in crianca.NomesSubscricao)
                                {
                                    if (subscricao.Nome == nomeSubscricao)
                                    {
                                        foreach (string nomePai in crianca.NomesPais)
                                        {
                                            foreach (Pai pai in pais)
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
                            }
                        }
                    }
                }
            }

            var salas = _context.Sala.ToList();
            foreach (Sala sala in salas) 
            {  
                if (sala != null)
                {
                    if (selectedSalaList.Contains(sala.Nome)) 
                    {
                        foreach (Subscricao subscricao in subscricaos)
                        {
                            if (subscricao != null)
                            {
                                if (subscricao.NomesSalas.Contains(sala.Nome))
                                {
                                    foreach (Crianca crianca in criancas)
                                    {
                                        if (crianca != null)
                                        {
                                            foreach (string nomeSubscricao in crianca.NomesSubscricao)
                                            {
                                                if (subscricao.Nome == nomeSubscricao)
                                                {
                                                    foreach (string nomePai in crianca.NomesPais)
                                                    {
                                                        foreach (Pai pai in pais)
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
                                        }
                                    }
                                }
                            }
                        }

                    }

                }
                    
            }


            ViewBag.Selected = selectedPaiList.Concat(selectedCriancaList).ToArray();
            ViewBag.SelectedEmail = selectedEmailList.ToArray();

            string multipleEmailsToSend = "";
            foreach(var item in selectedEmailList)
            {
                if (item!=null)
                {
                    multipleEmailsToSend += item + ",";
                }

            }

            ViewBag.multipleEmailsToSend = multipleEmailsToSend;
            ViewBag.Crianca = new SelectList(_context.Crianca, "Nome", "Nome");
            ViewBag.Atividade = new SelectList(_context.Atividade, "Nome", "Nome");
            ViewBag.Pai = new SelectList(_context.Pai, "Nome", "Nome");
            ViewBag.Subscricao = new SelectList(_context.Subscricao, "Nome", "Nome");
            ViewBag.Sala = new SelectList(_context.Sala, "Nome", "Nome");

            return View("Index");
        }
    }
}

