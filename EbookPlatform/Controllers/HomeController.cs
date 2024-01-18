using EbookPlatform.Core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EbookPlatform.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyEbookPlatformContext _context;
        public HomeController(ILogger<HomeController> logger , MyEbookPlatformContext context)
        {
            _logger = logger;
            _context = context;
        }
      
        public IActionResult Index()
        {
            var category = _context.categories.ToList();
            ViewBag.Category = category;
            return View();
        }
    }
}
