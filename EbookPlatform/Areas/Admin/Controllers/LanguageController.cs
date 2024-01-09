using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace EbookPlatform.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LanguageController : Controller
    {
        private readonly ILogger<LanguageController> _logger;
        private MyEbookPlatformContext _context;
        public LanguageController(ILogger<LanguageController> logger, MyEbookPlatformContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var languages = _context.languages.Where(c => c.isDeleted == false).ToList();
            return View(languages);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Language language)
        {
            if (!ModelState.IsValid)
            {
                return View(language);

            }
            if (languageDoesExist(language.languageTitle))
            {
                ModelState.AddModelError("languageTitle", "این زبان تکراری است!");
                return View(language);
            }

            _context.languages.Add(language);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var language = _context.languages.Find(id);
            language.isDeleted = true;
            _context.languages.Update(language);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Language language = _context.languages.Find(id);

            if (language == null)
            {
                Response.StatusCode = 404;
                return View("UserNotFound");
            }

            return View(language);

        }


        [HttpPost]
        public IActionResult Edit(int id, Language language)
        {
            language.languageID = id;
            var languageFound = _context.languages.Find(id);
            languageFound.languageTitle = language.languageTitle;
            languageFound.languageDescription = language.languageDescription;

            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }


        public bool languageDoesExist(string title)
        {
            if (_context.languages.Where(o => o.languageTitle == title).Count() > 0)
            {
                return true;
            }
            else
                return false;
        }


    }
}
