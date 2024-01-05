using Microsoft.AspNetCore.Mvc;

namespace EbookPlatform.Areas.Admin.Controllers
{
    public class BooksController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [Area("Admin")]
        public IActionResult ShowDetails()
        {
            return View();
        }
    }
}
