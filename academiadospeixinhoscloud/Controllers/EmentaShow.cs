using academiadospeixinhoscloud.Data;
using academiadospeixinhoscloud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace academiadospeixinhoscloud.Controllers
{
    public class EmentaShow : Controller
    {
        private readonly academiadospeixinhoscloudContext _context;

        public EmentaShow(academiadospeixinhoscloudContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var ementas = _context.Ementa.ToList();
            List<Ementa> ementasBagRoxaLaranja = new List<Ementa> { };
            List<Ementa> ementasBagRosaVerde = new List<Ementa> { };

            foreach (var ementa in ementas)
            {
                if (ementa.NomesSalas.Contains("Roxa e Laranja"))
                {
                    ementasBagRoxaLaranja.Add(ementa);
                }
                if (ementa.NomesSalas.Contains("Rosa e Verde"))
                {
                    ementasBagRosaVerde.Add(ementa);
                }
            }

            ViewBag.ementasBagRoxaLaranja = ementasBagRoxaLaranja;
            ViewBag.ementasBagRosaVerde = ementasBagRosaVerde;

            return View();
        }
    }
}
