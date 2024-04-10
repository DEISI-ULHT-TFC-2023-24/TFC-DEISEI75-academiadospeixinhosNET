using academiadospeixinhoscloud.Data;
using Microsoft.AspNetCore.Mvc;

namespace academiadospeixinhoscloud.Controllers
{
    public class RelatorioVagas : Controller
    {

        private readonly academiadospeixinhoscloudContext _context;

        public RelatorioVagas(academiadospeixinhoscloudContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
