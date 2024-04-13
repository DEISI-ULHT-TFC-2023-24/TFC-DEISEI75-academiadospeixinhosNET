using academiadospeixinhoscloud.Data;
using academiadospeixinhoscloud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        private readonly academiadospeixinhoscloudContext _context;

        public SubscricaosSimulador(academiadospeixinhoscloudContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            ViewBag.Subscricao = new SelectList(_context.Subscricao, "Nome", "Nome");

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
                            if (salaCalendarios.ContainsKey(subscricao.Nome))
                            {
                                salaCalendarios[subscricao.Nome].quantidade += 1;

                            }
                            else salaCalendarios.Add(subscricao.Nome, new SalaCalendario(subscricao.Nome, 1, subscricao.DataInicio));
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
