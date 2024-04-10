using academiadospeixinhoscloud.Data;
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
            return View();
        }
    }
}
