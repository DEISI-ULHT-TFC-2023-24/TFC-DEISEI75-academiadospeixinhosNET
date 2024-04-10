using academiadospeixinhoscloud.Data;
using Microsoft.AspNetCore.Mvc;

namespace academiadospeixinhoscloud.Controllers
{
    public class SubscricaosSimulador : Controller
    {

        private readonly academiadospeixinhoscloudContext _context;

        public SubscricaosSimulador(academiadospeixinhoscloudContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
