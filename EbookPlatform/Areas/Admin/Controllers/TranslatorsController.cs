using Microsoft.AspNetCore.Mvc;

namespace EbookPlatform.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TranslatorsController : Controller
    {
        private readonly ILogger<TranslatorsController> _logger;
        private MyEbookPlatformContext _context;
        public TranslatorsController(ILogger<TranslatorsController> logger, MyEbookPlatformContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            var translators = _context.translators.Where(c => c.isDeleted == false).ToList();
            return View(translators);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Translator translator)
        {
            if (!ModelState.IsValid)
            {
                return View(translator);

            }
            if (translatorDoesExist(translator.translatorFullName))
            {
                ModelState.AddModelError("translatorFullName", "این نویسنده تکراری است!");
                return View(translator);
            }

            _context.translators.Add(translator);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var translator = _context.translators.Find(id);
            translator.isDeleted = true;
            _context.translators.Update(translator);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Translator translator = _context.translators.Find(id);

            if (translator == null)
            {
                Response.StatusCode = 404;
                return View("UserNotFound");
            }

            return View(translator);

        }

        [HttpPost]
        public IActionResult Edit(int id, Translator translator)
        {
            translator.translatorID = id;
            var translatorFound = _context.translators.Find(id);
            translatorFound.translatorFullName = translator.translatorFullName;
            translatorFound.description = translator.description;

            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }


        public bool translatorDoesExist(string fullName)
        {
            if (_context.translators.Where(o => o.translatorFullName == fullName).Count() > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
