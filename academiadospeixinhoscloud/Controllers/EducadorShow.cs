using academiadospeixinhoscloud.Data;
using Microsoft.AspNetCore.Mvc;

namespace academiadospeixinhoscloud.Controllers
{
    public class EducadorShow : Controller
    {

        private readonly academiadospeixinhoscloudContext _context;

        public EducadorShow(academiadospeixinhoscloudContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
