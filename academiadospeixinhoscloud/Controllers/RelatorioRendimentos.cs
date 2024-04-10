using academiadospeixinhoscloud.Data;
using Microsoft.AspNetCore.Mvc;

namespace academiadospeixinhoscloud.Controllers
{
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
    }
}
