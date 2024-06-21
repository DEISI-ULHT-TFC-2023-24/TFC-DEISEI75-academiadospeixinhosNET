using academiadospeixinhoscloud.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
