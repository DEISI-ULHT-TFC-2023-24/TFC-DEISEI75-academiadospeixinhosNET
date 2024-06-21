using academiadospeixinhoscloud.Data;
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
            return View();
        }
    }
}
