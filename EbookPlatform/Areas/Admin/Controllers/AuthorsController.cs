using Microsoft.AspNetCore.Mvc;

namespace EbookPlatform.Areas.Admin.Controllers
{
    public class AuthorsController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
      
            return View();
        }
         public string myaction()
        {
            return "test github";
        }
    }
}
