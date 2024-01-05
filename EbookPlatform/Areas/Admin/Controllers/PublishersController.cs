using Microsoft.AspNetCore.Mvc;

namespace EbookPlatform.Areas.Admin.Controllers
{
    public class PublishersController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
