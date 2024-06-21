using academiadospeixinhoscloud.Data;
using academiadospeixinhoscloud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace academiadospeixinhoscloud.Controllers
{
    public class EventosShow : Controller
    {

        private readonly academiadospeixinhoscloudContext _context;

        public EventosShow(academiadospeixinhoscloudContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var eventos = _context.Evento.ToList();
            List<Evento> eventosBag = new List<Evento> { };

            foreach (var evento in eventos)
            {
                eventosBag.Add(evento);
            }

            ViewBag.eventosBag = eventosBag;

            return View();
        }
    }
}
