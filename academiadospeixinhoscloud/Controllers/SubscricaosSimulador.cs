using academiadospeixinhoscloud.Data;
using academiadospeixinhoscloud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace academiadospeixinhoscloud.Controllers
{


    public class SalaCalendario
    {
        public string nome;
        public int quantidade;
        public DateTime date;

        public SalaCalendario(string nome, int quantidade, DateTime mes) {
        this.nome = nome;
        this.quantidade = quantidade;
        this.date = mes;
        }
        
    }



    public class SubscricaosSimulador : Controller
    {

        static string RemoveWordsFromString(string inputString)
        {
            List<string> wordsToRemove = new List<string> { "Creche","Feliz", "Normal", "Higiene", "Reserva" };
            // Split the input string into words
            string[] words = inputString.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            // Convert wordsToRemove to HashSet for O(1) average time complexity for lookups
            HashSet<string> wordsToRemoveSet = new HashSet<string>(wordsToRemove.Select(word => word.ToLower()));

            // Filter out words that are in wordsToRemoveSet
            List<string> filteredWords = words.Where(word => !wordsToRemoveSet.Contains(word.ToLower())).ToList();

            // Recreate the string from the filtered words
            string outputString = string.Join(" ", filteredWords);

            return outputString;
        }

        private readonly academiadospeixinhoscloudContext _context;

        public SubscricaosSimulador(academiadospeixinhoscloudContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<string> listaOfertas = new List<string> { "Creche Feliz", "Privado", "Higiene", "Reserva" };
            List<SelectListItem> selectList = listaOfertas.Select(x => new SelectListItem { Text = x, Value = x }).ToList();
            ViewBag.Subscricao = selectList;

            List<string> selectedCriancas = new List<string>();
            ViewBag.selectedCriancas = selectedCriancas;

            Dictionary<string, int> preenchimento = new Dictionary<string, int>();
            ViewBag.preenchimento = preenchimento;

            ViewBag.Vaga = "TEM VAGA / SEM VAGA";

            return View();
        }

        [HttpPost]
        public ActionResult Select(DateTime DataNascimento, DateTime DataInicio, IEnumerable<string> Subscricao, Boolean taekwondo, Boolean danca, Boolean ingles, int nparcial, Boolean anoCompleto)
        {
            ViewBag.Subscricao = new SelectList(_context.Subscricao, "Nome", "Nome");

            var criancas = _context.Crianca.ToList();
            var subscricoes = _context.Subscricao.ToList();
            var salas = _context.Sala.ToList();

            Dictionary<string, SalaCalendario> salaCalendarios = new Dictionary<string, SalaCalendario>();

            foreach (Subscricao subscricao in subscricoes)
            {
                if (subscricao != null)
                {
                    foreach (Crianca crianca in criancas)
                    {
                        if (crianca.NomesSubscricao.Contains(subscricao.Nome))
                        {
                            if (salaCalendarios.ContainsKey(RemoveWordsFromString(subscricao.Nome)))
                            {
                                salaCalendarios[RemoveWordsFromString(subscricao.Nome)].quantidade += 1;

                            }
                            else salaCalendarios.Add(RemoveWordsFromString(subscricao.Nome), new SalaCalendario(RemoveWordsFromString(subscricao.Nome), 1, subscricao.DataInicio));
                        }
                    }
                }
            }

            


            int idadeComeco = (DataInicio.Year - DataNascimento.Year) * 12 + DataInicio.Month - DataNascimento.Month;
            Sala salaEscolhida = null;

            if(idadeComeco >= 10 && idadeComeco < 24)
            {
                salaEscolhida = _context.Sala.FirstOrDefault(c => c.Nome == "Sala Roxa");
            }
            else if (idadeComeco >= 24 && idadeComeco < 36)
            {
                salaEscolhida = _context.Sala.FirstOrDefault(c => c.Nome == "Sala Laranja");
            }
            else if (idadeComeco >= 36 && idadeComeco < 48)
            {
                salaEscolhida = _context.Sala.FirstOrDefault(c => c.Nome == "Sala Rosa");
            }
            else if (idadeComeco >= 48 && idadeComeco < 72)
            {
                salaEscolhida = _context.Sala.FirstOrDefault(c => c.Nome == "Sala Verde");
            }

            else
            {
                return View("Index");
            }
            int maxQuantidadeSalaEscolhida = salaEscolhida.VagasTotal;

            bool temVaga = true;




            DateTime currentDate = DataInicio;
            List<DateTime> dates = new List<DateTime>();

            for(int i = 0; i<=nparcial; i++)
            {
                dates.Add(currentDate);
                currentDate = currentDate.AddMonths(1);
            }

            foreach (var item in salaCalendarios)
            {
                foreach (var date in dates)
                {
                    if (item.Value.date.Month == date.Month && (item.Value.date.Year == date.Year))
                    {
                        if (maxQuantidadeSalaEscolhida <= item.Value.quantidade)
                        {
                            temVaga = false;
                        }

                    }
                }
            }


            if(temVaga)
            {
                ViewBag.Vaga = "TEM VAGA";
                return View("Index");
            }
            ViewBag.Vaga = "NÃO TEM VAGA";
            return View("Index");
        }
    }

}
