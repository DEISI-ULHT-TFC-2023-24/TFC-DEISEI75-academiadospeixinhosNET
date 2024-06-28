using academiadospeixinhoscloud.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using NuGet.Packaging;

namespace academiadospeixinhoscloud.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class RelatorioRendimentos : Controller
    {

        private readonly academiadospeixinhoscloudContext _context;

        public RelatorioRendimentos(academiadospeixinhoscloudContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }

        public ActionResult Selectx(IEnumerable<string> Subscricao, DateTime DataInicio, DateTime DataFim)
        {
            var criancas = _context.Crianca.ToList();
            var subscricoes = _context.Subscricao.ToList();
            var salas = _context.Sala.ToList();

            List<string> xValues = [];
            List<int> yValues = [];

            
                foreach (var subscricao in subscricoes)
                {
                    if (subscricao.DataInicio >= DataInicio && subscricao.DataFim <= DataFim)
                    {
                    if (xValues.Contains(subscricao.DataInicio.ToString())) 
                    {
                        foreach (string subForm in Subscricao)
                        {
                            if (subscricao.Nome.Contains(subForm))
                            {
                                for(int index = 0; index <= xValues.Count() - 1; index ++)
                                {
                                    if(subscricao.DataInicio.ToString() == xValues[index])
                                    {
                                        int criancas_count = 0;
                                        foreach(var crianca in criancas)
                                        {
                                            if (crianca.NomesSubscricao.Contains(subscricao.Nome))
                                            {
                                                criancas_count++;
                                            }
                                        }
                                        yValues[index] += (criancas_count * subscricao.Preco);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (string subForm in Subscricao)
                        {
                            if (subscricao.Nome.Contains(subForm))
                            {
                                xValues.Add(subscricao.DataInicio.ToString());
                                
                                for (int index = 0; index <= xValues.Count() - 1; index++)
                                {
                                    if (subscricao.DataInicio.ToString() == xValues[index])
                                    {
                                        int criancas_count = 0;
                                        foreach (var crianca in criancas)
                                        {
                                            if (crianca.NomesSubscricao.Contains(subscricao.Nome))
                                            {
                                                criancas_count++;
                                            }
                                        }
                                        yValues.Add(criancas_count * subscricao.Preco);
                                    }
                                }
                            }
                        }
                    }
                        
                    }
                }
            // Combine xValues and yValues into a list of tuples
            var combinedList = xValues.Zip(yValues, (x, y) => new { x, y }).ToList();

            // Sort the combined list by xValues (parsed as DateTime)
            combinedList.Sort((a, b) => DateTime.Parse(a.x).CompareTo(DateTime.Parse(b.x)));

            // Separate the sorted combined list back into xValues and yValues
            var sortedXValues = combinedList.Select(item => item.x).ToList();
            var sortedYValues = combinedList.Select(item => item.y).ToList();
            
            ViewBag.xValues = sortedXValues;
            ViewBag.yValues = sortedYValues;
            return View("calculatedRendimentos");
        }
        public ActionResult Select(IEnumerable<string> Subscricao, DateTime DataInicio, DateTime DataFim)
        {
            var criancas = _context.Crianca.ToList();
            var subscricoes = _context.Subscricao.ToList();
            var salas = _context.Sala.ToList();

            List<string> xValues = [];
            List<int> yValues = [];

            List<string> xValuesLaranja = [];
            List<int> yValuesLaranja = [];

            List<string> xValuesRoxa = [];
            List<int> yValuesRoxa = [];


            foreach (var subscricao in subscricoes)
            {
                if (subscricao.DataInicio >= DataInicio && subscricao.DataFim <= DataFim)
                {
                    if (xValues.Contains(subscricao.DataInicio.ToString()))
                    {
                        foreach (string subForm in Subscricao)
                        {
                            if (subscricao.Nome.Contains(subForm))
                            {
                                for (int index = 0; index <= xValues.Count() - 1; index++)
                                {
                                    if (subscricao.DataInicio.ToString() == xValues[index])
                                    {
                                        int criancas_count = 0;
                                        foreach (var crianca in criancas)
                                        {
                                            if (crianca.NomesSubscricao.Contains(subscricao.Nome))
                                            {
                                                criancas_count++;
                                            }
                                        }
                                        yValues[index] += (criancas_count * subscricao.Preco);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (string subForm in Subscricao)
                        {
                            if (subscricao.Nome.Contains(subForm))
                            {
                                xValues.Add(subscricao.DataInicio.ToString());

                                for (int index = 0; index <= xValues.Count() - 1; index++)
                                {
                                    if (subscricao.DataInicio.ToString() == xValues[index])
                                    {
                                        int criancas_count = 0;
                                        foreach (var crianca in criancas)
                                        {
                                            if (crianca.NomesSubscricao.Contains(subscricao.Nome))
                                            {
                                                criancas_count++;
                                            }
                                        }
                                        yValues.Add(criancas_count * subscricao.Preco);
                                    }
                                }
                            }
                        }
                    }

                }
            }

            foreach (var subscricao in subscricoes)
            {
                if (subscricao.DataInicio >= DataInicio && subscricao.DataFim <= DataFim && subscricao.NomesSalas.Contains("Sala Roxa"))
                {
                    if (xValuesRoxa.Contains(subscricao.DataInicio.ToString()))
                    {
                        foreach (string subForm in Subscricao)
                        {
                            if (subscricao.Nome.Contains(subForm))
                            {
                                for (int index = 0; index <= xValuesRoxa.Count() - 1; index++)
                                {
                                    if (subscricao.DataInicio.ToString() == xValuesRoxa[index])
                                    {
                                        int criancas_count = 0;
                                        foreach (var crianca in criancas)
                                        {
                                            if (crianca.NomesSubscricao.Contains(subscricao.Nome))
                                            {
                                                criancas_count++;
                                            }
                                        }
                                        yValuesRoxa[index] += (criancas_count * subscricao.Preco);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (string subForm in Subscricao)
                        {
                            if (subscricao.Nome.Contains(subForm))
                            {
                                xValuesRoxa.Add(subscricao.DataInicio.ToString());

                                for (int index = 0; index <= xValuesRoxa.Count() - 1; index++)
                                {
                                    if (subscricao.DataInicio.ToString() == xValuesRoxa[index])
                                    {
                                        int criancas_count = 0;
                                        foreach (var crianca in criancas)
                                        {
                                            if (crianca.NomesSubscricao.Contains(subscricao.Nome))
                                            {
                                                criancas_count++;
                                            }
                                        }
                                        yValuesRoxa.Add(criancas_count * subscricao.Preco);
                                    }
                                }
                            }
                        }
                    }

                }
            }

            foreach (var subscricao in subscricoes)
            {
                if (subscricao.DataInicio >= DataInicio && subscricao.DataFim <= DataFim && subscricao.NomesSalas.Contains("Sala Laranja"))
                {
                    if (xValuesLaranja.Contains(subscricao.DataInicio.ToString()))
                    {
                        foreach (string subForm in Subscricao)
                        {
                            if (subscricao.Nome.Contains(subForm))
                            {
                                for (int index = 0; index <= xValuesLaranja.Count() - 1; index++)
                                {
                                    if (subscricao.DataInicio.ToString() == xValuesLaranja[index])
                                    {
                                        int criancas_count = 0;
                                        foreach (var crianca in criancas)
                                        {
                                            if (crianca.NomesSubscricao.Contains(subscricao.Nome))
                                            {
                                                criancas_count++;
                                            }
                                        }
                                        yValuesLaranja[index] += (criancas_count * subscricao.Preco);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (string subForm in Subscricao)
                        {
                            if (subscricao.Nome.Contains(subForm))
                            {
                                xValuesLaranja.Add(subscricao.DataInicio.ToString());

                                for (int index = 0; index <= xValuesLaranja.Count() - 1; index++)
                                {
                                    if (subscricao.DataInicio.ToString() == xValuesLaranja[index])
                                    {
                                        int criancas_count = 0;
                                        foreach (var crianca in criancas)
                                        {
                                            if (crianca.NomesSubscricao.Contains(subscricao.Nome))
                                            {
                                                criancas_count++;
                                            }
                                        }
                                        yValuesLaranja.Add(criancas_count * subscricao.Preco);
                                    }
                                }
                            }
                        }
                    }

                }
            }

            // Convert string dates in xValues to DateTime objects for sorting
            List<DateTime> sortedDates = xValues.Select(date => DateTime.Parse(date)).ToList();

            // Combine lists into a list of tuples
            var combinedList = sortedDates.Zip(yValues, (x, y) => new { x, y })
                                          .Zip(yValuesLaranja, (pair, yLaranja) => new { pair.x, pair.y, yLaranja })
                                          .Zip(yValuesRoxa, (pair, yRoxa) => new { pair.x, pair.y, pair.yLaranja, yRoxa })
                                          .ToList();

            // Sort the combined list by sortedDates
            combinedList.Sort((a, b) => a.x.CompareTo(b.x));

            // Separate the sorted values back into lists
            xValues = combinedList.Select(item => item.x.ToString("yyyy-MM-dd")).ToList(); // Convert back to string format if needed
            yValues = combinedList.Select(item => item.y).ToList();
            yValuesLaranja = combinedList.Select(item => item.yLaranja).ToList();
            yValuesRoxa = combinedList.Select(item => item.yRoxa).ToList();


            ViewBag.xValues = xValues;
            ViewBag.yValues = yValues;

            ViewBag.yValuesLaranja = yValuesLaranja;
            ViewBag.yValuesRoxa = yValuesRoxa;
            return View("calculatedRendimentos");
        }
    }
}
