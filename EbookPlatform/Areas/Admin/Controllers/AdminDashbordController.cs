using EbookPlatform.Core.Security;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EbookPlatform.Areas.Admin.Controllers
{
    public class AdminDashbordController : Controller
    {
        [Area("Admin")]
        [CheckPermission(1)]
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
