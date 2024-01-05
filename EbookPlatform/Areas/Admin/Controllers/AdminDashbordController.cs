using Microsoft.AspNetCore.Mvc;

namespace EbookPlatform.Areas.Admin.Controllers
{
    public class AdminDashbordController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
        
            return View();
        }
        public string authors()
        {
            return "hello havij";
        }
        public IActionResult pulishers()
        {
            return View();
        }
        public IActionResult translators()
        {
            return View();
        }
    }
}
