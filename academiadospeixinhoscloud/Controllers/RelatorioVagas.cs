using academiadospeixinhoscloud.Data;
using academiadospeixinhoscloud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace academiadospeixinhoscloud.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class RelatorioVagas : Controller
    {

        public class MonthSala
        {
            public string keySalaNomeData;
            public string nomeSala;
            public DateTime data;
            public int quantidadeNormal;
            public int quantidadeHigiene;
            public int quantidadeCrecheFeliz;
            public int quantidadeReserva;
            public string dataString;

            public int quantidadeTotal
            {
                get
                {
                    return quantidadeNormal + quantidadeHigiene + quantidadeCrecheFeliz + quantidadeReserva;
                }
            }

            public MonthSala(string keySalaNomeData, string nomeSala, DateTime data, int quantidadeNormal, int quantidadeHigiene, int quantidadeCrecheFeliz, int quantidadeReserva)
            {
                this.keySalaNomeData = keySalaNomeData;
                this.nomeSala = nomeSala; 
                this.data = data;
                this.quantidadeNormal = quantidadeNormal;
                this.quantidadeHigiene = quantidadeHigiene;
                this.quantidadeCrecheFeliz = quantidadeCrecheFeliz;
                this.quantidadeReserva = quantidadeReserva;
                this.dataString = data.ToString("MMM yyyy", CultureInfo.InvariantCulture);
            }
        }

        private readonly academiadospeixinhoscloudContext _context;

        public RelatorioVagas(academiadospeixinhoscloudContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Select(DateTime DataInicio, DateTime DataFim)
        {
            string error = "empty";
            if (DataInicio > DataFim)
            {
                error = "inicio > fim";
            }



            ViewBag.Vaga = "TEM VAGA / SEM VAGA";
            ViewBag.error = error;

            List<string> months = new List<string>();
            DateTime current = new DateTime(DataInicio.Year, DataInicio.Month, 1);

            while (current <= DataFim)
            {
                months.Add(current.ToString("MMMM yyyy", CultureInfo.InvariantCulture));
                current = current.AddMonths(1);
            }
            ViewBag.months = months;


            var criancas = _context.Crianca.ToList();
            var subscricoes = _context.Subscricao.ToList();
            var salas = _context.Sala.ToList();

            Dictionary<string, MonthSala> MonthSalasRoxa = new Dictionary<string, MonthSala>();
            Dictionary<string, MonthSala> MonthSalasLaranja = new Dictionary<string, MonthSala>();
            Dictionary<string, MonthSala> MonthSalasRosa = new Dictionary<string, MonthSala>();
            Dictionary<string, MonthSala> MonthSalasVerde = new Dictionary<string, MonthSala>();



            foreach (Subscricao subscricao in subscricoes)
            {
                if (subscricao != null)
                {
                    foreach (Crianca crianca in criancas)
                    {
                        if (crianca.NomesSubscricao.Contains(subscricao.Nome))
                        {
                            string nomeSala = "empty";
                            if (subscricao.NomesSalas.Contains("Sala Roxa"))
                            {
                                nomeSala = "Sala Roxa";
                            }
                            if (subscricao.NomesSalas.Contains("Sala Laranja"))
                            {
                                nomeSala = "Sala Laranja";
                            }
                            if (subscricao.NomesSalas.Contains("Sala Rosa"))
                            {
                                nomeSala = "Sala Rosa";
                            }
                            if (subscricao.NomesSalas.Contains("Sala Verde"))
                            {
                                nomeSala = "Sala Verde";
                            }

                            if (nomeSala != null && nomeSala != "empty")
                            {
                                string keySalaNome = nomeSala + subscricao.DataInicio.ToString();

                                MonthSala monthSala = new MonthSala(keySalaNome, nomeSala, subscricao.DataInicio, 0,0,0,0);

                                if(nomeSala == "Sala Roxa") {

                                    if (MonthSalasRoxa.ContainsKey(keySalaNome))
                                    {
                                        if (subscricao.Nome.Contains("Normal"))
                                        {
                                            MonthSalasRoxa[keySalaNome].quantidadeNormal += 1;
                                        }
                                        if (subscricao.Nome.Contains("Higiene"))
                                        {
                                            MonthSalasRoxa[keySalaNome].quantidadeHigiene += 1;
                                        }
                                        if (subscricao.Nome.Contains("Creche Feliz"))
                                        {
                                            MonthSalasRoxa[keySalaNome].quantidadeCrecheFeliz += 1;
                                        }
                                        if (subscricao.Nome.Contains("Reserva"))
                                        {
                                            MonthSalasRoxa[keySalaNome].quantidadeReserva += 1;
                                        }
                                    }
                                    else
                                    {
                                        if (subscricao.Nome.Contains("Normal"))
                                        {
                                            monthSala.quantidadeNormal += 1;
                                        }
                                        if (subscricao.Nome.Contains("Higiene"))
                                        {
                                            monthSala.quantidadeHigiene += 1;
                                        }
                                        if (subscricao.Nome.Contains("Creche Feliz"))
                                        {
                                            monthSala.quantidadeCrecheFeliz += 1;
                                        }
                                        if (subscricao.Nome.Contains("Reserva"))
                                        {
                                            monthSala.quantidadeReserva += 1;
                                        }
                                        MonthSalasRoxa.Add(monthSala.keySalaNomeData, monthSala);
                                    }
                                }
                                if (nomeSala == "Sala Laranja")
                                {

                                    if (MonthSalasLaranja.ContainsKey(keySalaNome))
                                    {
                                        if (subscricao.Nome.Contains("Normal"))
                                        {
                                            MonthSalasLaranja[keySalaNome].quantidadeNormal += 1;
                                        }
                                        if (subscricao.Nome.Contains("Higiene"))
                                        {
                                            MonthSalasLaranja[keySalaNome].quantidadeHigiene += 1;
                                        }
                                        if (subscricao.Nome.Contains("Creche Feliz"))
                                        {
                                            MonthSalasLaranja[keySalaNome].quantidadeCrecheFeliz += 1;
                                        }
                                        if (subscricao.Nome.Contains("Reserva"))
                                        {
                                            MonthSalasLaranja[keySalaNome].quantidadeReserva += 1;
                                        }
                                    }
                                    else
                                    {
                                        if (subscricao.Nome.Contains("Normal"))
                                        {
                                            monthSala.quantidadeNormal += 1;
                                        }
                                        if (subscricao.Nome.Contains("Higiene"))
                                        {
                                            monthSala.quantidadeHigiene += 1;
                                        }
                                        if (subscricao.Nome.Contains("Creche Feliz"))
                                        {
                                            monthSala.quantidadeCrecheFeliz += 1;
                                        }
                                        if (subscricao.Nome.Contains("Reserva"))
                                        {
                                            monthSala.quantidadeReserva += 1;
                                        }
                                        MonthSalasLaranja.Add(monthSala.keySalaNomeData, monthSala);
                                    }
                                }
                                if (nomeSala == "Sala Rosa")
                                {

                                    if (MonthSalasRosa.ContainsKey(keySalaNome))
                                    {
                                        if (subscricao.Nome.Contains("Normal"))
                                        {
                                            MonthSalasRosa[keySalaNome].quantidadeNormal += 1;
                                        }
                                        if (subscricao.Nome.Contains("Higiene"))
                                        {
                                            MonthSalasRosa[keySalaNome].quantidadeHigiene += 1;
                                        }
                                        if (subscricao.Nome.Contains("Creche Feliz"))
                                        {
                                            MonthSalasRosa[keySalaNome].quantidadeCrecheFeliz += 1;
                                        }
                                        if (subscricao.Nome.Contains("Reserva"))
                                        {
                                            MonthSalasRosa[keySalaNome].quantidadeReserva += 1;
                                        }
                                    }
                                    else
                                    {
                                        if (subscricao.Nome.Contains("Normal"))
                                        {
                                            monthSala.quantidadeNormal += 1;
                                        }
                                        if (subscricao.Nome.Contains("Higiene"))
                                        {
                                            monthSala.quantidadeHigiene += 1;
                                        }
                                        if (subscricao.Nome.Contains("Creche Feliz"))
                                        {
                                            monthSala.quantidadeCrecheFeliz += 1;
                                        }
                                        if (subscricao.Nome.Contains("Reserva"))
                                        {
                                            monthSala.quantidadeReserva += 1;
                                        }
                                        MonthSalasRosa.Add(monthSala.keySalaNomeData, monthSala);
                                    }
                                }
                                if (nomeSala == "Sala Verde")
                                {

                                    if (MonthSalasVerde.ContainsKey(keySalaNome))
                                    {
                                        if (subscricao.Nome.Contains("Normal"))
                                        {
                                            MonthSalasVerde[keySalaNome].quantidadeNormal += 1;
                                        }
                                        if (subscricao.Nome.Contains("Higiene"))
                                        {
                                            MonthSalasVerde[keySalaNome].quantidadeHigiene += 1;
                                        }
                                        if (subscricao.Nome.Contains("Creche Feliz"))
                                        {
                                            MonthSalasVerde[keySalaNome].quantidadeCrecheFeliz += 1;
                                        }
                                        if (subscricao.Nome.Contains("Reserva"))
                                        {
                                            MonthSalasVerde[keySalaNome].quantidadeReserva += 1;
                                        }
                                    }
                                    else
                                    {
                                        if (subscricao.Nome.Contains("Normal"))
                                        {
                                            monthSala.quantidadeNormal += 1;
                                        }
                                        if (subscricao.Nome.Contains("Higiene"))
                                        {
                                            monthSala.quantidadeHigiene += 1;
                                        }
                                        if (subscricao.Nome.Contains("Creche Feliz"))
                                        {
                                            monthSala.quantidadeCrecheFeliz += 1;
                                        }
                                        if (subscricao.Nome.Contains("Reserva"))
                                        {
                                            monthSala.quantidadeReserva += 1;
                                        }
                                        MonthSalasVerde.Add(monthSala.keySalaNomeData, monthSala);
                                    }
                                }
                            } 
                        }
                    }
                }
            }
            ViewBag.MonthSalasRoxa = MonthSalasRoxa.Values;
            ViewBag.MonthSalasLaranja = MonthSalasLaranja.Values;
            ViewBag.MonthSalasRosa = MonthSalasRosa.Values;
            ViewBag.MonthSalasVerde = MonthSalasVerde.Values;
            return View("calculated");
        }
    }
}
